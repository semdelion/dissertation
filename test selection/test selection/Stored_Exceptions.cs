using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCPR
{
    public static class Stored_Exceptions
    {
        private static List<Exception> Exceptions = new List<Exception>();

        public static bool Empty => Exceptions.Count == 0 ? true : false;
        
        public static void Add(Exception t) => Exceptions.Add(t);

        public static void Show()
        {
           //TODO save in file
        }
    }
}
