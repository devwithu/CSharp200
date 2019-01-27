using System;
namespace Com.JungBo.Maths{
    public enum SortType {ASC=100, DESC }
    //overloading
    public class HKArray{
        public static void PrintArray(int[]m) {
            foreach (int num in m){
                Console.Write("{0}  ",num);
            }
            Console.WriteLine();
        }
        //0���� �ʱ�ȭ
        public static void Clear(int[] m){
            Array.Clear(m, 0, m.Length);
        }
        //�Էµ� n���� �ʱ�ȭ
        public static void Clear(int[] m,  int n){
            for (int i = 0; i < m.Length; i++){
                m[i] = n;//n���� ��� �����
            }
        }
        //SortType�� ���� ����
        public static void Sort(int[] m,SortType stype) {
            switch (stype){
                case SortType.ASC: Array.Sort(m);
                    break;
                case SortType.DESC: Array.Sort(m);//asc��
                                    Array.Reverse(m);//�ݴ��
                    break;
            }
        }//
        //SortType�� ���ٸ� �ڵ����� ASC
        public static void Sort(int[] m){
            Sort(m, SortType.ASC);//�̹� ����� ���� Ȱ��
        }//
    }
}
