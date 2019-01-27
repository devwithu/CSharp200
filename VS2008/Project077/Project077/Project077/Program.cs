using System;
using Com.JunBo.Logic;
namespace Com.JunBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //OddMagicSquare odd = new OddMagicSquare(5);
            //인터페이스 타입으로 구현클래스를 생성할 수 있다.
            IMagic odd = new OddMagicSquare(5);
            odd.Make();   //인터페이스 메서드를 호출
            odd.Print();  //인터페이스 메서드를 호출
        }
    }
}
