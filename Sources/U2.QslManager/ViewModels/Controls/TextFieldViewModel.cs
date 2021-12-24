using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace U2.QslManager
{
    public class TextFieldViewModel : INotifyPropertyChanged
    {
        private string? _name;
        private string? _text;
        private string? _title;
        private string? _fontFamily;
        private string? _fontColor;
        private int _fontSize;
        private int _angle;
        private bool _bold;
        private bool _italic;
        private int _maxWidth;
        private bool _visible;

        /// <summary>
        /// A name of the control
        /// </summary>
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// A text to be displayed
        /// </summary>
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A text to be displayed
        /// </summary>
        public string? Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A name of the used font
        /// </summary>
        public string? FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A color of the text
        /// </summary>
        public string? FontColor
        {
            get => _fontColor;
            set
            {
                _fontColor = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A positive size of the font
        /// </summary>
        public int FontSize
        {
            get => _fontSize; set
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A non-negative value indicating the direction of the text.
        /// 0 - up, 90 - right, 180 - down, 270 - left, upside down
        /// 45 - up-right, and so on
        /// </summary>
        public int Angle
        {
            get => _angle; 
            set
            {
                _angle = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Indicates whether the text should be bold
        /// </summary>
        public bool Bold
        {
            get => _bold; 
            set
            {
                _bold = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Indicates whether the text should be italic
        /// </summary>
        public bool Italic
        {
            get => _italic; 
            set
            {
                _italic = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// A maximal width of the displayed text
        /// </summary>
        public int MaxWidth
        {
            get => _maxWidth; 
            set
            {
                _maxWidth = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Indicates whether the field should be rendered
        /// </summary>
        public bool Visible
        {
            get => _visible; 
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
