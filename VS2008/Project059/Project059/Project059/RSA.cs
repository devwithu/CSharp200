using System;
namespace Com.JungBo.Logic{
    //Random
    public class RSA{
        private int p=7;
        private int q=11;
        //�����ڿ����� ������ �� �ִ�.
        public readonly  int SEED = 111;//11~1111����
        private int seed = 37;  //���� �Ҽ��� ����

        public RSA(int prime) {
            ///section 19 �̿�
            if(PrimNumber.IsPrime2(prime)){
                SEED = prime;
            }
        }
        //�ۿ����� ȣ���� �� ����.
        //seed�� ���� ���� ���� ��� ���ȭ���� ������. 
        //�������� �νĽ�Ű��.
        private void MakePQ(){
            //�μ��� ������ ��찡 ����.
            //Random r = new Random(); //1)
            //���ʼ��� ���������� ������ ��찡 ����.
            //Random r = new Random(seed++);  //2)
            //������ ������ ��찡 ����.
            Random r =
             new Random(seed++ + DateTime.Now.Millisecond);
            
            int distance = SEED/2;
            int tP = r.Next(SEED - distance, SEED);
            //section 19 �̿�
            while (!PrimNumber.IsPrime2(tP)){
                //�Ҽ��� �ƴ϶�� ���� �����.
                tP = r.Next(SEED - distance, SEED); ;
            }
            this.p = tP;

            int tQ = r.Next(SEED, SEED + distance);
            //q�� �Ҽ��̸鼭 p�� ���� �޶���Ѵ�.
            while (!PrimNumber.IsPrime2(tQ) || p == tQ){
                //p���ٴ� ū �ٸ� �Ҽ�
                tQ = r.Next(SEED, SEED + distance);
            }
            this.q = tQ;
        }
        public void Make(){
            MakePQ();
        }
        public override string ToString(){
            return string.Format(
                "{0} ��ó�� ���δٸ� �� �Ҽ�: [{1}, {2}]"
                ,SEED,p,q);
        }
    }
}
