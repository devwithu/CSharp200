using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Z z1 = new Z(3, 2);
            Z z2 = new Z(3 ,- 5);
            //����Ÿ�� ���۷����� .ToString()�� �ٴ´�.
            Console.WriteLine(z1);//z1.ToString()
            Console.WriteLine(z2);
        }
    }
}
