using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Logger
{
    public sealed class ButtonClickedMessage
    {
        public ButtonClickedMessage(object sender, ApplicationButton button)
        {
            Sender = sender;
            Button = button;
        }

        public object? Sender { get; set; }
        public ApplicationButton Button { get; set; }
    }
}
