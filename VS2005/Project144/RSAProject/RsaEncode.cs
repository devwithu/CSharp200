using System;
namespace Com.JungBo.Logic {
    public class RsaEncode{
        //����Ű
        private int n;
        private int e;
        private int[] cp;

        public RsaEncode(int n,int e) {
            this.n = n;
            this.e = e;
        }
        //�Ѱ� C���ϱ�(���� ��ȣȭ)
        public int ToC(int p){
            int temp = 1;
            for (int i = 0; i < e; i++){
                temp = (temp * p) % n;
            }
            return temp;
        }
        //��� ��ȣȭ
        public void SetP(int [] sp) {
            cp = new int[sp.Length];
            for (int i = 0; i < sp.Length; i++){
                cp[i] = ToC(sp[i]);
            }
        }
        public int[] GepC() {
            int []ccp = new int[cp.Length];
            Array.Copy(cp, ccp, cp.Length);
            return ccp;
        }
        public void PrintAlpha(){
            for (int i = 0; i < cp.Length; i++){
                Console.Write(cp[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
