﻿/* 
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
using JetBrains.Annotations;

namespace U2.MultiRig.Code.UDP;

public enum PacketChunkType
{
    MagicNumber,
    
}

public class MagicNumberPacketChunk : UdpPacketChunk<string?>
{
    public MagicNumberPacketChunk(byte[] data) 
        : base("MagicNumber", PacketChunkType.MagicNumber, 0, 4, data)
    {
    }

    internal override string? GetValueFromBytes(byte[] data)
    {
        var chunkData = GetBytes(data, StartPosition, ChunkSize);
        return ByteFunctions.BytesToHex(chunkData);
    }

    internal override byte[] GetBytesFromValue()
    {
        return ByteFunctions.HexStrToBytes(Value ?? string.Empty);
    }
}

public abstract class UdpPacketChunk<T>
{
    private readonly byte[] _data;

    protected UdpPacketChunk(string name, PacketChunkType type, int start, int len, byte[] data)
    {
        Name = name;
        ChunkType = type;
        StartPosition = start;
        ChunkSize = len;
        _data = data;
        Value = default(T);
        
        Init();
    }

    protected void Init()
    {
        Value = GetValueFromBytes(_data);
    }

    protected static byte[] GetBytes(byte[] data, int start, int len)
    {
        if (start + len >= data.Length)
        {
            throw new UdpPacketException($"Data too short.");
        }

        return data.Skip(start).Take(len).ToArray();
    }

    internal virtual T? GetValueFromBytes(byte[] data)
    {
        throw new NotImplementedException();
    }

    internal virtual byte[] GetBytesFromValue()
    {
        throw new NotImplementedException();
    }

    public string Name { get; }
    public PacketChunkType ChunkType { get; }
    public int StartPosition { get; }
    public int ChunkSize { get; }

    public T? Value { get; private set; }
}