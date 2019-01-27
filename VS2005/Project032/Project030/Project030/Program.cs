using System;
using System.Collections;//IEnumerable
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            int[] mm ={ 6,3,8,9,2,1,4,7,5};
            foreach (int num in mm){
                Console.Write("{0}\t", num);
            }
            Console.WriteLine();

            Console.WriteLine("정렬전---------");
            Bubble.Print(mm);

            Console.WriteLine("정렬후---------");
            Bubble.AscSort(mm);     //증가순으로 정렬
            Bubble.Print(mm);

            //참고
            IEnumerable ieb = (IEnumerable)mm;

            foreach (int vars in ieb)
            {
                Console.Write("{0}\t", vars);
            }
            Console.WriteLine();
        }
    }
}
