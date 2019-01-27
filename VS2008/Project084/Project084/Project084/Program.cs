using System;
using Com.JungBo.Games;
namespace Project084
{
    public class Program
    {
        static void Main(string[] args)
        {
            Block bk;  //구조체 선언
            bk.bState = BombState.BOMB;
            bk.oState = OpenState.CLOSE;
            bk.down = false;

            Block ck = bk;
            //구조체는 기본타입이다.
            //그러므로 값에 의한 복사다.
            ck.bState = BombState.SEVEN;
            Console.WriteLine(bk.bState);
            Console.WriteLine(ck.bState);

            Block[] b = new Block[3];
            b[0] = ck;//BombState.SEVEN;
            b[1] = ck; //BombState.SEVEN;
            b[2] = ck; //BombState.SEVEN;
            ck.bState = BombState.THREE;
            //값에 의한 대입이므로 ck를 변경해도
            //복사된 값들이 변경되지 않는다.
            Console.WriteLine(b[1].bState);
            //개체 생성도 가능하다. 그러나 기본타입이다.
            Block bb = new Block();
            bb.bState = BombState.SEVEN;

        }
    }
}
