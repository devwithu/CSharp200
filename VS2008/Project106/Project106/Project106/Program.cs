using System;
using Com.JungBo.School;
namespace Project104
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //선언, 생성-> 초기화 안됨
            YenaGrade[] yg = new YenaGrade[5];
            yg[0] = new YenaGrade(30, 60, 100);//초기화
            yg[1] = new YenaGrade(90, 70, 80);
            yg[2] = new YenaGrade(40, 90, 60);
            yg[3] = new YenaGrade(60, 67, 89);
            yg[4] = new YenaGrade(100, 100, 80);
            Print(yg);
            //좋은성적에서 낮은 성적으로 DESC
            YenaGradeComparer ygcomp = new YenaGradeComparer();
            Array.Sort(yg, ygcomp);   //성적순 정렬
            Console.WriteLine("========After==============");
            Print(yg);
            Array.Reverse(yg);  //ASC
            Console.WriteLine("========Reverse==============");
            Print(yg);
        }
        //배열의 엘리먼트를 순서대로 출력
        public static void Print(YenaGrade[] yg)
        {
            foreach (YenaGrade ygrade in yg)
            {
                Console.WriteLine(ygrade);
            }
        }
    }
}
