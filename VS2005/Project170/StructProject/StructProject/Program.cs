using System;
using Com.JungBo.Games;
namespace StructProject{
    public class Program{
        public static void Main(string[] args){
            MineConsole mc = new MineConsole();
            mc.Make();//���ڰ����� ����� 
            //�������� 0�� �ƴϸ� �ڵ����� ������ �ʴ´�.
            mc.Chain_Bomb(5, 8); 
            mc.Print();//���ڰ����� ����Ѵ�.
        }
    }
}
