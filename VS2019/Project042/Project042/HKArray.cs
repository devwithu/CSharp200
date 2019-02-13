using System;
namespace Com.JungBo.Maths
{
    public enum SortType { ASC = 100, DESC }
    //overloading
    public class HKArray
    {
        public static void PrintArray(int[] m)
        {
            foreach (int num in m)
            {
                Console.Write("{0}  ", num);
            }
            Console.WriteLine();
        }
        //0으로 초기화
        public static void Clear(int[] m)
        {
            Array.Clear(m, 0, m.Length);
        }
        //입력된 n으로 초기화
        public static void Clear(int[] m, int n)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = n;//n으로 모두 만들기
            }
        }
        //SortType에 따라 정렬
        public static void Sort(int[] m, SortType stype)
        {
            switch (stype)
            {
                case SortType.ASC:
                    Array.Sort(m);
                    break;
                case SortType.DESC:
                    Array.Sort(m);//asc후
                    Array.Reverse(m);//반대로
                    break;
            }
        }//
        //SortType이 없다면 자동으로 ASC
        public static void Sort(int[] m)
        {
            Sort(m, SortType.ASC);//이미 선언된 것을 활용
        }//
    }
}
