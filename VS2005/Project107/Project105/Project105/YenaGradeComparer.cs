using System;
using System.Collections;//IComparer
namespace Com.JungBo.School{
    public class YenaGradeComparer:IComparer{
        public int Compare(object x, object y){
            YenaGrade yg1 = x as YenaGrade;
            YenaGrade yg2 = y as YenaGrade;
            if(yg1.CompareTo(yg2)<0){
                return -1;  //yg2가 작다.
            }
            else if (yg1.CompareTo(yg2) > 0){
                return 1;   //yg2가 크다
            }
            else {
                return 0;
            }
        }//Compare
    }
}
