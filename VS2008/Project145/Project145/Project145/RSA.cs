using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic {
    public class RSA{
        private int p=7;    //�Ҽ�1
        private int q=11;   //�Ҽ� 2
        private int n;      //�Ҽ�1x�Ҽ�2
        private int phiN;   //(�Ҽ�1-1)x(�Ҽ�-2)
        private int e;      //����Ű
        private int d;      //����Ű
        private static int SEED = 127;//���۰� 111?

        List<int> eList = new List<int>();
        List<int> dList = new List<int>();

        public RSA() {}
        
        public int N{get { return n; }}
        public int E{get { return e; }}
        //�Ҽ�1x�Ҽ�2
        private void MakeN() { 
            this.n=p*q;
            Console.WriteLine("n= {0}", n);
        }
        //(�Ҽ�1-1)x(�Ҽ�-2)
        private void MakePhiN(){
            this.phiN = (p - 1) * (q - 1);
            Console.WriteLine("phiN= {0}", phiN);
        }
        //RSA ��ȣȭ
        public void Make() {
            MakePQ();
            MakeN();//n�����
            MakePhiN();
            MakeEs();
            ShowEs();
            SelectE();
            MakeDs();
            SelectD();
        }
        //���� �ٸ� �� �Ҽ� ����� ���� 59
        private void MakePQ(){
            Random r = new Random();
            int distance = SEED/2;
            int tP = r.Next(SEED - distance, SEED);
            while (!PrimeNumber.IsPrime(tP)){
                tP = r.Next(SEED - distance, SEED); ;
            }
            this.p = tP;

            int tQ = r.Next(SEED, SEED + distance);
            while (!PrimeNumber.IsPrime(tQ) || p == tQ) {
                tQ = r.Next(SEED, SEED + distance);
            }
            this.q = tQ;
            //-------------------������ �����
            Console.WriteLine("p= {0}", p);
            Console.WriteLine("q= {0}", q);
            //-------------------������ �����
        }
        private void MakeEs(){
            eList.Clear();   //��� ������
            for (int i = 2; i < phiN; i++){
                //e�� p�� q�� �ƴϴ�.���� i�� phiN�� ���μ�
                if (i != p && i != q && (i<phiN)&&
                       UclidMath.GCD(i, this.phiN) == 1){
                    eList.Add(i);
                }
            }
        }//
        //
        private void ShowEs(){
            Console.WriteLine("p={0}, q={1}",p,q);
            int count = eList.Count;
            Console.Write("E [");
            for (int i = 0; i < count-1; i++){
                Console.Write("{0}, ",eList[i]);
            }
            Console.WriteLine("{0}]",eList[count-1]);
        }
        private void SelectE(){
            int count = eList.Count;
            Lotto lot = new Lotto(count, 1);
            lot.Make();
            //������ �ϳ� ����
            e = eList[lot.Lot[0] - 1];
        }
        //SelectD()�ڿ��� ����� �� �ִ�.
        private void ShowDs(){
            int count = dList.Count;
            if (count == 0) { return; }
            Console.Write("D [");
            for (int i = 0; i < count - 1; i++){
                Console.Write("{0}, ", dList[i]);
            }
            Console.WriteLine("{0}]", dList[count - 1]);
        }
        //���� Ű ���ϱ�
        private void MakeDs(){
            dList.Clear();
            for (int i = 2; i < this.phiN; i++){
             //ed ��ġ 1,  mod(phi(N))
             if ( e!=i && (e * i) % phiN == 1) {
                dList.Add(i);
             }
            }
        }
        //���� Ű �����ϱ�
        private void SelectD() {
            int count = dList.Count;
            int iters = 0;
            while(count==0){
                iters++;
                MakeDs();
                count = dList.Count;
                if(iters==10){
                    SelectE();//�����ϴ� e������ d
                    //�� ���� �� �ٽ� e�� �����ϰ� 
                    //�װͿ� ���� d�� ��´�.
                    iters = 0;
                }
            }
            d = dList[0];
            //-------------------������ �����
            Console.WriteLine("e={0}", e);
            ShowDs();
            Console.WriteLine("d={0}",d);
            //---------------------------
        }
        //��� �ص�
        public int[] ToPS(int[] ps) {
            int[] ims = new int[ps.Length];

            for (int i = 0; i < ps.Length; i++){
                ims[i] = ToP(ps[i]);
            }

            return ims;
        }
        //�Ѱ� �ص�
        private int ToP(int c) {
            int temp = 1;
            for (int i = 0; i < d; i++){
                temp = (temp * c) % n;
            }
            return temp;
        }
    }
}
