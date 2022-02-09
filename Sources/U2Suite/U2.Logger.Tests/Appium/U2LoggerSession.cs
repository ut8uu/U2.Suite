using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MouseButton = Avalonia.Input.MouseButton;

namespace U2.Logger.Tests
{
    public class U2LoggerSession
    {
        private MouseTestHelper _helper = new MouseTestHelper();

        private const string CallsignFieldId = "CallsignTextBox";
        private const string WipeButtonId = "WipeButton";
        private const string SaveButtonId = "SaveButton";

        protected static TextBox _callsignField;
        protected static Button _saveButton;
        protected static Button _wipeButton;

        protected static LoggerMainWindow _mainWindow;
        private static AppBuilder _appBuilder;

        public static void Setup(TestContext context)
        {
            if (_mainWindow == null)
            {
                _appBuilder = AppBuilder.Configure<App>().UsePlatformDetect();
                _appBuilder.SetupWithoutStarting();

                _mainWindow = new LoggerMainWindow();

                var inputPanel = _mainWindow.Find<TextInputPanel>("TextInputs");
                Assert.IsNotNull(inputPanel);

                _callsignField = inputPanel.Find<TextBox>(CallsignFieldId);
                Assert.IsNotNull(_callsignField);

                var buttonsPanel = _mainWindow.Find<FuncButtonsPanel>("FuncButtons");
                _saveButton = buttonsPanel.FindControl<Button>(SaveButtonId);
                Assert.IsNotNull(_saveButton);

                _wipeButton = buttonsPanel.FindControl<Button>(WipeButtonId);
                Assert.IsNotNull(_wipeButton);
            }
        }

        public static void TearDown()
        {
            if (_mainWindow != null)
            {
                _mainWindow = null;
            }
        }

        protected void ClickButton(Button button)
        {
            var pt = new Point(button.Width / 2, button.Height / 2);

            RaisePointerPressed(button, 1, MouseButton.Left, pt);

            Assert.AreEqual(_helper.Captured, button);

            RaisePointerReleased(button, MouseButton.Left, pt);

            Assert.AreEqual(_helper.Captured, null);
        }

        protected void RaisePointerPressed(Button button, int clickCount, MouseButton mouseButton, Point position)
{
            _helper.Down(button, mouseButton, position, clickCount: clickCount);
        }

        protected void RaisePointerReleased(Button button, MouseButton mouseButton, Point pt)
{
            _helper.Up(button, mouseButton, pt);
        }

        protected void RaiseKeyEvent(TextBox textBox, Key key, KeyModifiers inputModifiers)
        {
            textBox.RaiseEvent(new KeyEventArgs
            {
                RoutedEvent = InputElement.KeyDownEvent,
                KeyModifiers = inputModifiers,
                Key = key
            });
        }

        protected void RaiseTextEvent(TextBox textBox, string text)
        {
            textBox.RaiseEvent(new TextInputEventArgs
            {
                RoutedEvent = InputElement.TextInputEvent,
                Text = text
            });
        }


    }
}
