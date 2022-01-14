using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace U2.Logger
{
    public sealed class TextInputPanelViewModel : ViewModelBase
    {

        public string CallsignInputTitle { get; set; } = "Callsign";
        public string RstSentInputTitle { get; set; } = "Rst Sent";
        public string RstRvcdInputTitle { get; set; } = "Rst Rvcd";
        public string OperatorInputTitle { get; set; } = "Operator";
        public string CommentsInputTitle { get; set; } = "Comments";


        public Window Owner { get; set; } = default!;
        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstRvcd { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;

    }
}
