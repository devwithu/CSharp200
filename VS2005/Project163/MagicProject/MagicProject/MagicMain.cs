using System;
namespace Com.JungBo.Logic{
   public class MagicMain{
       public static void Main(string[] args){
           Console.WriteLine("������ ���ڸ� �Է��ϼ���!!");
           int num = int.Parse(Console.ReadLine());
           //OddMagicSquare ods = new OddMagicSquare(num);
           //FourMagicSquare ods = new FourMagicSquare(num);
           SixMagicSquare ods = new SixMagicSquare(num);
           ods.Make();
           ods.Print();   //������
           Console.WriteLine(); 
           ods.Prints();   //üũ
        }
    }
}
