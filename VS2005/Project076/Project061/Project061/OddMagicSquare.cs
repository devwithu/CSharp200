using System;
namespace Com.JunBo.Logic{
    //惑加茄促.
    public class OddMagicSquare:AbstractMagic{
        //积己磊
        public OddMagicSquare(int n):base(n) {}
        //积己磊
        public OddMagicSquare() : this(3) { }

        //overriding
        public override  void Make() {
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
    }//class
}//namespace
