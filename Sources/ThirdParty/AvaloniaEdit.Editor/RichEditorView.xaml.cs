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
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Rendering;
using AvaloniaEdit.TextMate;
using AvaloniaEdit.TextMate.Grammars;

namespace AvaloniaEdit.Editor
{
    using Pair = KeyValuePair<int, IControl>;

    public class RichEditorView : Window
    {
        private readonly TextEditor _textEditor;
        private CompletionWindow _completionWindow;
        private OverloadInsightWindow _insightWindow;
        private readonly TextBlock _statusTextBlock;
        private readonly ElementGenerator _generator = new ElementGenerator();
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
                    new() { Header = "Copy", InputGesture = new KeyGesture(Key.C, KeyModifiers.Control) },
                    new() { Header = "Paste", InputGesture = new KeyGesture(Key.V, KeyModifiers.Control) },
                    new() { Header = "Cut", InputGesture = new KeyGesture(Key.X, KeyModifiers.Control) }
                }
            };
            _textEditor.TextArea.Background = this.Background;
            _textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
            _textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            _textEditor.TextArea.IndentationStrategy = new Indentation.CSharp.CSharpIndentationStrategy();
            _textEditor.TextArea.Caret.PositionChanged += Caret_PositionChanged;

            _textEditor.TextArea.TextView.ElementGenerators.Add(_generator);

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
            }

            _textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("JSON");
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

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void textEditor_TextArea_TextEntering(object sender, TextInputEventArgs e)
        {
            if (e?.Text?.Length > 0 && _completionWindow != null && !char.IsLetterOrDigit(e.Text[0]))
            {
                // Whenever a non-letter is typed while the completion window is open,
                // insert the currently selected element.
                _completionWindow.CompletionList.RequestInsertion(e);
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
