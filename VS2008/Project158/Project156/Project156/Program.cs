using System;
using Com.JungBo.Sorts;
namespace Project154
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] a = { 5, 6, 3, 7, 4, 8, 2, 9 };
            Quick.QuickSort(a);
            SortUtil.Print(a);
            Console.WriteLine("------------------");
            double[] b = { 5, 6, 3, 7, 4, 8, 2, 9 };
            Quick.QuickSort<double>(b);
            SortUtil.Print<double>(b);
        }
    }
}
