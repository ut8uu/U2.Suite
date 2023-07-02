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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.MultiRig.Code;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.MultiRig.Tests
{
    public class ByteFunctionTests
    {
        [Fact]
        public void BytesAnd()
        {
            var arr1 = new byte[] { 0x10, 0x22, 0x80, 0x55 };
            var arr2 = new byte[] { 0x30, 0xff, 0x00, 0xa9 };
            var expectedResult = new byte[] { 0x10, 0x22, 0x00, 0x01 };
            var actualResult = ByteFunctions.BytesAnd(arr1, arr2);
            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void ReverseArray()
        {
            var arr1 = new byte[] { 0x10, 0x22, 0x80, 0x55 };
            var expectedResult = new byte[] { 0x55, 0x80, 0x22, 0x10 };
            Array.Reverse(arr1);
            Assert.True(expectedResult.SequenceEqual(arr1));
        }

        [Fact]
        public void BytesToHex()
        {
            var arr1 = new byte[] { 0x10, 0x22, 0x80, 0x55 };
            var expectedResult = "10228055";
            var actualResult = ByteFunctions.BytesToHex(arr1);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void BytesToStr()
        {
            var arr1 = new byte[] { 0x41, 0x42, 0x43 };
            var expectedResult = "ABC";
            var actualResult = ByteFunctions.BytesToStr(arr1);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("01.02.03.04.05", new byte[] { 1, 2, 3, 4, 5 })]
        [InlineData("01020 30405", new byte[] { 1, 2, 3, 4, 5 })]
        [InlineData("01 02 03 04 05", new byte[] { 1, 2, 3, 4, 5 })]
        [InlineData("(abc)", new byte[] { 0x61, 0x62, 0x63 })]
        [InlineData("qwer0", new byte[] { })]
        public void StrToBytes(string str, byte[] expectedArray)
        {
            var actualArray = ByteFunctions.StrToBytes(str);
            Assert.True(actualArray.SequenceEqual(expectedArray));
        }

        [Fact]
        public void BytesToHexStr()
        {
            var bytes = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1A,
                0x05, 0x01, 0x32, 0x01, 0xFD,
            };
            var expectedString = "FEFEA4E01A05013201FD";
            var actualString = ByteFunctions.BytesToHex(bytes);
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void TestTimestamp()
        {
            var timestamp = DateTime.UnixEpoch;
            var unixEpochBytes = ByteFunctions.HexStrToBytes("0080B5F7F57F9F48");
            var bytes = ByteFunctions.TimestampToBytes(timestamp);
            var decodedTimestamp = ByteFunctions.BytesToTimestamp(bytes);

            Assert.Equal(unixEpochBytes, bytes);
            Assert.Equal(timestamp, decodedTimestamp);
        }

        [Theory]
        [InlineData("0000000000000002.0304", RigParameter.FreqA, 772)]
        [InlineData("0000000000000002.00000304", RigParameter.FreqA, 772)]
        [InlineData("0000000000000002.0000000000000304", RigParameter.FreqA, 772)]
        public void BytesToRigParameterValue(string hex, RigParameter expectedRigParameter,
            long expectedValue)
        {
            var data = ByteFunctions.HexStrToBytes(hex);
            var (parameter, value) = ByteFunctions.BytesToRigParameterValue(data);
            Assert.Equal(expectedRigParameter, parameter);
            Assert.Equal(expectedValue, value);
        }
    }
}
