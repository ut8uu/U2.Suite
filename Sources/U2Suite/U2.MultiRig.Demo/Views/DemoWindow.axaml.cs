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

using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using U2.MultiRig.Demo.ViewModels;

namespace U2.MultiRig.Demo.Views
{
    [DoNotNotify]
    public sealed class DemoWindow : Window
    {
        private readonly DemoViewModel _model;

        public DemoWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _model = new DemoViewModel
            {
                Owner = this
            };
            this.DataContext = _model;

            this.Closing += OnClosing;
        }

        private void OnClosing(object? sender, CancelEventArgs e)
        {
            _model.Dispose();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
