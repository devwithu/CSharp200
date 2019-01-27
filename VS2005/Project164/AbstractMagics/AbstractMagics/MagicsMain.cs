using System;
namespace Com.JungBo.Logic{
    public class MagicsMain{
        public static void Main(string[] args){
            AbstractMagic ods=
            //OddMagicSquare ods = new OddMagicSquare(3);
           // FourMagicSquare ods = new FourMagicSquare(4);
           // SixMagicSquare ods = new SixMagicSquare(10);
          //new FourMagicSquare(4);
          //new OddMagicSquare(3);
          new SixMagicSquare(10);
            ods.Make();
            ods.Prints();

        }
    }
}
