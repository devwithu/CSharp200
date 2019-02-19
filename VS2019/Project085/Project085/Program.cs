using System;
using Com.JungBo.Games;

namespace Com.JungBo.Basic
{
    //델리게이트 선언
    public delegate void Attack();
    public delegate void DoIt(String str);

    public class Program
    {

        public static void Main(string[] args)
        {
            MineConsole mc = new MineConsole();
            mc.Make();//지뢰게임을 만들고 
            mc.Print();//지뢰게임을 출력한다.
        }
    }
}