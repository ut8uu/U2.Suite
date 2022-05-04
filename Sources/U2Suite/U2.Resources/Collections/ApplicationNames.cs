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

namespace U2.Resources
{
    public static class ApplicationNames
    {
        public const string SuiteWin = "U2.Suite.exe";
        public const string SuiteOsx = "U2.Suite";
        public const string SuiteLInux = "U2.Suite";

        public const string QslManagerWin = "U2.QslManager.exe";
        public const string QslManagerOsx = "U2.QslManager";
        public const string QslManagerLinux = "U2.QslManager";

        public const string LibraryWin = "U2.Library.exe";
        public const string LibraryOsx = "U2.Library";
        public const string LibraryLinux = "U2.Library";

        public const string LoggerWin = "U2.Logger.exe";
        public const string LoggerOsx = "U2.Logger";
        public const string LoggerLinux = "U2.Logger";

        public const string RichEditorWin = "AvaloniaEdit.Editor.exe";
        public const string RichEditorOsx = "AvaloniaEdit.Editor";
        public const string RichEditorLinux = "AvaloniaEdit.Editor";

        public static string ChooseByOS(string win, string osx, string linux)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                    // returned by SilverLight. .NET Core returns Unix for this OS
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32S:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32Windows:
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32NT:
                    return win;
                case PlatformID.WinCE:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Unix:
                    // MacOS falls here
                    return osx;
                case PlatformID.Xbox:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetSuiteAppName()
        {
            return ChooseByOS(SuiteWin, SuiteOsx, SuiteLInux);
        }

        public static string GetQslManagerAppName()
        {
            return ChooseByOS(QslManagerWin, QslManagerOsx, QslManagerLinux);
        }

        public static string GetEditorAppName()
        {
            return ChooseByOS(RichEditorWin, RichEditorOsx, RichEditorLinux);
        }

        public static string GetLibraryAppName()
        {
            return ChooseByOS(LibraryWin, LibraryOsx, LibraryLinux);
        }

        public static string GetLoggerAppName()
        {
            return ChooseByOS(LoggerWin, LoggerOsx, LoggerLinux);
        }
    }
}
