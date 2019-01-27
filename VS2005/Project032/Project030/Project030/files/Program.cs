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

            Console.WriteLine("������---------");
            Bubble.Print(mm);

            Console.WriteLine("������---------");
            Bubble.AscSort(mm);     //���������� ����
            Bubble.Print(mm);

            //����
            IEnumerable ieb = (IEnumerable)mm;

            foreach (int vars in ieb)
            {
                Console.Write("{0}\t", vars);
            }
            Console.WriteLine();
        }
    }
}
