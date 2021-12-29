using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return elements.FirstOrDefault(e => e.ElementName == name);
        }
    }
}
