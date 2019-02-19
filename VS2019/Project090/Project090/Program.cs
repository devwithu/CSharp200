using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        static void Main(string[] args)
        {
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.PrintCards();
            Console.WriteLine("-------------------------");
            dic.Suffle();
            dic.PrintCards();
        }
    }
}