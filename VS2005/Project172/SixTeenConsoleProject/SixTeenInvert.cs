using System;
namespace Com.JungBo.Logic{
    public class SixTeenInvert{
        private int inverNum = 0;
        private int[,] sti;
        public SixTeenInvert(int[,] sti) {
            //2���� �迭 ���� ����
            this.sti = MatrixTrans<int>.Mat2Clone(sti,
                sti.GetLength(0), sti.GetLength(1));
        }//
        //���Ǽ��� ���� ������ ū ���
        //2893�̶�� 83, 93 �� 2��찡 �߻�
        public void InvertNumbers() {
            int[] m = MatrixTrans<int>.Mat2to1(sti);
            int num = m.GetLength(0);
            for (int i = 0; i < num-1; i++){
                for (int j = i+1; j < num; j++){
                    if(m[j]!=0 && m[i]>m[j]){
                        inverNum++;
                    }
                }
            }
        }
        //16�Ǵ� 0�� �ִ� ���� ��ġ
        public int ZeroRow() {
            int locate = 0;
            int col = sti.GetLength(1);
            int[] m = MatrixTrans<int>.Mat2to1(sti);
            int num = m.GetLength(0);
            for (int i = 0; i < num ; i++){
               if(m[i]==0){
                   locate = i / col;
                   break;
               }
            }
            return locate;
        }//
        public int InverNum{
            get { return inverNum; }
        }
        //0�Ǵ� 16�� �ִ� ��+�������� ��+row�� 
        //Ȧ���� 16���� ����
        public bool IsPossible(){
            if ((sti.GetLength(0) +
                             inverNum+ZeroRow())%2 == 0){
                return false;
            }
            else {
                return true;
            }
        }
    }
}
