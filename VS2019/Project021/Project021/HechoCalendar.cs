using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logics
{
    //논리연산자 &&, ||
    public class HechoCalendar
    {
        public bool IsLeapYear(int year)
        {
            bool isL = false;
            //A-B+c
            if (((year % 4 == 0) && (year % 100 != 0))
                          || (year % 400 == 0))
            {
                isL = true;
            }
            return isL;
        }//IsLeapYear

        public void PrintLeapYear(int sy, int ey)
        {
            for (int i = sy; i <= ey; i++)
            {
                if (IsLeapYear(i))
                {
                    Console.WriteLine("{0}는 윤년입니다.", i);
                }
            }
        }//PrintLeapYear

    }//HechoCalendar
}
