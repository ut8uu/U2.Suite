using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Logger
{
    public sealed class LogListViewModel
    {
        public LogListViewModel(LogList list)
        {
            List = list;
        }

        public LogList List { get; }
    }
}
