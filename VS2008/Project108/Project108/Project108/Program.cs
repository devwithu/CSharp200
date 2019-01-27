using System;
using System.Collections.Generic;
using Com.JungBo.School;
namespace Project104
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
            //좋은성적에서 낮은 성적으로 DESC
            YenaGradeComparerGen<YenaGrade> ygcomp =
                        new YenaGradeComparerGen<YenaGrade>();

            List<YenaGrade> list = new List<YenaGrade>(yg);
            Print(list);
            Console.WriteLine("========After==============");
            //list.Sort();//성적순 정렬   CompareTo
            list.Sort(ygcomp);  //comparer
            Print(list);
        }
        public static void Print(List<YenaGrade> list)
        {
            foreach (YenaGrade ygrade in list)
            {
                Console.WriteLine(ygrade);
            }
        }
    }
}
