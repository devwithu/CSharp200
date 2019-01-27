using System;
using System.Threading; //Thread
namespace Com.JungBo.Proce {
public class ThreadT {
    public void Go(){
        for (int i = 0; i < 3000; i++){
            Console.Write("T");
        }
    }
}//
public class ThreadS {
    public void Go(){
        for (int i = 0; i < 3000; i++){
            Console.Write("S");
        }
    }
}//
public class ThreadM {
    public void Go(){
        for (int i = 0; i < 3000; i++){
            Console.Write("M");
        }
    }
}//
public class ThreadCompete {
    public void Going() {
        //개체생성
        ThreadT t = new ThreadT();
        ThreadS s = new ThreadS();
        ThreadM m = new ThreadM();
        //쓰레드에 위임
        Thread t1 = new Thread(new ThreadStart(t.Go));
        Thread t2 = new Thread(new ThreadStart(s.Go));
        Thread t3 = new Thread(new ThreadStart(m.Go));
        //쓰레드 레디 ->CLR의 관리하여 Run
        t1.Start();
        t2.Start();
        t3.Start();
    }
}
}//네임스페이스
