using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            int[] mm ={ 6,3,8,9,2,1,4,7,5};
            Console.WriteLine("������---------");
            Bubble.Print(mm);
            Console.WriteLine("������---------");
            Bubble.AscSort(mm);
            Bubble.Print(mm);
        }
    }
}
