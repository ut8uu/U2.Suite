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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using U2.CommonControls;
using U2.Core;

namespace U2.Logger;

public sealed class TextInputPanelViewModel : ViewModelBase
{
    private bool _internalChange = false;
    private readonly Timer _timer;
    private readonly ILog _logger = LogManager.GetLogger("Logger");

    public const string CallsignTextBox = nameof(CallsignTextBox);
    public const string RstSentTextBox = nameof(RstSentTextBox);
    public const string RstRcvdTextBox = nameof(RstRcvdTextBox);
    public const string OperatorTextBox = nameof(OperatorTextBox);
    public const string CommentsTextBox = nameof(CommentsTextBox);
    public const string TimestampTextBox = nameof(TimestampTextBox);
    public const string ModeTextBox = nameof(ModeTextBox);
    public const string FrequencyTextBox = nameof(FrequencyTextBox);

    public TextInputPanelViewModel()
    {
        Messenger.Default.Register<ExecuteCommandMessage>(this,
            AcceptExecuteCommandMessage);

        _timer = new Timer(TimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        SetDefaultValues();
    }

    private void TimerTick(object? state)
    {
        if (Realtime)
        {
            Timestamp = DateTime.UtcNow;
        }
    }

    #region Properties

    public string CallsignInputTitle { get; set; } = Resources.Callsign;
    public string RstSentInputTitle { get; set; } = Resources.RstSent;
    public string RstRcvdInputTitle { get; set; } = Resources.RstReceived;
    public string OperatorInputTitle { get; set; } = Resources.Operator;
    public string FrequencyInputTitle { get; set; } = Resources.FreqMhz;
    public string ModeInputTitle { get; set; } = Resources.Mode;
    public string BandInputTitle { get; set; } = Resources.Band;
    public string CommentsInputTitle { get; set; } = Resources.Comments;
    public string TimestampInputTitle { get; set; } = Resources.Timestamp;
    public string RealtimeTitle { get; set; } = Resources.realtime;

    public Window Owner { get; set; } = default!;
    public string Callsign { get; set; } = default!;
    public string RstSent { get; set; } = default!;
    public string RstRcvd { get; set; } = default!;
    public string Operator { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public string Frequency { get; set; } = default!;
    public string Mode { get; set; } = default!;
    public string Band { get; set; } = default!;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool Realtime { get; set; } = true;
    public bool TimestampEnabled => !Realtime;

    public ApplicationTextBox FocusedTextBox { get; set; } = ApplicationTextBox.Callsign;

    public static ObservableCollection<string> AllModes => new(ConversionHelper.AllModes.Select(m => m.Name));
    public static ObservableCollection<string> AllBands => new(ConversionHelper.AllBands.Select(m => m.Name));

    #endregion

    private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
    {
        switch (message.CommandToExecute)
        {
            case CommandToExecute.ClearTextInputs:
                _logger.Debug("Accepted ClearTextInputs command.");
                ClearAll();
                break;
            case CommandToExecute.InitQso:
                _logger.Debug("Accepted InitQso command.");
                SetDefaultValues();
                break;
            case CommandToExecute.SaveQso:
            {
                if (message.CommandParameters == null)
                {
                    _logger.Debug("Accepted SaveQso(null) command.");
                    // empty parameters are being sent when this is 
                    // an initial command
                    if (!decimal.TryParse(this.Frequency, NumberStyles.Number,
                            CultureInfo.DefaultThreadCurrentUICulture, out decimal frequency))
                    {
                        if (!decimal.TryParse(Frequency, NumberStyles.Number, CultureInfo.InvariantCulture,
                                out frequency))
                        {
                            _logger.Error($"Cannot parse given double value: {Frequency}.");
                            frequency = ConversionHelper.BandNameAndModeToFrequency(Band, Mode);
                            _logger.Info($"Frequency {frequency} calculated based on mode {Mode} and band {Band}.");
                        }
                    }
                    var formData = new QsoData
                    {
                        Band = this.Band,
                        Callsign = this.Callsign,
                        Comments = this.Comments,
                        FreqMhz = frequency,
                        Mode = this.Mode,
                        Operator = this.Operator,
                        RstRcvd = this.RstRcvd,
                        RstSent = this.RstSent,
                        Timestamp = this.Timestamp,
                    };
                    var saveQsoMessage = new ExecuteCommandMessage(CommandToExecute.SaveQso, formData);
                    Messenger.Default.Send(saveQsoMessage);
                }

                break;
            }
            case CommandToExecute.DeleteQso:
                break;
            case CommandToExecute.RefreshLog:
                break;
            case CommandToExecute.CreateLog:
                break;
            case CommandToExecute.UpdateLog:
                break;
            case CommandToExecute.OpenLog:
                break;
            case CommandToExecute.SwitchLog:
                break;
            case CommandToExecute.ShowMessage:
                break;
            case CommandToExecute.ShutDown:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(message.CommandToExecute));
        }
    }

    private void ClearAll()
    {
        _internalChange = true;

        Callsign = string.Empty;
        RstSent = ConversionHelper.ModeToDefaultReport(Mode);
        RstRcvd = ConversionHelper.ModeToDefaultReport(Mode);
        Operator = string.Empty;
        Comments = string.Empty;
        Timestamp = DateTime.UtcNow;

        _timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

        _internalChange = false;
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (_internalChange)
        {
            return;
        }

        switch (propertyName)
        {
            case nameof(Callsign):
                break;
            case nameof(RstRcvd):
                _internalChange = true;
                RstRcvd = ConversionHelper.FixRst(Mode, RstRcvd);
                _internalChange = false;
                _logger.Debug($"New {propertyName} value: {RstRcvd}");
                break;
            case nameof(RstSent):
                _internalChange = true;
                RstSent = ConversionHelper.FixRst(Mode, RstSent);
                _internalChange = false;
                _logger.Debug($"New {propertyName} value: {RstSent}");
                break;
            case nameof(Operator):
                _logger.Debug($"New {propertyName} value: {Operator}");
                break;
            case nameof(Comments):
                _logger.Debug($"New {propertyName} value: {Comments}");
                break;
            case nameof(Mode):
                {
                    UpdateFrequencyFromModeAndBand();
                    _logger.Debug($"New {propertyName} value: {Mode}");
                }
                break;
            case nameof(Band):
                {
                    UpdateFrequencyFromModeAndBand();
                    _logger.Debug($"New {propertyName} value: {Band}");
                }
                break;
            case nameof(Timestamp):
                break;
            case nameof(Frequency):
                var bandName = string.Empty;
                var freq = StringConverter.StringToDecimal(Frequency);
                if (freq > 0)
                {
                    bandName = ConversionHelper.FrequencyToBandName(freq);
                }

                if (!string.IsNullOrEmpty(bandName))
                {
                    if (Band != bandName)
                    {
                        Band = bandName;
                        _logger.Debug($"Frequency is {Frequency}. Mode changed to {Mode}.");
                    }
                }
                else
                {
                    Band = string.Empty;
                    var message = string.Format(Resources.FrequencyNotResolvedFmt, Frequency);
                    throw new Avalonia.Data.DataValidationException(message);
                }
                _logger.Debug($"New {propertyName} value: {Frequency}");
                break;
            default:
                return;
        }
    }

    private void UpdateFrequencyFromModeAndBand()
    {
        if (string.IsNullOrEmpty(Mode) || string.IsNullOrEmpty(Band))
        {
            return;
        }

        _internalChange = true;
        Frequency = ConversionHelper.BandNameAndModeToFrequency(Band, Mode).ToString("F3");
        _internalChange = false;
    }

    private void SetDefaultValues()
    {
        if (string.IsNullOrEmpty(Mode))
        {
            Mode = AllModes.First();
        }
        if (string.IsNullOrEmpty(Band))
        {
            Band = AllBands.First();
        }

        // force initialization of Mode and Band
        OnPropertyChanged(nameof(Band));
        OnPropertyChanged(nameof(Mode));

        Frequency = ConversionHelper.BandNameAndModeToFrequency(Band, Mode).ToString();
        RstSent = ConversionHelper.ModeToDefaultReport(Mode);
        RstRcvd = RstSent;
    }
}
