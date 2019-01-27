using System;
namespace Com.JungBo.Game{
    public class Pitcher{
        private int[] lott;//배열선언
        public static int seed=5;
        private Random r;
        private int m;
        public Pitcher(int m) {
            this.m = m;
        }
        public Pitcher() : this(3) { }
        //투수가 던진 공
        public int[] Ball {
            get { return this.lott; }
        }
        //0~9 사이의 서로 다른 세 수
        private void Init(int m) {
            lott = new int[m]; //배열생성, 초기화-->0
            BaseBallUtil.Fill(lott,-1); //초기화-->-1
            seed = DateTime.Now.Millisecond+seed;
            r = new Random(seed++);
        }
        //0~9 중 임의의 수 한 개
        public int MakeNum() {
            return r.Next(0, 10);//0~9 중 임의수
        }//
        //같은 수가 있는가
        public bool Contain(int m) { //m을 포함하고 있는가?
            bool isC = false;
            for (int i = 0; i < lott.Length; i++) {
                if (lott[i]==m){
                    isC = true;
                    break;
                }
            }
            return isC;
        }//
        //로또와 같이 서로 세수 만들기
        private void Make() {
            int count = 0;
            while(count!=lott.Length){
                int temp = this.MakeNum();
                if(!this.Contain(temp)){
                    lott[count++] = temp;
                }
            }
        }//
        //외부에서 사용
        public void ReMake() {
            this.Init(m);
            this.Make();
        }
    }
}
