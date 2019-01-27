using System;
namespace Com.JunBo.Logic{
    //인터페이스를 구현한다.
    public class OddMagicSquare:IMagic{
        private int[,] mabang;//2차원 배열 선언

        public OddMagicSquare(int n) {
            this.mabang = new int[n, n];//생성, 초기화
        }//생성자
        public OddMagicSquare():this(3){
        }//생성자

        public virtual void Make() {
            int top = mabang.GetLength(0)-1;
            int x = 0;
            int y = top / 2;
            mabang[x, y] = 1;
            for (int i = 2; i <= (top + 1) * (top+1); i++){
                int tempX = x;
                int tempY = y;

                if (x - 1 < 0){
                    x = top;
                }
                else {
                    x--;
                }
                if (y - 1 < 0){
                    y = top;
                }
                else{
                    y--;
                }

                if(mabang[x,y]!=0){
                    x = tempX + 1;
                    y = tempY;
                }
                mabang[x, y] = i;
            }

        }//Make
        //row의 합을 구한다.
        protected int SumRow(int row){
            int count = mabang.GetLength(1);
            int total = 0;
            for (int i = 0; i < count; i++){
                //row는 변함없이 col만 변한다.
                total += this.mabang[row, i];
            }
            return total;
        }//SumRow
        public virtual void Print(){
            for (int i = 0; i < mabang.GetLength(0); i++){
                for (int j = 0; j < mabang.GetLength(1); j++){
                    Console.Write("{0}\t", mabang[i, j]);
                }
                //row의 합 출력
                Console.Write("R:{0}\n",SumRow(i));
            }
        }//Print
    }//class
}//namespace
