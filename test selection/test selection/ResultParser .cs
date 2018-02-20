using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_selection
{
    class ResultParser
    {
        public List<bool> _TRUE { get; set; }
        public List<int> _SUM { get; set; }
        public ResultParser()
        {
            _TRUE = new List<bool>();
            _SUM = new List<int>();
        }
        public ResultParser(ResultParser q)
        {
            _TRUE = new List<bool>();
            _SUM = new List<int>();
            foreach (var i in q._TRUE)
                _TRUE.Add(i);
            foreach (var i in q._SUM)
                _SUM.Add(i);
        }
    }
}
