using System;
using System.Globalization;//CultureInfo
namespace Com.JungBo.Logic{
public class CalendarUsingDateTime{
 //해당 년월의 만년달력
 public void PrintCalendar(int year, int month){
    //입력된 년월의 1일 설정  ->GregorianCalendar 이용
    DateTime dt = new DateTime(year, month, 1, 
                      new GregorianCalendar());
    Console.WriteLine("\t------- {0}년 {1}월 --------",
                                 dt.Year, dt.Month); ;
    String s = "일\t월\t화\t수\t목\t금\t토";
    Console.WriteLine(s);
    //1일의 요일구하기- 0,1,2,3,4,5,6 (일요일이 0)
    int startOfWeek =((int)dt.DayOfWeek) % 7;
    //우리나라 시간대에 알맞게 
    Calendar cal = CultureInfo.InvariantCulture.Calendar;
    //그달에 마지막달 구하기
    //DateTime과 Calendar의 서로 변화
    int lastDay = cal.GetDaysInMonth(dt.Year, dt.Month,
                                  Calendar.CurrentEra);
    //1일의 요일처리, 1일이 화요일이라면 일,월 공백처리
    for (int i = 0; i < startOfWeek; i++){
        Console.Write("\t");
    }
    //1일부터 마지막날 까지 출력
    for (int i = 1; i <= lastDay; i++){
        Console.Write("{0,2}\t", i);
        //토요일이라면 한칸 내리기
        if ((startOfWeek + i) % 7 == 0){
            Console.WriteLine();
        }
    }
    Console.WriteLine("\n");
 }//
 //오버로딩, 해당년도의 만년달력
 public void PrintCalendar(int year){
    for (int i = 1; i < 13; i++){
        PrintCalendar(year, i);
    }
 }//
}
}
