using System;
namespace Com.JungBo.Logics {
    //--, ++
    public class BitConverts {
        int PIVOT = 1;  //2���� ��Ʈ����ũ
        public void MakeTo2(int m){

            int [] twoBit=new int [32];//����(�ڵ��ʱ�ȭ)
            int count = twoBit.Length;  //32, �迭�� ũ��
            int nums = 0;
            while (m != 0 && count > 0){
                twoBit[--count] = m & PIVOT;
                m >>= 1;  //��ȣ������� ���ڸ� ������
                nums++;
            }
            for (int i = twoBit.Length - nums; i < twoBit.Length; i++){
                Console.Write("{0}",twoBit[i]);
            }
            Console.WriteLine();
        }
        public int[] MakeTo2es(int m){

            int[] twoBit = new int[32];//����(�ڵ��ʱ�ȭ)
            int count = twoBit.Length;  //32, �迭�� ũ��
            int nums = 0;
            while (m != 0 && count > 0)
            {
                twoBit[--count] = m & PIVOT;
                m >>= 1;  //��ȣ������� ���ڸ� ������
                nums++;
            }
            int[] results = new int[nums];
            Array.Copy(twoBit, twoBit.Length - nums,results,0,nums);
            return results;
        }
        public static void Print(int[]m) {
            for (int i = 0; i < m.Length; i++){
                Console.Write(m[i]);
            }
            Console.WriteLine();
        }
    }//class
}
