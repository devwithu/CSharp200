using System;
using System.Collections.Generic;
using System.Text;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){

            int startNum = 1;
            int endNum = 10000;
            Console.WriteLine("{0}�� {1}������ ģȭ��: "
                ,startNum, endNum);
            UclidMath.PrintFriend(startNum, endNum);//ģȭ��

            Console.WriteLine("{0}�� ����� ��(�ڽ�����): {1}",
                79750, UclidMath.SumDivision(79750));
            UclidMath.PrintDivision(79750);

            Console.WriteLine("{0}�� ����� ��(�ڽ�����): {1}",
                88730, UclidMath.SumDivision(88730));
            UclidMath.PrintDivision(88730);


            Console.WriteLine("{0}�� ����� ��(�ڽ�����): {1}",
               220, UclidMath.SumDivision(220));
            UclidMath.PrintDivision(220);

            Console.WriteLine("{0}�� ����� ��(�ڽ�����): {1}",
                284, UclidMath.SumDivision(284));
            UclidMath.PrintDivision(284);


        }
    }
}
