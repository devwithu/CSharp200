using System;
using Com.JungBo.Logic;
namespace Com.JunBo.Basic{
    public class Program{
        public static void Main(string[] args) {

            int[] m ={ 3, 6, 1, 8, 2, 9, 0 };
            NumberGen.Print<int>(m);
            NumberGen.Shuffle<int>(m);
            NumberGen.Print<int>(m);

            double[] n ={ 3.3, 6.3, 1.3, 8.3, 2.3, 9.3, 0.3 };
            NumberGen.Print<double>(n);
            NumberGen.Shuffle<double>(n);
            NumberGen.Print<double>(n);
        }
    }
}
