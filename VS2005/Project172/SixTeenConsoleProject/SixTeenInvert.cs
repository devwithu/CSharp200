using System;
namespace Com.JungBo.Logic{
    public class SixTeenInvert{
        private int inverNum = 0;
        private int[,] sti;
        public SixTeenInvert(int[,] sti) {
            //2차원 배열 깊은 복사
            this.sti = MatrixTrans<int>.Mat2Clone(sti,
                sti.GetLength(0), sti.GetLength(1));
        }//
        //앞의수가 뒤의 수보다 큰 경우
        //2893이라면 83, 93 등 2경우가 발생
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
        //16또는 0이 있는 행의 위치
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
        //0또는 16이 있는 행+뒤집어진 수+row가 
        //홀수면 16게임 가능
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
