using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ZLists zlist = new ZLists();

            zlist.Add(new Z(1, 2));
            zlist.Add(new Z(3, 3));
            zlist.Add(new Z(5, 7));
            zlist.Add(new Z(9, 8));
            zlist.Add(new Z(2, 6));

            zlist.PrintZList();

            bool isC = zlist.Contains(new Z(5, 7));
            Console.WriteLine(isC);

            zlist.Remove(new Z(5, 7));
            zlist.PrintZList();

            Console.WriteLine("--------------------");
            //indexer 이용
            Z z3 = zlist[3];
            Console.WriteLine(z3);
            zlist[4] = new Z(4, -8);
            Console.WriteLine("--------------------");
            zlist.PrintZList();
            zlist[4] = new Z(-5, -8);
            Console.WriteLine("--------------------");
            zlist.PrintZList();
        }
    }
}
