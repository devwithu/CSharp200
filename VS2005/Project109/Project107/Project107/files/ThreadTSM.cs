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
        //��ü����
        ThreadT t = new ThreadT();
        ThreadS s = new ThreadS();
        ThreadM m = new ThreadM();
        //�����忡 ����
        Thread t1 = new Thread(new ThreadStart(t.Go));
        Thread t2 = new Thread(new ThreadStart(s.Go));
        Thread t3 = new Thread(new ThreadStart(m.Go));
        //������ ���� ->CLR�� �����Ͽ� Run
        t1.Start();
        t2.Start();
        t3.Start();
    }
}
}//���ӽ����̽�
