using System;
namespace Com.JungBo.Game{
    public class Empire{
        private int[] pit;//������ ������
        private int[] hit;//Ÿ�ڰ� ģ ��
        public Empire(int m) {
            pit = new int[m];
            hit = new int[m];
        }
        public Empire(): this(3){ }
        //������ ���� ��
        public int[] Pit {
            get { return this.pit; }
            set { pit = value; }
        }
        //Ÿ�ڰ� ģ ��
        public int[] Hit{
            get { return this.hit; }
            set { hit = value; }
        }
        //��Ʈ����ũ
        public int Strike() {
            int count = 0;
            for (int i = 0; i < hit.Length; i++){
                if (hit[i] == pit[i]) { count++; }
            }
            return count;
        }//
        //��
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
