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
        ThreadT m = new ThreadT();
        ThreadS t = new ThreadS();
        ThreadM s = new ThreadM();
        //�����忡 ����
        Thread t1 = new Thread(new ThreadStart(m.Go));
        Thread t2 = new Thread(new ThreadStart(t.Go));
        Thread t3 = new Thread(new ThreadStart(s.Go));
        //������ ���� ->CLR�� �����Ͽ� Run
        t1.Start();
        t2.Start();
        t3.Start();
    }
}
}//���ӽ����̽�
