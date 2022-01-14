using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaEdit.CodeCompletion;
using AvaloniaEdit.Document;
using AvaloniaEdit.Editing;
using AvaloniaEdit.Rendering;
using AvaloniaEdit.TextMate;

namespace AvaloniaEdit.Editor
{
    using Pair = KeyValuePair<int, IControl>;

    public class RichEditorView : Window
    {
        private readonly TextEditor _textEditor;
        private readonly TextMate.TextMate.Installation _textMateInstallation;
        private CompletionWindow _completionWindow;
        private OverloadInsightWindow _insightWindow;
        private readonly Button _changeThemeBtn;
        private readonly ComboBox _syntaxModeCombo;
        private readonly TextBlock _statusTextBlock;
        private readonly ElementGenerator _generator = new ElementGenerator();
        private int _currentTheme = (int)ThemeName.DarkPlus;
        private readonly Button _saveButton;

        public RichEditorView()
        {
            InitializeComponent();

            _saveButton = this.FindControl<Button>("SaveButton");
            _saveButton.Click += _saveButton_Click;

            _textEditor = this.FindControl<TextEditor>("Editor");
            _textEditor.Background = Brushes.Transparent;
            _textEditor.ShowLineNumbers = true;
            _textEditor.ContextMenu = new ContextMenu
            {
                Items = new List<MenuItem>
                {
                    new MenuItem { Header = "Copy", InputGesture = new KeyGesture(Key.C, KeyModifiers.Control) },
                    new MenuItem { Header = "Paste", InputGesture = new KeyGesture(Key.V, KeyModifiers.Control) },
                    new MenuItem { Header = "Cut", InputGesture = new KeyGesture(Key.X, KeyModifiers.Control) }
                }
            };
            _textEditor.TextArea.Background = this.Background;
            _textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
            _textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            _textEditor.TextArea.IndentationStrategy = new Indentation.CSharp.CSharpIndentationStrategy();
            _textEditor.TextArea.Caret.PositionChanged += Caret_PositionChanged;

            _changeThemeBtn = this.FindControl<Button>("changeThemeBtn");
            _changeThemeBtn.Click += _changeThemeBtn_Click;

            _textEditor.TextArea.TextView.ElementGenerators.Add(_generator);

            _textMateInstallation = _textEditor.InstallTextMate(
                (ThemeName)_currentTheme,
                null);

            var jsonLanguage = _textMateInstallation.RegistryOptions.GetLanguageByExtension(".json");

            _syntaxModeCombo = this.FindControl<ComboBox>("syntaxModeCombo");
            _syntaxModeCombo.Items = _textMateInstallation.RegistryOptions.GetAvailableLanguages();
            _syntaxModeCombo.SelectedItem = jsonLanguage;
            _syntaxModeCombo.SelectionChanged += _syntaxModeCombo_SelectionChanged;

            _textMateInstallation.SetGrammarByLanguageId(jsonLanguage.Id);

            _statusTextBlock = this.Find<TextBlock>("StatusText");

            this.AddHandler(PointerWheelChangedEvent, (o, i) =>
            {
                if (i.KeyModifiers != KeyModifiers.Control) return;
                if (i.Delta.Y > 0) _textEditor.FontSize++;
                else _textEditor.FontSize = _textEditor.FontSize > 1 ? _textEditor.FontSize - 1 : 1;
            }, RoutingStrategies.Bubble, true);

            if (!string.IsNullOrEmpty(Program.InputFile))
            {
                var content = File.ReadAllText(Program.InputFile);
                _textEditor.Document = new TextDocument(content);
                var extension = System.IO.Path.GetExtension(Program.InputFile);
                var language = _textMateInstallation.RegistryOptions.GetLanguageByExtension(extension);
                _textMateInstallation.SetGrammarByLanguageId(language.Id);
            }
        }

        private void _saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Program.InputFile))
            {
                File.WriteAllText(Program.InputFile, _textEditor.Document.Text);
            }
        }

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            var caret = _textEditor.TextArea.Caret;
            _statusTextBlock.Text = $"Line {caret.Line} Column {caret.Column}";
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _textMateInstallation.Dispose();
        }

        private void _syntaxModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var language = (Language)_syntaxModeCombo.SelectedItem;
            if (language == null)
            {
                return;
            }
            _textMateInstallation.SetGrammarByLanguageId(language.Id);
        }

        void _changeThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            _currentTheme = (_currentTheme + 1) % Enum.GetNames(typeof(ThemeName)).Length;

            _textMateInstallation.SetTheme((ThemeName)_currentTheme);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void textEditor_TextArea_TextEntering(object sender, TextInputEventArgs e)
        {
            if (e?.Text?.Length > 0 && _completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    _completionWindow.CompletionList.RequestInsertion(e);
                }
            }

            _insightWindow?.Hide();

            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        void textEditor_TextArea_TextEntered(object sender, TextInputEventArgs e)
        {
            if (e.Text == ".")
            {

                _completionWindow = new CompletionWindow(_textEditor.TextArea);
                _completionWindow.Closed += (o, args) => _completionWindow = null;

                var data = _completionWindow.CompletionList.CompletionData;
                data.Add(new MyCompletionData("Item1"));
                data.Add(new MyCompletionData("Item2"));
                data.Add(new MyCompletionData("Item3"));
                data.Add(new MyCompletionData("Item4"));
                data.Add(new MyCompletionData("Item5"));
                data.Add(new MyCompletionData("Item6"));
                data.Add(new MyCompletionData("Item7"));
                data.Add(new MyCompletionData("Item8"));
                data.Add(new MyCompletionData("Item9"));
                data.Add(new MyCompletionData("Item10"));
                data.Add(new MyCompletionData("Item11"));
                data.Add(new MyCompletionData("Item12"));
                data.Add(new MyCompletionData("Item13"));


                _completionWindow.Show();
            }
            else if (e.Text == "(")
            {
                _insightWindow = new OverloadInsightWindow(_textEditor.TextArea);
                _insightWindow.Closed += (o, args) => _insightWindow = null;

                _insightWindow.Provider = new MyOverloadProvider(new[]
                {
                    ("Method1(int, string)", "Method1 description"),
                    ("Method2(int)", "Method2 description"),
                    ("Method3(string)", "Method3 description"),
                });

                _insightWindow.Show();
            }
        }

        private class MyOverloadProvider : IOverloadProvider
        {
            private readonly IList<(string header, string content)> _items;
            private int _selectedIndex;

            public MyOverloadProvider(IList<(string header, string content)> items)
            {
                _items = items;
                SelectedIndex = 0;
            }

            public int SelectedIndex
            {
                get => _selectedIndex;
                set
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                    // ReSharper disable ExplicitCallerInfoArgument
                    OnPropertyChanged(nameof(CurrentHeader));
                    OnPropertyChanged(nameof(CurrentContent));
                    // ReSharper restore ExplicitCallerInfoArgument
                }
            }

            public int Count => _items.Count;
            public string CurrentIndexText => null;
            public object CurrentHeader => _items[SelectedIndex].header;
            public object CurrentContent => _items[SelectedIndex].content;

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class MyCompletionData : ICompletionData
        {
            public MyCompletionData(string text)
            {
                Text = text;
            }

            public IBitmap Image => null;

            public string Text { get; }

            // Use this property if you want to show a fancy UIElement in the list.
            public object Content => Text;

            public object Description => "Description for " + Text;

            public double Priority { get; } = 0;

            public void Complete(TextArea textArea, ISegment completionSegment,
                EventArgs insertionRequestEventArgs)
            {
                textArea.Document.Replace(completionSegment, Text);
            }
        }

        class ElementGenerator : VisualLineElementGenerator, IComparer<Pair>
        {
            private readonly List<Pair> _controls = new List<Pair>();

            /// <summary>
            /// Gets the first interested offset using binary search
            /// </summary>
            /// <returns>The first interested offset.</returns>
            /// <param name="startOffset">Start offset.</param>
            public override int GetFirstInterestedOffset(int startOffset)
            {
                var pos = _controls.BinarySearch(new Pair(startOffset, null), this);
                if (pos < 0)
                {
                    pos = ~pos;
                }

                if (pos < _controls.Count)
                {
                    return _controls[pos].Key;
                }
                else
                {
                    return -1;
                }
            }

            public override VisualLineElement ConstructElement(int offset)
            {
                var pos = _controls.BinarySearch(new Pair(offset, null), this);
                if (pos >= 0)
                {
                    return new InlineObjectElement(0, _controls[pos].Value);
                }
                else
                {
                    return null;
                }
            }

            int IComparer<Pair>.Compare(Pair x, Pair y)
            {
                return x.Key.CompareTo(y.Key);
            }
        }
    }
}
