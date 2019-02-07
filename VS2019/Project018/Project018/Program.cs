using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.JungBo.Logic;//using 필수

namespace Com.Jungbo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int iNum = 10000;
            Console.WriteLine("{0}까지의 완전수: ", iNum);
            UclidMath.PrintPerfect(iNum);
        }
    }
}
