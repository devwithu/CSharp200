using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            HechoCalendar hecal = new HechoCalendar();
            hecal.PrintLeapYear(1990,2010);
        }
    }
}
