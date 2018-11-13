using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCPR
{
    static class Level_of_expression
    {
        const double not_expressed = 0.5;
        const double weakly_expressed = 0.7;
        const double reduced_expressed = 0.9;

        const string weakly_expressed_string = "Слабая степень выраженности таких черт, как";
        const string reduced_expressed_string = "Пониженная степень выраженности таких черт, как";

        public static bool Return_text_about_of_expression(double measure, out string Manifestation)
        {
            if (measure >= not_expressed && measure < weakly_expressed)
            {
                Manifestation= "Слабая степень выраженности таких черт, как:";
                return true;
            }
            if (measure >= weakly_expressed && measure < reduced_expressed)
            {
                Manifestation = "Пониженная степень выраженности таких черт, как:";
                return true;
            }
            if (measure >= reduced_expressed)
            {
                Manifestation = "";
                return true;
            }
            Manifestation = "";
            return false;
        }
    }
}
