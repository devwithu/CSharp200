using System;
using Com.JungBo.Games;
namespace Project084{
    public class Program{
        static void Main(string[] args){

            Block bk;  //����ü ����
            bk.bState = BombState.BOMB;
            bk.oState = OpenState.CLOSE;
            bk.down = false;

            Block ck = bk;  
            //����ü�� �⺻Ÿ���̴�.
            //�׷��Ƿ� ���� ���� �����.
            ck.bState = BombState.SEVEN;
            Console.WriteLine(bk.bState);
            Console.WriteLine(ck.bState);

            Block[] b = new Block[3];
            b[0] = ck;//BombState.SEVEN;
            b[1] = ck; //BombState.SEVEN;
            b[2] = ck; //BombState.SEVEN;
            ck.bState = BombState.THREE;
            //���� ���� �����̹Ƿ� ck�� �����ص�
            //����� ������ ������� �ʴ´�.
            Console.WriteLine(b[1].bState);
            //��ü ������ �����ϴ�. �׷��� �⺻Ÿ���̴�.
            Block bb = new Block();
            bb.bState = BombState.SEVEN;

        }
    }
}
