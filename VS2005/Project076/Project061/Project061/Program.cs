using System;
using Com.JunBo.Logic;
namespace Com.JunBo.Basic {
    public class Program {
        public static void Main(string[] args){
            //OddMagicSquare odd = new OddMagicSquare(5);
            AbstractMagic odd = new OddMagicSquare(5);
            odd.Make();
            odd.Print();
           
        }
    }
}
