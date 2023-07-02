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

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerControls : UserControl
    {
        private readonly QslCardFieldsViewModel _viewModel;

        public QslDesignerControls()
        {
            InitializeComponent();

            QslCardFieldsModel qslCardFields = new QslCardFieldsModel
            {
                Callsign = "UT8UU",
                CqZone = "16",
                Grid = "KO50gk",
                ItuZone = "29",
                OperatorName = "Sergey Usmanov",
                Qth = "Kyiv",
                Text1 = string.Empty,
                Text2 = string.Empty,
                BackgroundImage = @"Images/kyiv.jpg"
            };
            _viewModel = new QslCardFieldsViewModel(qslCardFields);
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void SetOwner(Window owner)
        {
            _viewModel.SetOwner(owner);
        }
    }
}
