using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Com.Kaoni.Subway
{
    public class SubwayMain
    {
        public static void Main(string[] args)
        {
            Floyd fl = new Floyd();
            SubwayUtil ut = new SubwayUtil();

            ut.SubwayNumber();

            Console.Write("����� : ");
            //string StartNumber = Console.ReadLine();
            int start = int.Parse(StartNumber);
            Console.Write("������ : ");
            //string GoalNumber = Console.ReadLine();
            int goal = int.Parse(GoalNumber);

            fl.Distance(); // �Ÿ����
            //Console.Write("{0} -> ", fl.name[start]);
            fl.Path(start, goal); // ���
            //Console.Write("{0}", fl.name[goal]);
            //Console.WriteLine();
            //fl.PrintPath();           
        }

    }//class SubwayMain

}//namespace
