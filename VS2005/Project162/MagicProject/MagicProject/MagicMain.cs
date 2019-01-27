using System;
namespace Com.JungBo.Logic{
   public class MagicMain{
       public static void Main(string[] args){
           Console.WriteLine("마방진 숫자를 입력하세요!!");
           int num = int.Parse(Console.ReadLine());
           //OddMagicSquare ods = new OddMagicSquare(num);
           FourMagicSquare ods = new FourMagicSquare(num);
           //SixMagicSquare ods = new SixMagicSquare(num);
           ods.Make();
           ods.Print();   //마방진
           Console.WriteLine(); 
           ods.Prints();   //체크
        }
    }
}
