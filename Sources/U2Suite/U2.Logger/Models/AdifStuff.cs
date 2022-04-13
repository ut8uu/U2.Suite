using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Logger
{
    public abstract class KnownAdifTags
    {
        public const string TagBand = "BAND";
        public const string TagCall = "CALL";
        public const string TagComment = "COMMENT";
        public const string TagFreq = "FREQ";
        public const string TagMode = "MODE";
        public const string TagGridSquare = "GRIDSQUARE";
        public const string TagMySig = "MY_SIG";
        public const string TagMySigInfo = "MY_SIG_INFO";
        public const string TagOperator = "OPERATOR";
        public const string TagRstSent = "RST_SENT";
        public const string TagRstRcvd = "RST_RCVD";
        public const string TagQsoDate = "QSO_DATE";
        public const string TagTimeOn = "TIME_ON";
        public const string TagSig = "SIG";
        public const string TagSigInfo = "SIG_INFO";
        public const string TagSotaRef = "SOTA_REF";
        public const string TagStationCallsign = "STATION_CALLSIGN";
    }

    public abstract class LogFieldNames
    {
        public const string QsoId = nameof(QsoId);
        public const string DateTime = nameof(DateTime);
        public const string Call = nameof(Call);
        public const string RstSent = nameof(RstSent);
        public const string RstRcvd = nameof(RstRcvd);
        public const string Mode = nameof(Mode);
        public const string Band = nameof(Band);
        public const string Freq = nameof(Freq);
        public const string Comments = nameof(Comments);
    }
}
