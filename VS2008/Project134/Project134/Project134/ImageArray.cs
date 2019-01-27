using System;
using System.Text;//StringBuilder
namespace Com.JungBo.Logic{
	public class ImageArray{
		int []  lot ;
        private int m;//전체 공의 개수
        Random r;
        static int SEED = 17;
        public ImageArray(int m){
            Init(m);
        }
        public ImageArray() : this(24) { }
        //0도 가능하므로 -1로 초기화
        private void Init(int m) {
            this.m = m;
            lot = new int[m];
            for (int i = 0; i < lot.Length; i++){
                lot[i] = -1;
            }
            r = new Random(SEED++ +System.DateTime.Now.Millisecond);
        }
        private int NumMake() {
            return r.Next(m/2); //0<=m/2 <6
        }
        //같은 수가 두개씩 임의의 위치에 만들기
        public void Make() {
            int count = 0;
            while(count!=lot.Length){
                int temp = this.NumMake();
                //0, 1개면 더 받을 수 있다.
                if (NumCount(temp)<2){
                    lot[count++] = temp;
                }
            }
        }
        public void ReMake() {
            Init(m);
            this.Make();
        }
        //같은 수가 몇개 있는가?
        private int NumCount(int num) {
            int hasS = 0;
            for (int i = 0; i < lot.Length; i++){
                if(lot[i]==num){
                    hasS++;
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
        public int[] Getindex{
            get { return lot; }
        }
	}
}
