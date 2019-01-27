using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){
            string s = "850323-1089234";
            JuminNumCheck jumin = new JuminNumCheck();

            int[] mm = jumin.ToInt(s);
            foreach (int var in mm){
                Console.Write("{0} ",var);
            }
            Console.WriteLine();

            Console.WriteLine((int)'0');
        }
    }
}
