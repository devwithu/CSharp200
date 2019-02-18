using System;
namespace Com.JunBo.Logic{
    //2차원배열
    public class OddMagicSquare{
        private int[,] mabang;//2차원 배열 선언

        public OddMagicSquare(int n) {
            this.mabang = new int[n, n];//생성, 초기화
        }//생성자

        public void Make() {
            int top = mabang.GetLength(0)-1;  //열의 수
            int x = 0;        //맨위
            int y = top / 2;  //중앙
            mabang[x, y] = 1;
            for (int i = 2; i <= (top + 1) * (top+1); i++){
                int tempX = x;
                int tempY = y;

                if (x - 1 < 0){  //윗벽
                    x = top;     //아래쪽
                }
                else {
                    x--;
                }
                if (y - 1 < 0){   //왼쪽벽
                    y = top;      //오른쪽
                }
                else{
                    y--;
                }
                //이미 존재하는가?
                if(mabang[x,y]!=0){
                    x = tempX + 1;   //원위치에서 한칸아래
                    y = tempY;       //원위치
                }
                mabang[x, y] = i;
            }

        }//Make
        //row의 합을 구한다.마방진 체크로직 일부
        private int SumRow(int row){
            int count = mabang.GetLength(1);
            int total = 0;
            for (int i = 0; i < count; i++){
                //row는 변함없이 col만 변한다.
                total += this.mabang[row, i];
            }
            return total;
        }
        //마방진을 출력한다.
        public void Print(){
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
