using System;
namespace Com.JungBo.Logic{
    //Random
    public class RSA{
        private int p=7;
        private int q=11;
        //생성자에서만 변경할 수 있다.
        public readonly  int SEED = 111;//11~1111까지
        private int seed = 37;  //보통 소수로 시작

        public RSA(int prime) {
            ///section 19 이용
            if(PrimNumber.IsPrime2(prime)){
                SEED = prime;
            }
        }
        //밖에서는 호출할 수 없다.
        //seed가 없을 경우와 있을 경우 출력화면을 보이자. 
        //차이점을 인식시키자.
        private void MakePQ(){
            //두수가 동일할 경우가 많다.
            //Random r = new Random(); //1)
            //앞쪽수가 연속적으로 동일할 경우가 많다.
            //Random r = new Random(seed++);  //2)
            //수들이 동일할 경우가 적다.
            Random r =
             new Random(seed++ + DateTime.Now.Millisecond);
            
            int distance = SEED/2;
            int tP = r.Next(SEED - distance, SEED);
            //section 19 이용
            while (!PrimNumber.IsPrime2(tP)){
                //소수가 아니라면 새로 만든다.
                tP = r.Next(SEED - distance, SEED); ;
            }
            this.p = tP;

            int tQ = r.Next(SEED, SEED + distance);
            //q가 소수이면서 p와 값이 달라야한다.
            while (!PrimNumber.IsPrime2(tQ) || p == tQ){
                //p보다는 큰 다른 소수
                tQ = r.Next(SEED, SEED + distance);
            }
            this.q = tQ;
        }
        public void Make(){
            MakePQ();
        }
        public override string ToString(){
            return string.Format(
                "{0} 근처의 서로다른 두 소수: [{1}, {2}]"
                ,SEED,p,q);
        }
    }
}
