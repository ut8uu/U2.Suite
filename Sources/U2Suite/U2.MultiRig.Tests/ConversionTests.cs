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
