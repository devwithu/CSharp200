using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){
            string s = "8.5-03-23-1.0-89-.234";
            JuminNumCheck jumin = new JuminNumCheck();
            jumin.ToInt2(s);
            jumin.ToInt3(s);
        }
    }
}
