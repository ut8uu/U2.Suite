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
using Xunit;

namespace U2.MultiRig.Tests
{
    public class ConversionTests
    {
        [Fact]
        public void FromBcdBU()
        {
            var data = new byte[] { 0x10, 0x23, 0x32, 0x07 };
            var result = ConversionFunctions.FromBcdBU(data);
            Assert.Equal(10233207, result);
        }

        [Fact]
        public void FromBcdBS()
        {
            var data = new byte[] { 0x10, 0x23, 0x32, 0x07 };
            var result = ConversionFunctions.FromBcdBS(data);
            Assert.Equal(-233207, result);

            data = new byte[] { 0x00, 0x23, 0x32, 0x07 };
            result = ConversionFunctions.FromBcdBS(data);
            Assert.Equal(233207, result);
        }

        [Fact]
        public void ToBcdBU()
        {
            var result = ConversionFunctions.ToBcdBU(12345, 4);
            var expectedResult = new byte[] {0x00, 0x01, 0x23, 0x45};
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ToBcdBS()
        {
            var result = ConversionFunctions.ToBcdBS(-12345, 4);
            var expectedResult = new byte[] {0xFF, 0x01, 0x23, 0x45};
            Assert.Equal(expectedResult, result);
        }
    }
}
