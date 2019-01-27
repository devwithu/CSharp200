using System;
namespace Com.JungBo.Game{
    public class Pitcher{
        private int[] lott;//�迭����
        public static int seed=5;
        private Random r;
        private int m;
        public Pitcher(int m) {
            this.m = m;
        }
        public Pitcher() : this(3) { }
        //������ ���� ��
        public int[] Ball {
            get { return this.lott; }
        }
        //0~9 ������ ���� �ٸ� �� ��
        private void Init(int m) {
            lott = new int[m]; //�迭����, �ʱ�ȭ-->0
            BaseBallUtil.Fill(lott,-1); //�ʱ�ȭ-->-1
            seed = DateTime.Now.Millisecond+seed;
            r = new Random(seed++);
        }
        //0~9 �� ������ �� �� ��
        public int MakeNum() {
            return r.Next(0, 10);//0~9 �� ���Ǽ�
        }//
        //���� ���� �ִ°�
        public bool Contain(int m) { //m�� �����ϰ� �ִ°�?
            bool isC = false;
            for (int i = 0; i < lott.Length; i++) {
                if (lott[i]==m){
                    isC = true;
                    break;
                }
            }
            return isC;
        }//
        //�ζǿ� ���� ���� ���� �����
        private void Make() {
            int count = 0;
            while(count!=lott.Length){
                int temp = this.MakeNum();
                if(!this.Contain(temp)){
                    lott[count++] = temp;
                }
            }
        }//
        //�ܺο��� ���
        public void ReMake() {
            this.Init(m);
            this.Make();
        }
    }
}
