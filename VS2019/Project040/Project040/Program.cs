using System;
using Com.JungBo.Maths;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] mm = { 1, 3, 5, 6, 9 };
            int[] nn = { 2, 4, 6, 6, 0 };
            int[] kk = { 1, 2, 3, 4, 5 };
            HKArray.Clear(kk, -3);
            HKArray.PrintArray(kk);
            HKArray.SwapArray(mm, nn);
            HKArray.PrintArray(nn);
            HKArray.PrintArray(mm);
        }
    }
}