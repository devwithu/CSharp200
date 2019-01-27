using System;
using System.Threading; //Thread
namespace Com.JungBo.Proce3 {
 public class ThreadT {
    object oo = new object();
    static Mutex mutex = new Mutex();
    //public void Go(){
    //    lock (oo){
    //        for (int i = 0; i < 3000; i++){
    //            if (Thread.CurrentThread.Name == "T"){
    //                Console.Write("T");
    //            }
    //            else if (Thread.CurrentThread.Name == "S"){
    //                Console.Write("S");
    //            }
    //            else{
    //                Console.Write("M");
    //            }
    //        }
    //    }
    //}
    //public void Go(){
    //    lock (this){
    //        for (int i = 0; i < 3000; i++){
    //            if (Thread.CurrentThread.Name == "T"){
    //                Console.Write("T");
    //            }
    //            else if (Thread.CurrentThread.Name == "S"){
    //                Console.Write("S");
    //            }
    //            else{
    //                Console.Write("M");
    //            }
    //        }
    //    }
    //}
     public void Go(){
         mutex.WaitOne();
         for (int i = 0; i < 3000; i++){
             if (Thread.CurrentThread.Name == "T"){
                 Console.Write("T");
             }
             else if (Thread.CurrentThread.Name == "S"){
                 Console.Write("S");
             }
             else{
                 Console.Write("M");
             }
         }
         mutex.ReleaseMutex();
     }
 }
 public class ThreadCompete {
    public void Going(){
        ThreadT t = new ThreadT();
       
        //�����ڿ��� �����忡 ����
        Thread t1 = new Thread(new ThreadStart(t.Go));
        Thread t2 = new Thread(new ThreadStart(t.Go));
        Thread t3 = new Thread(new ThreadStart(t.Go));
        t1.Name = "T";
        t2.Name = "S";
        t3.Name = "M";
        //������ ���� ->CLR�� �����Ͽ� Run
        t1.Start();
        t2.Start();
        t3.Start();
    }
 }
}
