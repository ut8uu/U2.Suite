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
using System.Text;

namespace U2.MultiRig;

#nullable disable
public abstract class UdpPacketChunk<T>
{
    private readonly byte[] _data;

    protected UdpPacketChunk(PacketChunkType type, int start, int len, byte[] data)
    {
        ChunkType = type;
        StartPosition = start;
        ChunkSize = len;
        _data = data;
        Value = FromBytes(_data);
    }

    protected T FromBytes(byte[] data)
    {
        return GetValueFromBytes(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="start"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    /// <exception cref="UdpPacketException"></exception>
    protected static byte[] GetBytes(byte[] data, int start, int len)
    {
        if (start + len > data.Length)
        {
            throw new UdpPacketException($"Data too short.");
        }

        return data.Skip(start).Take(len).ToArray();
    }

    internal virtual T GetValueFromBytes(byte[] data)
    {
        throw new NotImplementedException();
    }

    internal virtual byte[] GetBytesFromValue()
    {
        throw new NotImplementedException();
    }

    public PacketChunkType ChunkType { get; }
    public int StartPosition { get; }
    public int ChunkSize { get; }

    public T Value { get; private set; }

    public virtual bool IsValid => true;

    public void SetValue(T value)
    {
        Value = value;
    }

    public byte Checksum {
        get
        {
            var bytes = GetBytesFromValue();
            byte checksum = 0;
            foreach (var b in bytes)
            {
                checksum ^= b;
            }

            return checksum;
        }
}
}