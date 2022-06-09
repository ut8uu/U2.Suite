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

namespace U2.MultiRig.Emulators.Gui;

public enum ValueChangeType
{
    Increment,
    Decrement,
}

public sealed class ValueChangedEventArgs : EventArgs
{
    public int Value { get; set; }
    public ValueChangeType ChangeType { get; set; }
}

public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs eventArgs);

public sealed class UpDownDigitViewModel
{
    public int Index { get; set; }

    public int Value { get; set; }

    public int DisplayValue
    {
        get
        {
            var divider = Math.Pow(10, Index);
            return (int)(Value / divider) % 10;
        }
    }

    internal int CalculateNewValue(int oldValue, ValueChangeType changeType)
    {
        var multiplier = changeType == ValueChangeType.Increment ? 1 : -1;
        var addValue = (int)Math.Pow(10, Index) * multiplier;
        return oldValue + addValue;
    }

    /// <summary>
    /// Increments value at the digit's position
    /// </summary>
    public void Increment()
    {
        Value = CalculateNewValue(Value, ValueChangeType.Increment);
    }

    /// <summary>
    /// Decrements value at the digit's position
    /// </summary>
    public void Decrement()
    {
        Value = CalculateNewValue(Value, ValueChangeType.Decrement);
    }
}
