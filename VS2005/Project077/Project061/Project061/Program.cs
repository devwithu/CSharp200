using System;
using Com.JunBo.Logic;
namespace Com.JunBo.Basic {
    public class Program {
        public static void Main(string[] args){
            //OddMagicSquare odd = new OddMagicSquare(5);
            //�������̽� Ÿ������ ����Ŭ������ ������ �� �ִ�.
            IMagic odd = new OddMagicSquare(5);
            odd.Make();   //�������̽� �޼��带 ȣ��
            odd.Print();  //�������̽� �޼��带 ȣ��
        }
    }
}
