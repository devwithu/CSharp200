using System;
using Com.JunBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] m = { 3, 6, 1, 8, 2, 9, 0 };
            BubbleSort.Print<int>(m);
            BubbleSort.SortByBubble<int>(m);
            BubbleSort.Print<int>(m);
            double[] n = { 3.3, 6.3, 1.3, 8.3, 2.3, 9.3, 0.3 };
            BubbleSort.Print<double>(n);
            BubbleSort.SortByBubble<double>(n);
            BubbleSort.Reverse<double>(n);
            BubbleSort.Print<double>(n);
        }
    }
}