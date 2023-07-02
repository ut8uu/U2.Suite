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
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LoggerMainWindow : Window
    {
        private TextInputPanel _textInputs = default!;
        private FuncButtonsPanel _funcButtonsPanel;
        internal ApplicationTextBox? _selectedTextBox = null;
        private MainWindowViewModel _loggerViewModel;

        public LoggerMainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _loggerViewModel = new MainWindowViewModel();
            _loggerViewModel.Owner = this;
            this.DataContext = _loggerViewModel;

            _textInputs = this.FindControl<TextInputPanel>("TextInputs");
            _textInputs.Owner = this;
            _textInputs.DataContext = new TextInputPanelViewModel();

            _funcButtonsPanel = this.FindControl<FuncButtonsPanel>("FuncButtons");
            _funcButtonsPanel.Owner = this;
            _funcButtonsPanel.DataContext = new FuncButtonsPanelViewModel();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Space)
            {
                Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SpaceButton));
                e.Handled = true;
                return;
            }
        }

        protected override void OnGotFocus(GotFocusEventArgs e)
        {
            base.OnGotFocus(e);

            if (e.Source is TextBox tb)
            {
                _selectedTextBox = ControlHelper.TextBoxFromString(tb.Name ?? string.Empty);
            }
            else
            {
                _selectedTextBox = null;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            _selectedTextBox = null;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
