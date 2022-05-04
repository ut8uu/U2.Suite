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

namespace U2.QslManager
{
    public class QslCardFieldsModel
    {
        public string Callsign { get; set; } = "";
        public string CqZone { get; set; } = "";
        public string ItuZone { get; set; } = "";
        public string Grid { get; set; } = "";
        public string Qth { get; set; } = "";
        public string OperatorName { get; set; } = "";
        public string Text1 { get; set; } = "";
        public string Text2 { get; set; } = "";
        public string BackgroundImage { get; set; } = "";
        public string Image1 { get; set; } = "";
        public string Image2 { get; set; } = "";
        public string Image3 { get; set; } = "";
    }
}
