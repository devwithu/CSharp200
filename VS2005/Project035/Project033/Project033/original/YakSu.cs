using System;
namespace Com.JungBo.Logics {
    //out
    public class YakSu {
        //����� ������ ���Ѵ�.
        private void CounOfYaksu(int n, out int nums) {
            int count = 0;  //�ʱ�ȭ ��Ŵ
            if (n == 1){
                count = 1;
            }else {
                for (int i = 1; i <= n; i++){
                    if(n%i==0){
                        count++;
                    }
                }
            }
            nums = count;   //�ܺη� ��������.
        }//
        public void MakeYaksu(int n) {
            int count;   //�ʱ�ȭ ��Ű�� ����
            //����� ���� �� count�� ����
            CounOfYaksu(n, out count);
            int[] m = new int[count];
            for (int i = 1, j=0 ; i <= n; i++){
                if (n % i == 0){
                    m[j++] = i; 
                }
            }
            foreach (int  mVal in m){
                Console.Write("{0}  ", mVal);
            }
            Console.WriteLine();
        }
        public int[] MakeYaksues(int n){
            int count;  //�ʱ�ȭ ��Ű�� ����
            //����� ���� �� count�� ����
            CounOfYaksu(n, out count);
            int[] m = new int[count];
            for (int i = 1, j = 0; i <= n; i++){
                if (n % i == 0)
                {
                    m[j++] = i;
                }
            }
            return m;
        }
        public static void Print(int[] m){
            for (int i = 0; i < m.Length; i++){
                Console.Write("{0} ",m[i]);
            }
            Console.WriteLine();
        }
    }//class
}
