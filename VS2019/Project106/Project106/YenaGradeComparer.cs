using System;
using System.Collections;//IComparer
namespace Com.JungBo.School{
    public class YenaGradeComparer:IComparer{
        //IComparer의 Comparer구현-> 두 개체비교
        public int Compare(object x, object y){
            YenaGrade yg1 = x as YenaGrade;
            YenaGrade yg2 = y as YenaGrade;
            //평균이 높은 것에서 낮은 것으로
            if (yg1.Avg > yg2.Avg){
                return -1; //DES
            }
            else if (yg1.Avg < yg2.Avg){
                return 1;//ASC
            }
            else {//평균이 같을경우 국어점수로 판단
                if (yg1.Kor > yg2.Kor){
                    return -1; //DES
                }
                else if (yg1.Kor < yg2.Kor){
                    return 1;//ASC
                }
                else return 0;
            }
        }//Compare
    }
}
