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

using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogContentWindow : Window
    {
        private LogContentViewModel _viewModel = default!;

        private DataGrid _mainGrid;

        public LogContentWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new LogContentViewModel();
            _viewModel.Owner = this;
            DataContext = _viewModel;

            _mainGrid = (DataGrid)this.Find<DataGrid>("MainGrid");
            _mainGrid.SelectionChanged += _mainGrid_SelectionChanged;
        }

        private void _mainGrid_SelectionChanged(object? sender, 
            SelectionChangedEventArgs e)
        {
            _viewModel.SelectItems(e.AddedItems as List<object>);
            _viewModel.DeselectItems(e.RemovedItems as List<LogRecordDbo>);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
