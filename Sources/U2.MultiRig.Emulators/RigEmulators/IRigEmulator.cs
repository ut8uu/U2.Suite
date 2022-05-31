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

namespace U2.MultiRig.Emulators;

public interface IRigEmulator
{
    /// <summary>
    /// Prepares data for sending to the calling code.
    /// Can be useful when requesting the Status requiring
    /// the value of the parameter to be injected in the reply.
    /// </summary>
    /// <param name="command">A command of the request.</param>
    /// <param name="request">A request from the calling party. Used to resolve the command.</param>
    /// <param name="response">A response to be sent to the calling party.</param>
    /// <returns>Returns <see langword="true"/> if request was resolved, <see langword="false"/> otherwise.</returns>
    bool TryPrepareResponse(RigCommand command, out byte[] response);

    /// <summary>
    /// Performs an attempt to extract value from the given request.
    /// </summary>
    /// <param name="commands">All known rig commands.</param>
    /// <param name="request">A request to be processed.</param>
    /// <returns>Returns <see langword="true"/> if request is resolved, <see langword="false"/> otherwise.</returns>
    bool TryExtractValue(RigCommands commands, byte[] request);

    int Freq { get; set; }
    int FreqA { get; set; }
    int FreqB { get; set; }
    int Pitch { get; set; }
    int RitOffset { get; set; }
}