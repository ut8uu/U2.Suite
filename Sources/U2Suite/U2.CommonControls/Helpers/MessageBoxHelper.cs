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
