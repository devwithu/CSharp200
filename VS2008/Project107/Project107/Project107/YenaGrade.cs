using System;
using System.Text;//StringBuilder
namespace Com.JungBo.School{
    public class YenaGrade : ICloneable,IComparable{
        private double kor;
        private double eng;
        private double math;
        private double total;
        private double avg;

        public YenaGrade(double kor, double eng, double math) {
            this.kor = kor;
            this.eng = eng;
            this.math = math;
            GetAvg();
        }
        public YenaGrade() : this(0.0, 0.0, 0.0) { }

        private void GetTotal() {
            this.total = (this.kor + this.eng + this.math);
        }
        private void GetAvg() {
            GetTotal();
            this.avg= this.total / 3.0;
        }
        public double Kor{
            get { return kor; }
            set { kor = value;GetAvg();}
        }
        public double Eng{
            get { return eng; }set { eng = value;}
        }
        public double Math{
            get { return math; }
            set { math = value;GetAvg();}
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
            //.## �Ҽ��� 2�ڸ�
            sb.Append(string.Format("[���� {0:.##},", this.kor))
            .Append(string.Format("���� {0:.##},", this.eng))
            .Append(string.Format("���� {0:.##},", this.math))
            .Append(string.Format("���� {0:.##},", this.Total))
            .Append(string.Format("��� {0:.##}]", this.Avg));
            return sb.ToString();
        }//
        //���� ����
        public  object Clone(){
            return new YenaGrade(this.kor,this.eng,this.math);
        }
        //IComparable ����
        public int CompareTo(object obj){
            YenaGrade yg2 = obj as YenaGrade;
            if (avg > yg2.Avg){
                return -1; //yg2 �� �۴�.
            }
            else if (avg< yg2.Avg){
                return 1;//yg2 �� ũ��.
            }
            else{//����� ������� ���������� �Ǵ�
                if (kor > yg2.Kor){
                    return -1; //yg2 �� �۴�.
                }
                else if (kor < yg2.Kor){
                    return 1;//yg2 �� ũ��.
                }
                else return 0;
            }
        }
    }
}
