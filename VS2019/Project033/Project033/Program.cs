﻿using System;
using Com.JungBo.Logics;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("개수변경---------");
            int a = 3; int b = 5; int c = 2;
            Bubble.Print(a, b, c);
            Bubble.DescSort(a, b, c);
            Bubble.Print(a, b, c);
            int[] mm = { 6, 3, 8, 9, 2, 1, 4, 7, 5 };  //배열에도 사용가능
            Console.WriteLine("정렬전---------");
            Bubble.Print(mm);
            Console.WriteLine("정렬후---------");
            Bubble.DescSort(mm);

        }
    }
}