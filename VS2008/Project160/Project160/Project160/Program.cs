﻿using System;
namespace Com.JungBo.Logic
{
    public class AntMain
    {
        public static void Main(string[] args)
        {
            AntQuiz quiz = new AntQuiz();
            quiz.AntStair(15);//15층 개미퀴즈
            //Console.WriteLine(quiz.PreString("1121"));
            //Console.WriteLine(quiz.NextString("1121"));
            //Console.WriteLine(quiz.Make("1121"));
            //Console.WriteLine(quiz.MakeAnt("1121"));
        }
    }
}
