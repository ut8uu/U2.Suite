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

namespace U2.MultiRig;

/// <summary>
/// An implementation of the Guest RIG class,
/// receiving UDP messages and reporting changes of the RIG parameters.
/// Corresponding changes of the RIG parameters generates a request for the
/// physical RIG update using the corresponding UDP datagrams.
/// </summary>
public sealed class GuestRig : Rig
{
    public GuestRig(int rigNumber, ushort applicationId)
        : base(RigControlType.Guest, rigNumber, applicationId, new RigSettings(), new RigCommands())
    {
    }

    public ushort HostRigId { get; set; } = 0;

    #region CustomRig members

    internal override void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind)
    {
    }

    internal override void ProcessInitReply(int number, byte[] data)
    {
    }

    internal override bool ProcessStatusReply(int number, byte[] data)
    {
        return true;
    }

    internal override void ProcessWriteReply(RigParameter param, byte[] data)
    {
    }

    internal override void AddWriteCommand(RigParameter param, int value = 0)
    {
    }

    #endregion

    #region Rig members

    protected override void OnUdpPacketReceived(RigUdpMessengerPacketEventArgs eventArgs)
    {
        var packet = eventArgs.Packet;
        if (!packet.IsValid)
        {
            return;
        }

        if (packet.ReceiverId.Value != KnownIdentifiers.MultiCast
            && packet.ReceiverId.Value != ApplicationId)
        {
            return;
        }

        switch (packet.MessageType.Value)
        {
            case MessageTypes.Status:
                ProcessStatusPacket(packet);
                break;
            case MessageTypes.Information:
                ProcessInformationPacket(packet);
                break;
            case MessageTypes.Request:
                ProcessRequestPacket(packet);
                break;
            case MessageTypes.Answer:
                ProcessAnswerPacket(packet);
                break;

        }
    }

    private void ProcessAnswerPacket(RigUdpMessengerPacket packet)
    {
        if (packet.ReceiverId.Value != ApplicationId)
        {
            // an answer packet must be addressed only
            return;
        }
    }

    private void ProcessRequestPacket(RigUdpMessengerPacket packet)
    {
        // as of now it is impossible to get a request to the guest
        return;
    }

    private void ProcessInformationPacket(RigUdpMessengerPacket packet)
    {
        Logger.Debug($"A status packet received: {ByteFunctions.BytesToHex(packet.GetBytes())}");
    }

    private void ProcessStatusPacket(RigUdpMessengerPacket packet)
    {
        Logger.Debug($"A status packet received: {ByteFunctions.BytesToHex(packet.GetBytes())}");
    }

    #endregion

    #region Setter overrides

    private void SendSetRigParameterPacket(RigParameter rigParameter, int value)
    {
        var packet = UdpPacketFactory.CreateSetRigParameterPacket(RigNumber,
            senderId: ApplicationId, receiverId: HostRigId, rigParameter, value);
        UdpMessenger.SendMultiCastMessage(packet);
    }

    /// <summary>
    /// Sets a frequency.
    /// As a guest, sends a request to host for changing the Rig parameter Freq.
    /// </summary>
    /// <param name="value"></param>
    public override void SetFreq(int value)
    {
        if (!Enabled || value == Freq)
        {
            return;
        }
        base.SetFreq(value);
        SendSetRigParameterPacket(RigParameter.Freq, value);
    }

    public override void SetFreqA(int value)
    {
        if (!Enabled || value == FreqA)
        {
            return;
        }
        base.SetFreqA(value);
        SendSetRigParameterPacket(RigParameter.FreqA, value);
    }

    public override void SetFreqB(int value)
    {
        if (!Enabled || value == FreqB)
        {
            return;
        }
        base.SetFreqB(value);
        SendSetRigParameterPacket(RigParameter.FreqB, value);
    }

    public override void SetPitch(int value)
    {
        if (!Enabled || value == Pitch)
        {
            return;
        }
        base.SetPitch(value);
        SendSetRigParameterPacket(RigParameter.Pitch, value);
    }

    public override void SetRitOffset(int value)
    {
        if (!Enabled || value == RitOffset)
        {
            return;
        }
        base.SetRitOffset(value);
        SendSetRigParameterPacket(RigParameter.RitOffset, value);
    }

    public override void SetVfo(RigParameter value)
    {
        if (!Enabled || value == Vfo)
        {
            return;
        }
        base.SetVfo(value);
        SendSetRigParameterPacket(value, 0);
    }

    public override void SetRit(RigParameter value)
    {
        if (!Enabled || value == Rit)
        {
            return;
        }
        base.SetRit(value);
        SendSetRigParameterPacket(value, 0);
    }

    public override void SetXit(RigParameter value)
    {
        if (!Enabled || value == Xit)
        {
            return;
        }
        base.SetXit(value);
        SendSetRigParameterPacket(value, 0);
    }

    public override void SetTx(RigParameter value)
    {
        if (!Enabled || value == Tx)
        {
            return;
        }
        base.SetTx(value);
        SendSetRigParameterPacket(value, 0);
    }

    public override void SetMode(RigParameter value)
    {
        if (!Enabled || value == Mode)
        {
            return;
        }
        base.SetMode(value);
        SendSetRigParameterPacket(value, 0);
    }

    #endregion

}