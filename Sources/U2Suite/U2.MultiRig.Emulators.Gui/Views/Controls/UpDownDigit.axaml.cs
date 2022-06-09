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
using Avalonia.Markup.Xaml;
using ReactiveUI.Fody.Helpers;

namespace U2.MultiRig.Emulators.Gui;

public partial class UpDownDigit : UserControl
{
    private readonly UpDownDigitViewModel _viewModel;

    public UpDownDigit()
    {
        InitializeComponent();

        _viewModel = new UpDownDigitViewModel();
        DataContext = _viewModel;
    }

    public event ValueChangedEventHandler ValueChanged;

    [Reactive] 
    public int DisplayValue => _viewModel.DisplayValue;

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void ExecuteUpButtonClick()
    {
        _viewModel.Increment();
        OnValueChanged(_viewModel.Value, ValueChangeType.Increment);
    }

    public void ExecuteDownButtonClick()
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
}
