using System;
namespace Com.JungBo.Logic{
    public class HechoCalendar{
        //2007/10/1 ->2006/21/31
        public int TotalDay(int year){
            int tDay = 0;
            for (int i = 1; i < year; i++){
                if (this.IsLeapYear(i)){
                    tDay += 366;
                }
                else {
                    tDay += 365;
                }
            }
            return tDay;
        }
        //2007/10/1 ->2006/21/31-->2007/9
        public int TotalDay(int year,int month){
            int tDay = TotalDay(year);//2006/21/31
            for (int i = 1; i < month; i++){
                tDay += Days(year, i);
            }
            return tDay;
        }//
        public int TotalDay(int year, int month,int day){
            int tDay = TotalDay(year,month);
            return tDay+day;
        }//
        public void PrintCalendar(int year, int month)
        {
            Console.WriteLine("--{0}년 -- {1}월------", year, month);
            String s = "일\t월\t화\t수\t목\t금\t토";
            Console.WriteLine(s);
            //-1:경과일 1:월요일대한 기준 
            int startOfWeek = (TotalDay(year,month,1)-1+1)%7;
            for (int i = 0; i < startOfWeek; i++){
                Console.Write("\t");
                
            }
            for(int i = 1; i <= Days(year,month); i++){
                Console.Write("{0,2}\t", i);
                if ((startOfWeek + i) % 7 == 0){
                    Console.WriteLine();
                }
            }
            Console.WriteLine(); 
        }
        //년도 찍으면 1월부터 12까지
        public void PrintCalendar(int year){   
            for (int month = 1; month <= 12; month++){
                PrintCalendar(year, month);
            }
        }
        //섹션 21
        public bool IsLeapYear(int year){
            bool isL = false;
            //A-B+c
            if (((year % 4 == 0) && (year % 100 != 0)) 
                || (year % 400 == 0)){
                isL = true;
            }
            return isL;
        }
        //섹션 21
        public void PrintLeapYear(int sy, int ey){
            for (int i = sy; i <= ey; i++){
                if (this.IsLeapYear(i)){
                    Console.WriteLine("{0}는 윤년입니다.", i);
                }
            }
        }
        //섹션 26
        public int Days(int year, int money){
            int tDay = 0;
            if (this.IsLeapYear(year)){   // 조심할점
                // 1.fall through -->break;
                switch (money) {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: tDay = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: tDay = 30; break;
                    case 2: tDay = 29; break;
                }
            }
            else {
                switch (money){
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: tDay = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: tDay = 30; break;
                    case 2: tDay = 28; break;
                }
            }
            return tDay;
        }
    }//IsLeapYear
}
