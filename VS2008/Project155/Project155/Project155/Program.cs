﻿using System;
using Com.JungBo.Logic;
namespace Project154
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int tray = 3;
            HanoiArray hanoi = new HanoiArray(tray);
            hanoi.show();
        }
    }
}
