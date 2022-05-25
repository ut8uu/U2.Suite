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
}