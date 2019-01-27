using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Basic{
    //public class Asterisk{
    //    //다이아모든형
    //    public static void ShowDiamond(int n){
    //        for (int i = 0; i < n; i++){
    //            for (int j = 0; j < Math.Abs(i - Math.Abs(n / 2)); j++){
    //                Console.Write(" ");
    //            }
    //            for (int k = 0; k < n - 2 * Math.Abs(i - Math.Abs(n / 2)); k++){
    //                Console.Write("X");
    //            }
    //            Console.WriteLine();
    //        }
    //    }
        
    //    public static void ShowReverseDiamond(int n){
    //        for (int i = 0; i < n; i++){
    //            for (int j = 0; j < Math.Abs(i - Math.Abs(n / 2)); j++){
    //                Console.Write("X");
    //            }
    //            for (int k = 0; k < n - 2 * Math.Abs(i - Math.Abs(n / 2)); k++){
    //                Console.Write(" ");
    //            }
    //            for (int j = 0; j < Math.Abs(i - Math.Abs(n / 2)); j++){
    //                Console.Write("X");
    //            }
    //            Console.WriteLine();
    //        }
    //    }

    //    public static void ShowStageDown(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int j = 0; j <= i; j++)
    //            {
    //                Console.Write("X");
    //            }//in for
    //            Console.WriteLine();
    //        }//out for
    //    }//

    //    public static void ShowStageTree(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int k = 0; k < n - i - 1; k++)
    //            {
    //                Console.Write(" ");
    //            }//in for
    //            for (int j = 0; j < 2 * i + 1; j++)
    //            {
    //                Console.Write("X");
    //            }//in for

    //            Console.WriteLine();
    //        }//out for
    //    }//
    //    public static void ShowStageV(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int k = 0; k < n - i - 1; k++)
    //            {
    //                Console.Write("X");
    //            }//in for
    //            for (int j = 0; j < 2 * i + 1; j++)
    //            {
    //                Console.Write(" ");
    //            }//in for
    //            for (int k = 0; k < n - i - 1; k++)
    //            {
    //                Console.Write("X");
    //            }//in for
    //            Console.WriteLine();
    //        }//out for
    //    }//
    //    //-----------------------------------------
    //    public static void ShowStageUp(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int k = 0; k < n - i - 1; k++)
    //            {
    //                Console.Write(" ");
    //            }//in for
    //            for (int j = 0; j <= i; j++)
    //            {
    //                Console.Write("X");
    //            }//in for

    //            Console.WriteLine();
    //        }//out for
    //    }//
    //    public static void ShowDecrease(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int k = 0; k < i; k++)
    //            {
    //                Console.Write(" ");
    //            }//in for
    //            for (int j = 1; j < 2 * (n - i); j++)
    //            {
    //                Console.Write("X");
    //            }//in for

    //            Console.WriteLine();
    //        }//out for
    //    }//
    //    public static void ShowStageRV(int n)
    //    {
    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int k = 0; k < i; k++)
    //            {
    //                Console.Write("X");
    //            }//in for
    //            for (int j = 0; j < 2 * n - 1 - 2 * i; j++)
    //            {
    //                Console.Write(" ");
    //            }//in for
    //            for (int k = 0; k < i; k++)
    //            {
    //                Console.Write("X");
    //            }//in for
    //            Console.WriteLine();
    //        }//out for
    //    }//
    //}
}
