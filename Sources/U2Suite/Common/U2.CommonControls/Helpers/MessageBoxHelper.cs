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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace U2.CommonControls
{
    public static class MessageBoxHelper
    {
        public static void ShowMessageBox(string title, string content)
        {
            var @params = new MessageBox.Avalonia.DTO.MessageBoxCustomParams
            {
                CanResize = false,
                ShowInCenter = true,
                Topmost = true,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ContentTitle = title,
                ContentMessage = content,
                SizeToContent = SizeToContent.WidthAndHeight,
                ButtonDefinitions = new[]
                    {
                        new MessageBox.Avalonia.Models.ButtonDefinition
                        {
                            Name = "OK",
                            IsCancel = false,
                            IsDefault = true,
                        }
                    }
            };

            var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxCustomWindow(@params);
            messageBox.Show();
        }
    }
}
