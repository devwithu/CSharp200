using System;
using System.Threading; //Thread
namespace Com.JungBo.Proce{
    public class ThreadH{
        public void Print(){
            for (int i = 0; i < 3000; i++){
                Console.Write("Q");
            }
        }
        public void Go(){
            Thread tt = new Thread(new ThreadStart(Print));
            tt.Start();
            for (int i = 0; i < 3000; i++){
                Console.Write("H");
                if (i == 100){
                    //1) 100/1000�� ���� ������ ����
                    Thread.Sleep(100);

                    //2) ������ �۾��� ������.
                    //Thread.CurrentThread.Abort();//H�� ������.
                }
            }
        }
    }
    public class ThreadCompete{
        public void Going() {
            ThreadH h = new ThreadH();
            //�����忡 ����
            Thread t2 = new Thread(new ThreadStart(h.Go));
            //3) �켱������ ������ �� �ִ�.
            //t2.Priority = ThreadPriority.Lowest;
            //t2.Priority = ThreadPriority.Highest;
            //������ ���� ->CLR�� �����Ͽ� Run
            t2.Start();
            for (int i = 0; i < 3000; i++){
                Console.Write("M");
            }
        }
    }
}
