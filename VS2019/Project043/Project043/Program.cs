using System;


namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {

            object obj = new object();
            object obj1 = new object();
            if (typeof(object) == obj.GetType())
            {

                Console.WriteLine("같은 타입");
            }

            Console.WriteLine(obj.ToString());//GetType()호출
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.GetHashCode());
            Console.WriteLine(obj1.GetHashCode());
            //모든 객체는 같지않다.
            if (obj.Equals(obj1))
            {
                Console.WriteLine("같은 객체");
            }
            else
            {
                Console.WriteLine("다른 객체");
            }

            Program pro = new Program();
            Console.WriteLine(pro.GetType());
            Console.WriteLine(pro.GetHashCode());
        }
    }
}