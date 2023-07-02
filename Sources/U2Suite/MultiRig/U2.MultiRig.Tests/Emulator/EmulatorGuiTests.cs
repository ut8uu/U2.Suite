using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.MultiRig.Emulators.Gui;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class EmulatorGuiTests
    {
        private UpDownDigitViewModel GetUpDownDigit(int index)
        {
            return new UpDownDigitViewModel
            {
                Value = 1234567890,
                Index = index,
                MaxValue = 9999999999,
            };
        }

        [Fact]
        public void CanManageUpDownValues()
        {
            var upDownDigit = GetUpDownDigit(0);
            upDownDigit.Increment();
            Assert.Equal(1234567891, upDownDigit.Value);
            Assert.Equal(1, upDownDigit.DisplayValue);

            upDownDigit.Decrement();
            upDownDigit.Decrement();
            Assert.Equal(1234567889, upDownDigit.Value);
            Assert.Equal(9, upDownDigit.DisplayValue);

            upDownDigit = GetUpDownDigit(3); // thousands
            upDownDigit.Increment();
            Assert.Equal(1234568890, upDownDigit.Value);
            Assert.Equal(8, upDownDigit.DisplayValue);

            upDownDigit.Decrement();
            Assert.Equal(1234567890, upDownDigit.Value);
            Assert.Equal(7, upDownDigit.DisplayValue);
        }
    }
}
