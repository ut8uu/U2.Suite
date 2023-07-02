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

using U2.Core;
using U2.Resources;

namespace U2.Suite
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainWindow _window;

        public string Greeting => "Welcome to Avalonia!";
        public string QslManagerTitle => "QSL Manager";

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(MainWindow window)
        {
            this._window = window;
        }

        private void LaunchQslManager()
        {
            Launcher.Launch(ApplicationNames.GetQslManagerAppName(), string.Empty);
        }

        public void ShowAboutWindow()
        {
            var window = new AboutFormView();
            window.ShowDialog(_window);
        }

        public void ShowLicenseWindow()
        {
            var window = new LicenseFormView();
            window.ShowDialog(_window);
        }

        public void ShowContributorsWindow()
        {
            var window = new ContributorsWindow();
            window.ShowDialog(_window);
        }

        public void LaunchLibrary()
        {
            Launcher.Launch(ApplicationNames.GetLibraryAppName(), string.Empty);
        }

        public void LaunchLogger()
        {
            Launcher.Launch(ApplicationNames.GetLoggerAppName(), string.Empty);
        }
    }
}
