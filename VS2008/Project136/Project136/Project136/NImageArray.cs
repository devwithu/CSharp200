using System;
using System.Text;//StringBuilder
namespace Com.JungBo.Logic{
    public class NImageArray{
        int[] lot;
        private int m;//전체 공의 개수 
        public NImageArray(int m){
            Init(m);
        }
        public NImageArray() : this(24) { }
        //2번씩 들어가도록 
        private void Init(int m){
            this.m = m;
            lot = new int[m];
            for (int i = 0; i < lot.Length/2; i++){
                lot[i] = i;
                lot[i + lot.Length / 2] = i;
            }
        }
        //두번 섞음-> 잘 섞음
        public void Make(){
            NumberGen<int>.Shuffle(lot);
            NumberGen<int>.Shuffle(lot);
        }
        public void Print(){
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < lot.Length - 1; i++){
                sb.Append(string.Format("{0},", lot[i]));
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
