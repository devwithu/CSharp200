using System;
using System.Text;//StringBuilder
namespace Com.JungBo.School{
public class YenaGrade : ICloneable{
 private double kor;
 private double eng;
 private double math;
 private double total;
 private double avg;

 public YenaGrade(double kor, double eng, double math) {
    this.kor = kor;this.eng = eng;this.math = math;
    GetAvg();
 }
 public YenaGrade() : this(0.0, 0.0, 0.0) { }

 private void GetTotal() {
    this.total = (this.kor + this.eng + this.math);
 }
 private void GetAvg() {
    GetTotal();this.avg= this.total / 3.0;
 }
 public double Kor{
    get { return kor; }set { kor = value;GetAvg();}
 }
 public double Eng{
    get { return eng; }set { eng = value;}
 }
 public double Math{
    get { return math; }set { math = value;GetAvg();}
 }
 public double Total{
    get {return total; }
 }
 public double Avg{
    get {return avg; }
 }
 public override string ToString(){
    GetAvg();
    StringBuilder sb = new StringBuilder();
    //.## 소수점 2자리 Format
    sb.Append(string.Format("[국어 {0:.##},", this.kor))
    .Append(string.Format("영어 {0:.##},", this.eng))
    .Append(string.Format("수학 {0:.##},", this.math))
    .Append(string.Format("총점 {0:.##},", this.Total))
    .Append(string.Format("평균 {0:.##}]", this.Avg));
    return sb.ToString();
 }//
//깊은 복사
 public  object Clone(){
    return new YenaGrade(this.kor,this.eng,this.math);
 }
}
}
