using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            int[] mm ={ 6,3,8,9,2,1,4,7,5};
            Console.WriteLine("정렬전---------");
            Bubble.Print(mm);
            Console.WriteLine("정렬후---------");
            Bubble.AscSort(mm);
            Bubble.Print(mm);
        }
    }
}
