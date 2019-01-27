using System;
using System.Collections.Generic;
using System.Collections;//IComparer
namespace Com.JungBo.School{
 public class YenaGradeComparerGen<T>:IComparer<T>
 where T : YenaGrade{
    public int Compare(T x, T y){
        if(x.CompareTo(y)<0){return -1;} 
        else if (x.CompareTo(y) > 0){return 1;}
        else {return 0;}
    }//Compare
 }
}
