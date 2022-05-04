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
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

namespace U2.CommonControls
{
    [PropertyChanged.DoNotNotify]
    public partial class TextBoxWithTitle : UserControl
    {
        public TextBoxWithTitle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        #region Title DP

        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(Title),
                defaultBindingMode: BindingMode.TwoWay);

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion

        #region Value DP

        public static readonly StyledProperty<string> ValueProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(Value));

        public string Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion

        #region ToolTip DP

        public static readonly StyledProperty<string> ToolTipProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(ToolTip));

        public string ToolTip
        {
            get => GetValue(ToolTipProperty);
            set => SetValue(ToolTipProperty, value);
        }

        #endregion
    }
}
