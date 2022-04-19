using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.MultiRig.Code;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class ByteFunctionTests
    {
        [Fact]
        public void BytesAnd()
        {
            var arr1 = new byte[] {0x10, 0x22, 0x80, 0x55};
            var arr2 = new byte[] {0x30, 0xff, 0x00, 0xa9};
            var expectedResult = new byte[] {0x10, 0x22, 0x00, 0x01};
            var actualResult = ByteFunctions.BytesAnd(arr1, arr2);
            Assert.True(actualResult.SequenceEqual(expectedResult));
        }

        [Fact]
        public void ReverseArray()
        {
            var arr1 = new byte[] { 0x10, 0x22, 0x80, 0x55 };
            var expectedResult = new byte[] { 0x55, 0x80, 0x22, 0x10 };
            ByteFunctions.BytesReverse(arr1);
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

        [Fact]
        public void StrToHex()
        {
            var str = "ABC";
            var expectedResult = "414243";
            var actualResult = ByteFunctions.StrToHex(str);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
