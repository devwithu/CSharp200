using Com.JungBo.Logics;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HechoCalendar hecal = new HechoCalendar();
            //1990~2010 사이의 윤년
            hecal.PrintLeapYear(1990, 2010);
        }
    }
}
