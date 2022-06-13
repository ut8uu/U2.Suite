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

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace U2.MultiRig.Emulators.Gui;

public partial class FrequencyIndicator : UserControl
{
    private readonly FrequencyIndicatorViewModel _viewModel;
    private long _frequency = 1810000;

    public FrequencyIndicator()
    {
        InitializeComponent();

        _viewModel = new FrequencyIndicatorViewModel();
        DataContext = _viewModel;
        _viewModel.Owner = this;
    }

    public static readonly DirectProperty<FrequencyIndicator, long> FrequencyProperty =
        AvaloniaProperty.RegisterDirect<FrequencyIndicator, long>(nameof(Frequency),
            getter: o => o.Frequency, 
            setter: (o, v) => o.Frequency = v,
            unsetValue:0,
            defaultBindingMode: BindingMode.TwoWay,
            false
            );

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public long Frequency
    {
        get => _frequency;
        set
        {
            _frequency = value;
            _viewModel.Frequency = value;
        }
    }
}
