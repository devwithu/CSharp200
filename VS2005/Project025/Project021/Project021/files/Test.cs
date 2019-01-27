using System;
using System.Collections.Generic;
using System.Text;

namespace Project021
{
    class Test
    {
        public string Tosixteen(int m){
            string s = "";
            if (m == 10) { s = "A"; }
            else if (m == 11) { s = "B"; }
            else if (m == 12) { s = "C"; }
            else if (m == 13) { s = "D"; }
            else if (m == 14) { s = "E"; }
            else if (m == 15) { s = "F"; }
            else { s = m.ToString(); }
            return s;
        }//
    }
}
