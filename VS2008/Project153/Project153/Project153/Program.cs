using System;
using Com.JungBo.Logic;
namespace Project152
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 5;
            int r = 3;
            Console.WriteLine("{0}P{1} ={2} ",
                n, r, Recursion.Permutation(n, r));
            Console.WriteLine("{0}C{1} ={2} ",
                n, r, Recursion.Combinatiion(n, r));
        }
    }
}
