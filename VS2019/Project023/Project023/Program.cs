﻿using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int startNum = 1;
            int endNum = 10000;
            Console.WriteLine("{0}과 {1}사이의 친화수: "
                , startNum, endNum);
            UclidMath.PrintFriend(startNum, endNum);//친화수

            Console.WriteLine("{0}의 약수의 합(자신제외): {1}",
                79750, UclidMath.SumDivision(79750));
            UclidMath.PrintDivision(79750);

            Console.WriteLine("{0}의 약수의 합(자신제외): {1}",
                88730, UclidMath.SumDivision(88730));
            UclidMath.PrintDivision(88730);


            Console.WriteLine("{0}의 약수의 합(자신제외): {1}",
               220, UclidMath.SumDivision(220));
            UclidMath.PrintDivision(220);

            Console.WriteLine("{0}의 약수의 합(자신제외): {1}",
                284, UclidMath.SumDivision(284));
            UclidMath.PrintDivision(284);


        }
    }
}
