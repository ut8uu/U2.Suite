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
