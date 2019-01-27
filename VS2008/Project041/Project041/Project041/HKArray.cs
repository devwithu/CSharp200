using System;
namespace Com.JungBo.Maths{
    public enum ClearType { ZERO, THEOTHER  }
    public enum SortType:int{ASC=100, DESC  }
    //enum
    public class HKArray{
        public static void PrintArray(int[]m) {
            foreach (int num in m){
                Console.Write("{0}  ",num);
            }
            Console.WriteLine();
        }//
        public static void Clear(int[] m,ClearType ctypes,int n){
            switch (ctypes){
                case ClearType.ZERO: Array.Clear(m, 0, m.Length);
                                     break;
                case ClearType.THEOTHER:
                    for (int i = 0; i < m.Length; i++){
                        m[i] = n;//n으로 모두 만들기
                    }
                    break;           
            }
        }//
        //SortType에 따라 정렬
        public static void Sort(int[] m,SortType stype) {
            switch (stype){
                case SortType.ASC: Array.Sort(m);
                    break;
                case SortType.DESC: Array.Sort(m);//asc후
                                    Array.Reverse(m);//반대로
                    break;
            }
        }//
    }
}
