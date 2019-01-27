using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            BitConverts yak = new BitConverts();
            yak.MakeTo2(67);
            yak.MakeTo2(-67);
            yak.MakeTo2(123);
            yak.MakeTo2(-123);

            int[] m = yak.MakeTo2es(67);
            BitConverts.Print(m);
        }
    }
}
