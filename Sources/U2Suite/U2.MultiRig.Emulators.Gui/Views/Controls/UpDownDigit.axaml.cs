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
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace U2.MultiRig.Emulators.Gui;

public partial class UpDownDigit : UserControl
{
    private readonly UpDownDigitViewModel _viewModel;
    private int _frequency;
    private int _index;

    public UpDownDigit()
    {
        InitializeComponent();

        _viewModel = new UpDownDigitViewModel();
        DataContext = _viewModel;
        _viewModel.ValueChanged += ViewModelOnValueChanged;
    }

    private void ViewModelOnValueChanged(object sender, ValueChangedEventArgs eventargs)
    {
        Frequency = eventargs.Value;
        OnValueChanged(eventargs.Value, eventargs.ChangeType);
    }

    public event ValueChangedEventHandler ValueChanged;

    public int DisplayValue => _viewModel.DisplayValue;

    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            _viewModel.Index = value;
        }
    }

    public int Frequency
    {
        get => _frequency;
        set
        {
            _frequency = value;
            _viewModel.Value = value;
        }
    }

    public static readonly DirectProperty<UpDownDigit, int> IndexProperty =
        AvaloniaProperty.RegisterDirect<UpDownDigit, int>(nameof(Index),
            getter: o => o.Index, 
            setter: (o, v) => o.Index = v,
            unsetValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            false
        );

    public static readonly DirectProperty<UpDownDigit, int> FrequencyProperty =
        AvaloniaProperty.RegisterDirect<UpDownDigit, int>(nameof(Frequency),
            getter: o => o.Frequency, 
            setter: (o, v) => o.Frequency = v,
            unsetValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            false
        );

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void ExecuteButtonUpClick()
    {
        _viewModel.Increment();
        OnValueChanged(_viewModel.Value, ValueChangeType.Increment);
    }

    public void ExecuteButtonDownClick()
    {
        _viewModel.Decrement();
        OnValueChanged(_viewModel.Value, ValueChangeType.Decrement);
    }

    private void OnValueChanged(int value, ValueChangeType changeType)
    {
        var eventArgs = new ValueChangedEventArgs
        {
            Value = value,
            ChangeType = changeType,
        };
        ValueChanged?.Invoke(this, eventArgs);
    }

    private void InputElement_OnPointerWheelChanged(object? sender, 
        PointerWheelEventArgs e)
    {
        if (e.Delta.Y > 0)
        {
            ExecuteButtonUpClick();
        }
        else if (e.Delta.Y < 0)
        {
            ExecuteButtonDownClick();
        }

    }
}
