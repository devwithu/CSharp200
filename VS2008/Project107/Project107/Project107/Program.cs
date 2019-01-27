using System;
using System.Collections;
using Com.JungBo.School;
namespace Project107
{
    public class Program
    {
        public static void Main(string[] args)
        {
            YenaGrade[] yg = new YenaGrade[5];
            yg[0] = new YenaGrade(30, 60, 100);
            yg[1] = new YenaGrade(90, 70, 80);
            yg[2] = new YenaGrade(40, 90, 60);
            yg[3] = new YenaGrade(60, 67, 89);
            yg[4] = new YenaGrade(100, 100, 80);
            Print(yg);
            //좋은성적에서 낮은 성적으로 DESC
            YenaGradeComparer ygcomp = new YenaGradeComparer();
            Array.Sort(yg);   //성적순 정렬 CompareTo
            //Array.Sort(yg, ygcomp);   //성적순 정렬
            Console.WriteLine("========After==============");
            Print(yg);
            //ArrayList list = new ArrayList(yg);
            //list.Sort(ygcomp);
        }

        public static void Print(YenaGrade[] yg)
        {
            foreach (YenaGrade ygrade in yg)
            {
                Console.WriteLine(ygrade);
            }
        }
    }
}
