using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){


            Console.WriteLine("��������---------");
            int a = 3; int b = 5; int c = 2;
            Bubble.Print(a, b, c);
            Bubble.DescSort(a, b, c);
            Bubble.Print(a, b, c);
            int[] mm ={ 6,3,8,9,2,1,4,7,5};  //�迭���� ��밡��
            Console.WriteLine("������---------");
            Bubble.Print(mm);
            Console.WriteLine("������---------");
            Bubble.DescSort(mm);

        }
    }
}
