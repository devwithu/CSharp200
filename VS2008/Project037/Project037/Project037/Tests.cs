using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Basic{
    public class Tests {

        public void Show() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Good Morning");
            Console.WriteLine(sb.ToString());
            sb.Insert(7, "~~");
            Console.WriteLine(sb.ToString());
            sb.Remove(7, 2);
            Console.WriteLine(sb.ToString());
            sb.Replace("G", "S");
            Console.WriteLine(sb.ToString());
            
        }
    }
}
