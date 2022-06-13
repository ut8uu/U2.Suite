/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Autofac;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig.Emulators.Lib;

public abstract class RigEmulatorBase : IRigEmulator
{
    private static IRigEmulator _instance;

    protected RigEmulatorBase(string iniFileContent)
    {
        var stream = new MemoryStream(Encoding.ASCII.GetBytes(iniFileContent));
        RigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
    }

    public static IRigEmulator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = MultiRigApplicationContext.Instance.Container.Resolve<IRigEmulator>();
                Debug.Assert(_instance != null, "Cannot resolve a RigEmulator instance.");
            }
            return _instance;
        }
        set => _instance = value;
    }

    public RigCommands RigCommands { get; set; }

    public MessageDisplayModes MessageDisplayModes { get; set; }

    public int Freq { get; set; }

    public int FreqA { get; set; }

    public int FreqB { get; set; }

    public int Pitch { get; set; }

    public int RitOffset { get; set; }

    public RigParameter Vfo { get; set; }

    public RigParameter Rit { get; set; }

    public RigParameter Xit { get; set; }

    public RigParameter Tx { get; set; }

    public RigParameter Mode { get; set; }

    public RigParameter Split { get; set; }

    private void DisplayMessage(MessageDisplayModes messageMode, string message)
    {
        if (MessageDisplayModes.HasFlag(messageMode))
        {
            Console.WriteLine(message);
        }
    }

    public bool TryPrepareResponse(RigCommand command, out byte[] response)
    {
        response = command.Validation.Flags;

        switch (command.Values.FirstOrDefault().Param)
        {
            case RigParameter.Freq:
                return TryInjectValue(command, Freq, out response);
            case RigParameter.FreqA:
                return TryInjectValue(command, FreqA, out response);
            case RigParameter.FreqB:
                return TryInjectValue(command, FreqB, out response);
            case RigParameter.Pitch:
                return TryInjectValue(command, Pitch, out response);
            case RigParameter.RitOffset:
                return TryInjectValue(command, RitOffset, out response);
        }

        var allParameters = new[] { Mode, Vfo, Rit, Xit, Tx, Split };

        foreach (var parameter in allParameters)
        {
            if (parameter == RigParameter.None)
            {
                continue;
            }

            var modeFlag = command.Flags.FirstOrDefault(f => f.Param == parameter);
            if (modeFlag.Flags == null || modeFlag.Flags.Length == 0)
            {
                continue;
            }
            var flags = command.Flags.FirstOrDefault(f => f.Param == parameter).Flags;
            for (var i = 0; i < flags.Length; i++)
            {
                response[i] |= flags[i];
            }

            return true;
        }

        Debug.Fail($"Parameter {command.Value.Param} not supported.");
        return false;
    }

    public bool TryPrepareWriteCommandResponse(RigParameter parameter, RigCommand command, out byte[] response)
    {
        response = command.Validation.Flags;

        var parametersWithValues = new[]
        {
            RigParameter.Freq,
            RigParameter.FreqA,
            RigParameter.FreqB,
            RigParameter.Pitch,
            RigParameter.RitOffset,
            RigParameter.Rit0,
            RigParameter.VfoA,
            RigParameter.VfoB,
            RigParameter.VfoEqual,
            RigParameter.VfoSwap,
            RigParameter.VfoAA,
            RigParameter.VfoAB,
            RigParameter.VfoBA,
            RigParameter.VfoBB,
        };

        if (parametersWithValues.Contains(parameter))
        {
            return true;
        }

        var onOffParameters = new[]
        {
            RigParameter.AM,
            RigParameter.FM,
            RigParameter.CW_L,
            RigParameter.CW_U,
            RigParameter.SSB_L,
            RigParameter.SSB_U,
            RigParameter.DIG_L,
            RigParameter.DIG_U,
            RigParameter.Tx,
            RigParameter.Rx,
            RigParameter.XitOff,
            RigParameter.XitOn,
            RigParameter.RitOff,
            RigParameter.RitOn,
            RigParameter.SplitOff,
            RigParameter.SplitOn,
        };

        return onOffParameters.Contains(parameter);
    }

    private bool TryInjectValue(RigCommand command, int value, out byte[] response)
    {
        response = command.Validation.Flags;

        var info = command.Values[0];
        var bytes = ConversionFunctions.FormatValue(value, info);
        if (bytes.Length == 0)
        {
            return false;
        }

        Debug.Assert(bytes.Length == info.Len,
            $"A formatted value {ByteFunctions.BytesToHex(bytes)} has incorrect length.");
        Array.Copy(bytes, 0, response, info.Start, info.Len);
        return true;
    }

    public bool TryExtractValue(RigCommands commands, byte[] request)
    {
        var requestHex = ByteFunctions.BytesToHex(request);
        DisplayMessage(MessageDisplayModes.Diagnostics3, $"Extracting value from {requestHex}");

        foreach (var (rigParameter, command) in commands.WriteCmd)
        {
            if (command.Code.Length != request.Length)
            {
                continue;
            }

            if (TryExtractBinaryValue(request, command, rigParameter))
            {
                return true;
            }

            if (TryExtractNumericValue(request, command))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Performs an attempt to extract a value from the request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="command"></param>
    /// <returns>Returns <see langword="true"/> if value extracted, or <see langword="false"/> otherwise.</returns>
    private bool TryExtractNumericValue(byte[] request, RigCommand command)
    {
        if (command.Value.Param == RigParameter.None)
        {
            return false;
        }

        // Freq, FreqA, FreqB, Pitch
        if (command.Code.Length != request.Length)
        {
            return false;
        }

        var clearRequest = request.ToArray();
        var cnt = 0;
        for (var i = command.Value.Start; cnt < command.Value.Len; cnt++)
        {
            clearRequest[i + cnt] = 0;
        }

        if (!command.Code.SequenceEqual(clearRequest))
        {
            return false;
        }

        var value = ConversionFunctions.UnformatValue(request, command.Value);
        switch (command.Value.Param)
        {
            case RigParameter.Freq:
                Freq = value;
                break;
            case RigParameter.FreqA:
                FreqA = value;
                break;
            case RigParameter.FreqB:
                FreqB = value;
                break;
            case RigParameter.Pitch:
                Pitch = value;
                break;
            default:
                throw new NotSupportedException($"Parameter {command.Value.Param} not supported.");
        }

        return true;
    }

    /// <summary>
    /// Performs an attempt to extract a valueless parameter,
    /// whose value is itself.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="command"></param>
    /// <param name="rigParameter"></param>
    /// <returns>Returns <see langword="true"/> if value extracted, or <see langword="false"/> otherwise.</returns>
    private bool TryExtractBinaryValue(byte[] request, RigCommand command, int rigParameter)
    {
        if (!command.Code.SequenceEqual(request))
        {
            return false;
        }

        var parameter = (RigParameter) rigParameter;
        switch (parameter)
        {
            case RigParameter.AM:
            case RigParameter.FM:
            case RigParameter.CW_L:
            case RigParameter.CW_U:
            case RigParameter.SSB_L:
            case RigParameter.SSB_U:
            case RigParameter.DIG_L:
            case RigParameter.DIG_U:
                Mode = parameter;
                break;
            case RigParameter.Tx:
            case RigParameter.Rx:
                Tx = parameter;
                break;
            case RigParameter.XitOff:
            case RigParameter.XitOn:
                Xit = parameter;
                break;
            case RigParameter.RitOff:
            case RigParameter.RitOn:
                Rit = parameter;
                break;
            case RigParameter.SplitOff:
            case RigParameter.SplitOn:
                Split = parameter;
                break;
            case RigParameter.Pitch:
                var info = new ParameterValue();
                if (command.Value.Param == parameter)
                {
                    info = command.Value;
                }
                else if (command.Values.FirstOrDefault().Param == parameter)
                {
                    info = command.Values.FirstOrDefault();
                }

                if (info.Param != RigParameter.Pitch)
                {
                    break;
                }

                Pitch = ConversionFunctions.UnformatValue(request, info);
                break;
            case RigParameter.VfoAA:
            case RigParameter.VfoAB:
                DisplayMessage(MessageDisplayModes.Debug, $"Parameter {parameter} supported, but not implemented yet.");
                break;
            default:
                //throw new ArgumentOutOfRangeException($"Parameter {parameter} not supported.");
                DisplayMessage(MessageDisplayModes.Error, $"Parameter {parameter} not supported.");
                break;
        }

        return true;
    }
}