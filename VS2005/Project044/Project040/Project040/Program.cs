using System;
namespace Com.JungBo.Basic{
    public class Program{
        //is
        public static void Main(string[] args){
            string ss = "Hello! My name is Su-mi";
            object obj = ss;//���θ��
            object obj1 = 23; //�ڽ�
            if(obj is string){//�ν��Ͻ��� Ÿ��
                string tt = (string)obj;//ĳ����
                Console.WriteLine(tt);
            }
            if (obj1 is int){//Int32
                int tt = (int)obj1;//��ڽ�
                Console.WriteLine(tt);
            }
        }
    }
}
