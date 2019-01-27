using System;
namespace Com.JungBo.Logics{
    public class HechoCalendar{
        public bool IsLeapYear(int year){
            bool isL = false;
            //A-B+c
            if (((year % 4 == 0) && (year % 100 != 0)) 
                          ||  (year % 400 == 0)  ){
                isL = true;
            }
            return isL;
        }//IsLeapYear
        public int Days(int year, int month){
            int tDay = 0;
            
            if (IsLeapYear(year)){   // if. bool 
                // switch. fall through -->break;
                switch (month){
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
            }else{
                switch (month){
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
        }//Days
    }
}
