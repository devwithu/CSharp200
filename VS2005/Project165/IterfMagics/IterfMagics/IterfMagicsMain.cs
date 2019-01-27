using System;
namespace Com.JungBo.Logic{
    public class IterfMagicsMain{
        public static void Main(string[] args){
            //AbstractMagic im=
            IMagic im =
                //new OddMagicSquare(5);
                //new FourMagicSquare(8);
                new SixMagicSquare(6);
            im.Make();
            im.Print();
        }
    }
}
