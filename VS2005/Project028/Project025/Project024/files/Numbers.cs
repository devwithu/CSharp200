using System;
namespace Com.JungBo.Maths{
    public class Numbers{
        /// <summary>
        /// 1����� �Լ� n�� ¦���� n/2 Ȧ���� n*3+1
        /// </summary>
        public static void MakeOne(int n){
            int time = 0;
            Console.WriteLine("{0}���� 1�� �ǰ��� ����", n);

            while (n != 1) {//1�ƴϸ� �ݺ��Ѵ�.
                if (n % 2 == 0){
                    n /= 2;
                }
                else{
                    n = n * 3 + 1;
                }
                Console.Write("{0} ", n);
                time++;
            }
            Console.WriteLine("\n��� ���Ƴ�? {0}", time);
        }
    }
}
