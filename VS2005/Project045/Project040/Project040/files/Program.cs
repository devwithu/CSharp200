using System;
namespace Com.JungBo.Basic{
    public class Program{
        //as
        public static void Main(string[] args){
            string ss = "Hello! My name is Su-mi";
            object obj = ss;//���θ��
            //as�� Ÿ���� Ʋ���� null�� ��
            string tt = obj as string;//����Ÿ�Ը� ĳ����
            Console.WriteLine(tt);
            //�Ʒ� �ҽ��� ����
            if(obj is string){//�ν��Ͻ��� Ÿ��
                string ts = (string)obj;//ĳ����
                Console.WriteLine(ts);
            }
            object obj1 = 23;
            //int s = obj1 as int; //��ڽ��� as ���Ұ�
            int s = (int)obj1;  //��ڽ��� ĳ������
            Console.WriteLine(s);
        }
    }
}
