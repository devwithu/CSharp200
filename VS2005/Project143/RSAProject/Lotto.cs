using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic {
    public class Lotto{

        private int[] lot;

        
        private int m;//전체 공의 개수 45
        private int n; //선택된 공의 수  6

        Random r;
        static int SEED = 17;

        public Lotto(int m, int n) {
            Init(m,n);
        }

        public Lotto() :this(45,6){ }

        private void Init(int m, int n) {
            this.m = m;
            this.n = n;
            lot = new int[n];
            r = new Random(SEED++  + System.DateTime.Now.Millisecond);
        }
        private int NumMake() {
            return r.Next(m) + 1;
        }

        public void Make() {
            int count = 0;
            while(count!=lot.Length){
                int temp = this.NumMake();
                if(!this.Contains(temp)){
                    lot[count++] = temp;
                }
            }
        }

        public void ReMake() {
            Init(m,n);
            this.Make();
        }

        private bool Contains(int num) {
            bool hasS = false;
            for (int i = 0; i < lot.Length; i++)
            {
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
            for (int i = 0; i < lot.Length-1; i++)
            {
                sb.Append(string.Format("{0},",lot[i]));
            }
            sb.Append(
                string.Format("{0}]", lot[lot.Length - 1]));
            Console.WriteLine(sb.ToString());
        }

        public int[] Lot
        {
            get { return lot; }

        }
    }
}
