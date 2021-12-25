using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;

namespace U2.QslManager
{
    public class QslCardFieldsViewModel : INotifyPropertyChanged
    {
        private string? _callsign;
        private string? _cqZone;
        private string? _ituZone;
        private string? _grid;
        private string? _qth;
        private string? _operatorName;
        private string? _text1;
        private string? _text2;

        public QslCardFieldsViewModel(QslCardFieldsModel qslCardFields)
        {
            ClearFieldsCommand = ReactiveCommand.Create(ClearFields);
            PreviewCardCommand = ReactiveCommand.Create(PreviewCard);

            QslCardFields = qslCardFields;
            Callsign = qslCardFields.Callsign;
            CqZone = qslCardFields.CqZone;
            ItuZone = qslCardFields.ItuZone;
            Grid = qslCardFields.Grid;
            Qth = qslCardFields.Qth;
            OperatorName = qslCardFields.OperatorName;
            Text1 = qslCardFields.Text1;
            Text2 = qslCardFields.Text2;
        }

        public string? Callsign
        {
            get => _callsign;
            set
            {
                _callsign = value;
                OnPropertyChanged();
            }
        }

        internal void Clear()
        {
            Callsign = string.Empty;
            OperatorName = string.Empty;
            CqZone = string.Empty;
            ItuZone = string.Empty;
            Grid = string.Empty;
            Qth = string.Empty;
            Text1 = string.Empty;
            Text2 = string.Empty;
        }

        public string? CqZone
        {
            get => _cqZone;
            set
            {
                _cqZone = value;
                OnPropertyChanged();
            }
        }
        public string? ItuZone
        {
            get => _ituZone;
            set
            {
                _ituZone = value;
                OnPropertyChanged();
            }
        }
        public string? Grid
        {
            get => _grid;
            set
            {
                _grid = value;
                OnPropertyChanged();
            }
        }
        public string? Qth
        {
            get => _qth;
            set
            {
                _qth = value;
                OnPropertyChanged();
            }
        }
        public string? OperatorName
        {
            get => _operatorName;
            set
            {
                _operatorName = value;
                OnPropertyChanged();
            }
        }
        public string? Text1
        {
            get => _text1;
            set
            {
                _text1 = value;
                OnPropertyChanged();
            }
        }
        public string? Text2
        {
            get => _text2;
            set
            {
                _text2 = value;
                OnPropertyChanged();
            }
        }

        public QslCardFieldsModel QslCardFields { get; }
        public ReactiveCommand<Unit, Unit> ClearFieldsCommand { get; }
        public ReactiveCommand<Unit, Unit> PreviewCardCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearFields()
        {
            Clear();
        }

        private void PreviewCard()
        {

        }
    }
}
