using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){

            int[] m ={ 5,3,2,7,8,9,1,6,4};
            int[] n=new int[m.Length];
            //m과 동일한 배열을 n에 깊은 복사
            Array.Copy(m, n, m.Length);
            int[] kk = new int[m.Length];
            //-1로 초기화
            HKArray.Clear(kk, ClearType.THEOTHER,- 1);
            HKArray.PrintArray(kk);
            HKArray.Sort(m, SortType.ASC);
            HKArray.PrintArray(m);
            HKArray.Sort(n, SortType.DESC);
            HKArray.PrintArray(n);
        }
    }
}
