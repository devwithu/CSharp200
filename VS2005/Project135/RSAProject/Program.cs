using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            int[] m ={ 0,1,2,3,4,5,0,1,2,3,4,5};
            NumberGen<int>.Shuffle(m);
            NumberGen<int>.Print(m);
            NumberGen<int>.Shuffle(m);
            NumberGen<int>.Print(m);
        }
    }
}
