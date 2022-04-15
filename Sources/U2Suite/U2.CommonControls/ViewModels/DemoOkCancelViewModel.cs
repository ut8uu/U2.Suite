using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.CommonControls
{
    public sealed class DemoOkCancelViewModel
    {
        public string CancelButtonTitle { get; set; } = "Cancel";
        public string OkButtonTitle { get; set; } = "OK";

        public void ExecuteOkAction()
        {
            throw new NotImplementedException();
        }

        public void ExecuteCancelAction()
        {
            throw new NotImplementedException();
        }
    }
}
