using System;
using System.Globalization;//CultureInfo
namespace Com.JungBo.Logic{
public class CalendarUsingDateTime{
 //�ش� ����� ����޷�
 public void PrintCalendar(int year, int month){
    //�Էµ� ����� 1�� ����  ->GregorianCalendar �̿�
    DateTime dt = new DateTime(year, month, 1, 
                      new GregorianCalendar());
    Console.WriteLine("\t------- {0}�� {1}�� --------",
                                 dt.Year, dt.Month); ;
    String s = "��\t��\tȭ\t��\t��\t��\t��";
    Console.WriteLine(s);
    //1���� ���ϱ��ϱ�- 0,1,2,3,4,5,6 (�Ͽ����� 0)
    int startOfWeek =((int)dt.DayOfWeek) % 7;
    //�츮���� �ð��뿡 �˸°� 
    Calendar cal = CultureInfo.InvariantCulture.Calendar;
    //�״޿� �������� ���ϱ�
    //DateTime�� Calendar�� ���� ��ȭ
    int lastDay = cal.GetDaysInMonth(dt.Year, dt.Month,
                                  Calendar.CurrentEra);
    //1���� ����ó��, 1���� ȭ�����̶�� ��,�� ����ó��
    for (int i = 0; i < startOfWeek; i++){
        Console.Write("\t");
    }
    //1�Ϻ��� �������� ���� ���
    for (int i = 1; i <= lastDay; i++){
        Console.Write("{0,2}\t", i);
        //������̶�� ��ĭ ������
        if ((startOfWeek + i) % 7 == 0){
            Console.WriteLine();
        }
    }
    Console.WriteLine("\n");
 }//
 //�����ε�, �ش�⵵�� ����޷�
 public void PrintCalendar(int year){
    for (int i = 1; i < 13; i++){
        PrintCalendar(year, i);
    }
 }//
}
}
