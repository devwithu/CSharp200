using System;
using Com.JungBo.Games;
namespace StructProject{
    public class Program{
        public static void Main(string[] args){
            MineConsole mc = new MineConsole();
            mc.Make();//지뢰게임을 만들고 
            mc.Print();//지뢰게임을 출력한다.
        }
    }
}
