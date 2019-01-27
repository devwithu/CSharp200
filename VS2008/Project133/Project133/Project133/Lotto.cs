using System;
using System.Text;//StringBuilder
namespace Com.JungBo.Logic {
    public class Lotto{
        private int[] lot;//6개의 서로 다른 번호
        private int m;//전체 공의 개수 45
        private int n; //선택된 공의 수  6
        Random r;//임의의 수를 만드는 클래스
        static int SEED = 17;

        public Lotto(int m, int n) {
            Init(m,n);
        }
        public Lotto() :this(45,6){ }

        private void Init(int m, int n) {
            this.m = m;
            this.n = n;
            lot = new int[n];
            r = new Random(SEED++ + System.DateTime.Now.Millisecond);
        }
        //임의의 수 만들기 1~45
        private int NumMake() {
            return r.Next(m) + 1;
        }
        //서로 다른 6개의 공 만들기
        public void Make() {
            int count = 0;
            while(count!=lot.Length){
                int temp = this.NumMake();
                if(!this.Contains(temp)){
                    lot[count++] = temp;
                }
            }
        }
        //다시 만들기
        public void ReMake() {
            Init(m,n);
            this.Make();
        }
        //같은 수가 있는가?
        private bool Contains(int num) {
            bool hasS = false;
            for (int i = 0; i < lot.Length; i++) {
                if(lot[i]==num){
                    hasS = true;
                    break;
                }
            }
            return hasS;
        }
        public void Print() {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < lot.Length-1; i++){
                sb.Append(string.Format("{0},",lot[i]));
            }
            sb.Append(
                string.Format("{0}]", lot[lot.Length - 1]));
            Console.WriteLine(sb.ToString());
        }
        public int[] Lot{
            get { return lot; }

        }
    }
}
