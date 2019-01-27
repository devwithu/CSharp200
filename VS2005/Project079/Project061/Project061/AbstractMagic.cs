using System;
namespace Com.JunBo.Logic{
    public abstract class AbstractMagic  {

        protected int[,] mabang;//2차원 배열 선언

        public AbstractMagic(int n){
            this.mabang = new int[n, n];//생성, 초기화
        }//생성자
        
        //추상메서드
        public abstract void Make();

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
    }
}
