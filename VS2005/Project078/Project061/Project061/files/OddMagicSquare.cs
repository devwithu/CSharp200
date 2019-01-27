using System;
namespace Com.JunBo.Logic{
    public class OddMagicSquare:AbstractMagic{

        public OddMagicSquare(int n):base(n) {
        }//持失切
        public OddMagicSquare():this(3){
        }//持失切

        public override void Make() {
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

        public override void Print(){
            int count = mabang.GetLength(0);
            for (int i = 0; i < count; i++){
                for (int j = 0; j < count; j++){
                    Console.Write("{0}\t", mabang[i, j]);
                }
                Console.Write("R:{0}\n", SumRow(i));
            }
            for (int j = 0; j < count; j++){
                Console.Write("C:{0}\t", SumCol(j));
            }
            Console.WriteLine();
        }//Print
    }//class
}//namespace
