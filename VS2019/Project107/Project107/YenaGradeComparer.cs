using System;
using System.Collections;//IComparer
namespace Com.JungBo.School{
    public class YenaGradeComparer:IComparer{
        public int Compare(object x, object y){
            YenaGrade yg1 = x as YenaGrade;
            YenaGrade yg2 = y as YenaGrade;
            if(yg1.CompareTo(yg2)<0){
                return -1;  //yg2�� �۴�.
            }
            else if (yg1.CompareTo(yg2) > 0){
                return 1;   //yg2�� ũ��
            }
            else {
                return 0;
            }
        }//Compare
    }
}
