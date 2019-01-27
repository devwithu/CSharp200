using System;
using Com.JunBo.Logic;
namespace Com.JunBo.Basic {
    public class Program {
        public static void Main(string[] args){
            int num = 5;//5x5 ¸¶¹æÁø
            OddMagicSquare odd = new OddMagicSquare(num);
            odd.Make();
            odd.Print();
        }
    }
}
