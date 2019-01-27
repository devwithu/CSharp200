using System;
using Com.JungBo.Games;
namespace StructProject{
    public class Program{
        public static void Main(string[] args){
            MineConsole mc = new MineConsole();
            mc.Make();//지뢰게임을 만들고 
            //시작점이 0이 아니면 자동으로 열리지 않는다.
            mc.Chain_Bomb(5, 8); 
            mc.Print();//지뢰게임을 출력한다.
        }
    }
}
