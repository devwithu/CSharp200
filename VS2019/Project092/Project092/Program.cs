using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CardStack stacks = new CardStack();
            stacks.MakeCards();//스택에 채우기
            for (int i = 0; i < 20; i++)
            {
                stacks.PrintCards();
            }
            stacks.MakeCards();//다시 스택에 채우기
            for (int i = 0; i < 20; i++)
            {
                stacks.PrintCards();
            }
        }
    }
}