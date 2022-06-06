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
using Avalonia.Markup.Xaml;
using AvaloniaEdit.Utils;
using PropertyChanged;
using U2.MultiRig.ViewModels;

namespace U2.MultiRig
{
    [DoNotNotify]
    public partial class MultiRigWindow : Window
    {
        private MultiRigWindowViewModel _model;

        public MultiRigWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _model = new MultiRigWindowViewModel
            {
                Owner = this,
                SelectedRigIndex = 0,
            };
            DataContext = _model;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
