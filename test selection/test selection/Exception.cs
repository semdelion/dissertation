using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selection
{
    class ExceptionRES
    {
        public string mes = "";
        public ExceptionRES()
        {
            mes  = "Ошибка: ";
        }
        public ExceptionRES(string t)
        {
            mes = "Ошибка: " + t;
        }

    }
}
