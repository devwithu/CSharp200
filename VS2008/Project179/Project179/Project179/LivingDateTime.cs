using System;
using System.Globalization;
namespace Com.JungBo.Logic {
    public class LivingDateTime{
private DateTime birthDay;
private DateTime toDay;
public LivingDateTime(DateTime birthDay, DateTime toDay) {
    this.birthDay = birthDay;
    this.toDay = toDay;
}
//������ �ʱ�ȭ �ϰ� ���� ��¥�� ���÷� �ʱ�ȭ
public LivingDateTime(DateTime birthDay){
    this.birthDay = birthDay;
    toDay = DateTime.Now;
}
//������ �ʱ�ȭ �ϰ� ���� ��¥�� ���÷� �ʱ�ȭ
public LivingDateTime(int year, int month, int day){
    birthDay= new DateTime(year, month, day,
                           new GregorianCalendar());
    toDay = DateTime.Now;
}
public DateTime ToDay{
    get { return toDay; }
    set { toDay = value; }
}
public void SetToDay(int year,int month, int day){
   toDay= new DateTime(year, month, day, 
                          new GregorianCalendar());
}
public int HowLong() {
    TimeSpan howSpan = toDay - birthDay;
    return howSpan.Days;
}
//������
public void NextDay() {
    //�ٽ� �޾ƾ� �Ѵ�.-->�⺻Ÿ���̱� ����
    toDay = toDay.AddDays(1);
}
//�Ϸ���
public void PerviousDay(){
    toDay = toDay.AddDays(-1);
}
/*
* ���̿������� 1906�� ������ �ǻ� W. ����� 
* ȯ���� �ӻ󿬱� ���  �ֱ�PSI �м�
*��ü : 23, ���� : 28, ���� : 33, ���� : 38
*/
public double Physical() {
    return Math.Sin(2.0 * Math.PI * HowLong() / 23.0);
}
public double Emotial(){
    return Math.Sin(2.0 * Math.PI * HowLong() / 28.0);
}
public double Intellectual(){
    return Math.Sin(2.0 * Math.PI * HowLong() / 33.0);
}
public double Perceptive(){
    return Math.Sin(2.0 * Math.PI * HowLong() / 38.0);
}
    }
}
