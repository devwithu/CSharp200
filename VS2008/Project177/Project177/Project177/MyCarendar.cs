using System;
namespace Com.JungBo.Logic{
    public class MyCarendar{
        private int[] RYEAR =
    { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int[] LYEAR =
    { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //���� 1�� 1�� 1�Ϻ��� year-1�� 12�� 31�ϱ���
        public int TotalDay(int year){
            int total = 0;
            for (int i = 1; i < year; i++){
                if (IsLeapYear(i)){
                    total += 366;
                }
                else{
                    total += 365;
                }
            }
            return total;
        }//TotalDate
        public int TotalDay(int year, int month){
            int total = this.TotalDay(year);
            for (int i = 1; i < month; i++){
                if (this.IsLeapYear(year)){
                    total += LYEAR[i - 1];
                }
                else{
                    total += RYEAR[i - 1];
                }
            }
            return total;
        }//TotalDate
        public int TotalDay(int year, int month, int day){
            int total = this.TotalDay(year,month)+day;
            return total;
        }//TotalDate
        public int Days(int year, int month){
            if (IsLeapYear(year)){
                return LYEAR[month - 1];
            }
            else{
                return RYEAR[month - 1];
            }
        }
        public void PrintCalendar(int year, int month){
            string str = "------ {0}�� ------ {1}��--------";
            Console.WriteLine(str, year, month);
            String s = "��\t��\tȭ\t��\t��\t��\t��";
            Console.WriteLine(s);
            //-1:����� 1:�����ϴ��� ���� 
            int startOfWeek = (TotalDay(year, month, 1) - 1 + 1) % 7;
            for (int i = 0; i < startOfWeek; i++){
                Console.Write("\t");
            }
            for (int i = 1; i <= Days(year, month); i++){
                Console.Write("{0}\t", i);
                if ((startOfWeek + i) % 7 == 0){
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n");
        }
        
        //� ���� ���� �׳����� ���ñ��� ���� �� ��
        public int HowLongDay(int fyear, int fmonth, int fday,
            int tyear, int tmonth, int tday){
            int Date = this.TotalDay(tyear, tmonth, tday);
            Date= Date - this.TotalDay(fyear, fmonth, fday);
            return Date;
        }//HowLongDay
        public string ToDate(int date){
            string sdate = "��";
            switch (date){
                case 0: sdate = "��"; break;
                case 1: sdate = "��"; break;
                case 2: sdate = "ȭ"; break;
                case 3: sdate = "��"; break;
                case 4: sdate = "��"; break;
                case 5: sdate = "��"; break;
                case 6: sdate = "��"; break;
            }
            return sdate;
        }//ToDate
        public bool IsLeapYear(int year) {
            bool isL = false;
            if (((year % 4 == 0) && (year % 100 != 0))
                                   || (year % 400 == 0)){
                isL = true;
            }
            return isL;
        }//IsLeapYear(int year)
        //�⵵ ������ 1������ 12����
        public void PrintCalendar(int year){
            for (int month = 1; month <= 12; month++){
                PrintCalendar(year, month);
            }
            Console.WriteLine();
        }
    }//class MyCarendar
}
