using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace U2.Logger
{
    internal static class ControlHelper
    {
        public static ApplicationTextBox TextBoxFromString(string fieldName)
        {
            switch (fieldName)
            {
                case TextInputPanelViewModel.CallsignTextBox:
                    return ApplicationTextBox.Callsign;
                case TextInputPanelViewModel.RstRcvdTextBox:
                    return ApplicationTextBox.RstReceived;
                case TextInputPanelViewModel.RstSentTextBox:
                    return ApplicationTextBox.RstSent;
                case TextInputPanelViewModel.OperatorTextBox:
                    return ApplicationTextBox.Operator;
                case TextInputPanelViewModel.CommentsTextBox:
                    return ApplicationTextBox.Comments;
                case TextInputPanelViewModel.TimestampTextBox:
                    return ApplicationTextBox.Comments;
                case TextInputPanelViewModel.ModeTextBox:
                    return ApplicationTextBox.Mode;
                case TextInputPanelViewModel.FrequencyTextBox:
                    return ApplicationTextBox.Frequency;
                default:
                    throw new ArgumentException($"Unrecognized text box '{fieldName}.'");
            }
        }
    }
}
