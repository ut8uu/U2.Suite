using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Logger
{
    public sealed class ButtonClickedMessage
    {
        public object? Sender { get; set; }
        public ApplicationButton Button { get; set; }
    }

    public sealed class TextChangedMessage
    {
        public object? Sender { get; set; }
        public ApplicationTextBox TextBox { get; set; }
        public string NewValue { get; set; } = default!;
    }
}
