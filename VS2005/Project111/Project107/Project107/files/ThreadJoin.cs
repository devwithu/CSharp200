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
            tt.Join(); //Q를 끝날 때까지 H 기다림
            for (int i = 0; i < 3000; i++){
                Console.Write("H");
            }
        }
    }
    public class ThreadCompete {
        public void Going() {
            ThreadH h = new ThreadH();
            //쓰레드에 위임
            Thread t2 = new Thread(new ThreadStart(h.Go));
            //쓰레드 레디 ->CLR의 관리하에 Run
            t2.Start();
            //t2.Join(); //H를 끝날 때 까지 M 기다림.
            //for (int i = 0; i < 3000; i++){
            //    Console.Write("M");
            //}
        }
    }
}
