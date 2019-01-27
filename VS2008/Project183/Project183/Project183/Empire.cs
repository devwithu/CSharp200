using System;
namespace Com.JungBo.Game{
    public class Empire{
        private int[] pit;//투수가 던진공
        private int[] hit;//타자가 친 공
        public Empire(int m) {
            pit = new int[m];
            hit = new int[m];
        }
        public Empire(): this(3){ }
        //투수가 던진 공
        public int[] Pit {
            get { return this.pit; }
            set { pit = value; }
        }
        //타자가 친 공
        public int[] Hit{
            get { return this.hit; }
            set { hit = value; }
        }
        //스트라이크
        public int Strike() {
            int count = 0;
            for (int i = 0; i < hit.Length; i++){
                if (hit[i] == pit[i]) { count++; }
            }
            return count;
        }//
        //볼
        public int Ball(){
            int count = 0;
            for (int i = 0; i < hit.Length; i++){
                for (int j = 0; j <hit.Length; j++){
                    if (i!=j && hit[i] == pit[j]) { 
                        count++; 
                    }
                }
            }
            return count;
        }//
    }
}
