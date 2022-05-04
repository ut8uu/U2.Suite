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
