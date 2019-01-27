using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Kisa{
    public class Program{
        public static void Main(string[] args){
            JungBoManager mng = new JungBoManager();
            mng.printJungBo("../../abc3031.txt");
            mng.solveOne();
            mng.solveTwo();
        }
    }
}
