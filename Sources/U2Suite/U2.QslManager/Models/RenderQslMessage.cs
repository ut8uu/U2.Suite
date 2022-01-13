using System;
using System.Collections.Generic;
using System.Text;

namespace U2.QslManager
{
    public sealed class RenderQslMessage
    {
        public QslCardFieldsModel Fields { get; set; } = default!;
        public QslCardDesign Design { get; set; } = default!;
    }
}
