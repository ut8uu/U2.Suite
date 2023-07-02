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
using System.Linq;

namespace U2.QslManager.Helpers
{
    public static class Extensions
    {
        public static QslCardElement GetByName(this QslCardElement[]? elements, string name)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            var element = elements.FirstOrDefault(e => name.Equals(e?.ElementName, StringComparison.InvariantCultureIgnoreCase));
            if (element == null)
            {
                throw new ArgumentException($"Element {name} not found.", nameof(name));
            }

            return element;
        }
    }
}
