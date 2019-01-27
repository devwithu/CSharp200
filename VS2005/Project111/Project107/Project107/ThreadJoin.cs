using System;
using System.Threading; //Thread
namespace Com.JungBo.Proce {
    public class ThreadH {
        public void Print() {
            for (int i = 0; i < 3000; i++){
                Console.Write("Q");
            }
        }
        public void Go(){
            Thread tt = new Thread(new ThreadStart(Print));
            tt.Start();
            tt.Join(); //Q�� ���� ������ H ��ٸ�
            for (int i = 0; i < 3000; i++){
                Console.Write("H");
            }
        }
    }
    public class ThreadCompete {
        public void Going() {
            ThreadH h = new ThreadH();
            //�����忡 ����
            Thread t2 = new Thread(new ThreadStart(h.Go));
            //������ ���� ->CLR�� �����Ͽ� Run
            t2.Start();
            //t2.Join(); //H�� ���� �� ���� M ��ٸ�.
            //for (int i = 0; i < 3000; i++){
            //    Console.Write("M");
            //}
        }
    }
}
