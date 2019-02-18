using System;
using Com.JunBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {

        public static void Main(string[] args)
        {
            int num = 5;//5x5 마방진
            OddMagicSquare odd = new OddMagicSquare(num);
            odd.Make();
            odd.Print();
        }
    }
}