using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    interface IData
    {
        void UstawDate(DateTime data);
        bool SprawdzDate(DateTime data);
    }
}
