using System;
namespace Com.JungBo.Basic{
    public class Program{
        //object
        public static void Main(string[] args){

            object obj = new object();
            object obj1 = new object();
            if (typeof(object) == obj.GetType()){

                Console.WriteLine("���� Ÿ��");
            }

            Console.WriteLine(obj.ToString());//GetType()ȣ��
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.GetHashCode());
            Console.WriteLine(obj1.GetHashCode());
            //��� ��ü�� �����ʴ�.
            if (obj.Equals(obj1)){
                Console.WriteLine("���� ��ü");
            }
            else {
                Console.WriteLine("�ٸ� ��ü");
            }

            Program pro = new Program();
            Console.WriteLine(pro.GetType());
            Console.WriteLine(pro.GetHashCode());
        }
    }
}
