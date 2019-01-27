using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            YakSu yak = new YakSu();
            yak.MakeYaksu(10);
            int[] m = yak.MakeYaksues(50);
            YakSu.Print(m);
        }
    }
}
