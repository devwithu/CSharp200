using System;
using System.Collections.Generic;
using System.Text;
using Com.JunBo.Logic;
namespace Com.JunBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OddMagicSquare odd = new OddMagicSquare(5);

            odd.Make();
            odd.Print();

        }
    }
}
