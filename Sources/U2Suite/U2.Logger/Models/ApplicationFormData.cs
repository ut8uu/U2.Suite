using System;

namespace U2.Logger
{
    public class ApplicationFormData
    {
        private string _callsign = string.Empty;
        private string _operator = string.Empty;
        private string _rstSent = string.Empty;
        private string _rstRcvd = string.Empty;
        private DateTime _dateTime = DateTime.UtcNow;
        private string _comments = string.Empty;
        private string _band = string.Empty;
        private float _freqKhz = 0f;
        private string _mode = string.Empty;

        public string Callsign
        {
            get => _callsign;
            set
            {
                _callsign = value;
                Modified = true;
            }
        }

        public string Operator
        {
            get => _operator;
            set
            {
                _operator = value;
                Modified = true;
            }
        }

        public string Band
        {
            get => _band;
            set
            {
                _band = value;
                Modified = true;
            }
        }

        public float FreqKhz
        {
            get => _freqKhz;
            set
            {
                _freqKhz = value;
                Modified = true;
            }
        }

        public string Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                Modified = true;
            }
        }

        public string RstSent
        {
            get => _rstSent;
            set
            {
                _rstSent = value;
                Modified = true;
            }
        }

        public string RstRcvd
        {
            get => _rstRcvd;
            set
            {
                _rstRcvd = value;
                Modified = true;
            }
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                Modified = true;
            }
        }

        public string Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                Modified = true;
            }
        }

        public bool Modified { get; set; }

        public void Clear()
        {
            Callsign = string.Empty;
            RstSent = string.Empty;
            RstRcvd = string.Empty;
            DateTime = DateTime.UtcNow;
            Comments = string.Empty;
            Band = string.Empty;
            Mode = string.Empty;

            Modified = false;
        }

        public void Assign(ApplicationFormData data)
        {
            Callsign = data.Callsign;
            RstSent = data.RstSent;
            RstRcvd = data.RstRcvd;
            DateTime = data.DateTime;
            Comments = data.Comments;
            Mode = data.Mode;
            Band = data.Band;
        }

        public bool CanBeSaved()
        {
            return Modified
                   && !string.IsNullOrEmpty(Callsign)
                   && !string.IsNullOrEmpty(RstSent)
                   && !string.IsNullOrEmpty(RstRcvd);
        }
    }
}
