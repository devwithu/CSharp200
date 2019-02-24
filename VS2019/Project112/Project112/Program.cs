using System;
using System.Threading;
using Com.JungBo.Proce3;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ThreadCompete tcomp = new ThreadCompete();
            tcomp.Going();
        }
    }
}