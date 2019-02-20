﻿using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] m = { 3, 6, 1, 8, 2, 9, 0 };
            NumberGen<int>.Print(m);
            NumberGen<int>.Shuffle(m);
            NumberGen<int>.Print(m);

            double[] n = { 3.3, 6.3, 1.3, 8.3, 2.3, 9.3, 0.3 };
            NumberGen<double>.Print(n);
            NumberGen<double>.Shuffle(n);
            NumberGen<double>.Print(n);
        }
    }
}