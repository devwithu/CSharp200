using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic {
    public class RSA{
        private int p=7;    //소수1
        private int q=11;   //소수 2
        private int n;      //소수1x소수2
        private int phiN;   //(소수1-1)x(소수-2)
        private int e;      //공개키
        private int d;      //개인키
        private static int SEED = 127;//시작값 111?

        List<int> eList = new List<int>();
        List<int> dList = new List<int>();

        public RSA() {}
        
        public int N{get { return n; }}
        public int E{get { return e; }}
        //소수1x소수2
        private void MakeN() { 
            this.n=p*q;
            Console.WriteLine("n= {0}", n);
        }
        //(소수1-1)x(소수-2)
        private void MakePhiN(){
            this.phiN = (p - 1) * (q - 1);
            Console.WriteLine("phiN= {0}", phiN);
        }
        //RSA 암호화
        public void Make() {
            MakePQ();
            MakeN();//n만들기
            MakePhiN();
            MakeEs();
            ShowEs();
            SelectE();
            MakeDs();
            SelectD();
        }
        //서로 다른 두 소수 만들기 섹션 59
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
            //-------------------개발후 지우기
            Console.WriteLine("p= {0}", p);
            Console.WriteLine("q= {0}", q);
            //-------------------개발후 지우기
        }
        private void MakeEs(){
            eList.Clear();   //모두 지워기
            for (int i = 2; i < phiN; i++){
                //e는 p나 q가 아니다.또한 i와 phiN는 서로소
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
            //임의의 하나 선택
            e = eList[lot.Lot[0] - 1];
        }
        //SelectD()뒤에만 사용할 수 있다.
        private void ShowDs(){
            int count = dList.Count;
            if (count == 0) { return; }
            Console.Write("D [");
            for (int i = 0; i < count - 1; i++){
                Console.Write("{0}, ", dList[i]);
            }
            Console.WriteLine("{0}]", dList[count - 1]);
        }
        //개인 키 구하기
        private void MakeDs(){
            dList.Clear();
            for (int i = 2; i < this.phiN; i++){
             //ed 동치 1,  mod(phi(N))
             if ( e!=i && (e * i) % phiN == 1) {
                dList.Add(i);
             }
            }
        }
        //개인 키 선택하기
        private void SelectD() {
            int count = dList.Count;
            int iters = 0;
            while(count==0){
                iters++;
                MakeDs();
                count = dList.Count;
                if(iters==10){
                    SelectE();//만족하는 e에대한 d
                    //가 없을 때 다시 e를 선택하고 
                    //그것에 대한 d를 얻는다.
                    iters = 0;
                }
            }
            d = dList[0];
            //-------------------개발후 지우기
            Console.WriteLine("e={0}", e);
            ShowDs();
            Console.WriteLine("d={0}",d);
            //---------------------------
        }
        //모두 암호화
        public int[] ToPS(int[] ps) {
            int[] ims = new int[ps.Length];

            for (int i = 0; i < ps.Length; i++){
                ims[i] = ToP(ps[i]);
            }

            return ims;
        }
        //한개 암호화
        private int ToP(int c) {
            int temp = 1;
            for (int i = 0; i < d; i++){
                temp = (temp * c) % n;
            }
            return temp;
        }
    }
}
