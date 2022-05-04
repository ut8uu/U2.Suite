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

namespace U2.Logger.ViewModels
{
    internal class WindowViewModelBase : ViewModelBase
    {
        private Window _owner = default!;

        public string WindowTitle { get; set; } = default!;

        public string CancelButtonTitle { get; set; } = Resources.Cancel;
        public string OkButtonTitle { get; set; } = Resources.OK;

        public Window Owner
        {
            get => _owner; 
            set
            {
                SetOwner(value);
            }
        }

        protected virtual void SetOwner(Window owner)
        {
            _owner = owner;
        }

        public virtual void ExecuteOkAction()
        {
            throw new NotImplementedException();
        }

        public virtual void ExecuteCancelAction()
        {
            throw new NotImplementedException();
        }
    }
}
