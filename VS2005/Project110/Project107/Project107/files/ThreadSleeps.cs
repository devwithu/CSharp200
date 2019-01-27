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
                    //1) 100/1000초 동안 쓰레드 정지
                    Thread.Sleep(100);

                    //2) 쓰레드 작업을 끝낸다.
                    //Thread.CurrentThread.Abort();//H를 끝낸다.
                }
            }
        }
    }
    public class ThreadCompete{
        public void Going() {
            ThreadH h = new ThreadH();
            //쓰레드에 위임
            Thread t2 = new Thread(new ThreadStart(h.Go));
            //3) 우선순위를 결정할 수 있다.
            //t2.Priority = ThreadPriority.Highest;
            //쓰레드 레디 ->CLR의 관리하에 Run
            t2.Start();
            for (int i = 0; i < 3000; i++){
                Console.Write("M");
            }
        }
    }
}
