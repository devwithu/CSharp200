using System;
namespace Com.JungBo.Logic {
    public class LeapYearMain{
        public static void Main(string[] args){
            CalendarUsingDateTime ly =
                   new CalendarUsingDateTime();
            //ly.PrintCalendar(2009,10);
            ly.PrintCalendar(2009);
        }
    }
}
