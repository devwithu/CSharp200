using System;
using System.Globalization;
namespace Com.JungBo.Logic
{
    public class LivingDateTime
    {
        private DateTime birthDay;
        private DateTime toDay;

        public LivingDateTime(DateTime birthDay, DateTime toDay) {
            this.birthDay = birthDay;
            this.toDay = toDay;
        }
        //생일을 초기화 하고 오늘 날짜를 오늘로 초기화
        public LivingDateTime(DateTime birthDay)
        {
            this.birthDay = birthDay;
            toDay = DateTime.Now;
            
        }
        //생일을 초기화 하고 오늘 날짜를 오늘로 초기화
        public LivingDateTime(int year, int month, int day)
        {
            birthDay= new DateTime(year, month, day, new GregorianCalendar());
            toDay = DateTime.Now;
        }

        public DateTime ToDay
        {
            get { return toDay; }
            set { toDay = value; }
        }
        public void SetToDay(int year,int month, int day)
        {
           toDay= new DateTime(year, month, day, new GregorianCalendar());
        }
        public int HowLong() 
        {
            TimeSpan howSpan = toDay - birthDay;
            return howSpan.Days;
        }
        public void NextDay() {
            toDay = toDay.AddDays(1);//다시 받아야 한다.-->기본타입이기 때문
        }
        public void PerviousDay()
        {
            toDay = toDay.AddDays(-1);//다시 받아야 한다.-->기본타입이기 때문에
        }
  /*
 * 바이오리듬은 1906년 독일의 의사 W. 프리즈가 
 * 환자의 임상연구를 토대 신체(physical)는 23일, 
 * 감성(emotional)은 28일, 
 * 지성(intellectual)은 33일의 주기PSI 학설

        신체 : 23
        감성 : 28
        지성 : 33
        지각 : 38
        */
        public double Physical() {
            return Math.Sin(2.0 * Math.PI * HowLong() / 23.0);
        }
        public double Emotial()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 28.0);
        }
        public double Intellectual()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 33.0);
        }
        public double Perceptive()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 38.0);
        }
    }
}
