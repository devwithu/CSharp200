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
            zlist.Add(new Z(8, 6));
            zlist.PrintZList();

            bool isC = zlist.Contains(new Z(5, 7));
            Console.WriteLine(isC);

            zlist.Remove(new Z(5, 7));
            zlist.RemoveAt(2);
            zlist.PrintZList();

            Console.WriteLine("--------------------");
            //indexer 이용
            Z z3 = zlist[3];
            Console.WriteLine(z3);
            zlist[4] = new Z(4, -8);
            Console.WriteLine("--------------------");
            zlist.PrintZList();
            //예외처리---------------------------
            try
            {
                Z zz = zlist[7];//가져오지 못한다.
                Console.WriteLine(zz);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                zlist[7] = new Z(-5, -8); //넣지 못한다.
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            zlist.PrintZList();
        }
    }
}
