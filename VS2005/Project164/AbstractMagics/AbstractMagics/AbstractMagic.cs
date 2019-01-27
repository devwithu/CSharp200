using System;
namespace Com.JungBo.Logic{
    public abstract class AbstractMagic{

        protected int[,] mabang;//2차원 배열 선언
        protected int top;//n-1

        public AbstractMagic(int n) {
            Init(n);
        }
        protected virtual void Init(int n){
            this.top = n - 1;
            this.mabang = new int[n, n];//생성, 초기화
        }
        public abstract void Make();

        //마방진 완성?
        public bool IsCheck(){
            bool isC = true;
            int count = top + 1;
            int[] ic = new int[2 * count + 2];
            for (int k = 0; k < count; k++){
                ic[k] = SumRow(k);         //한 행의 합
                ic[k + count] = SumCol(k); //한 열의 합
            }//
            ic[2 * count] = SumDiago();    //대각선 합 
            ic[2 * count + 1] = SumAntiDiago();//역 대각선 합
            //2 * count + 2개 값이 모두 동일한가?
            for (int i = 1; i < ic.Length; i++){
                if (ic[0] != ic[i]){
                    isC = false;
                    break;
                }
            }
            return isC;
        }//
        //한 행의 합
        public int SumRow(int row){
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++){
                total += this.mabang[row, i];
            }
            return total;
        }
        //한 열의 합
        public int SumCol(int col){
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++){
                total += this.mabang[i, col];
            }
            return total;
        }
        //대각선의 합
        public int SumDiago(){ //대각선
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++){
                total += this.mabang[i, i];
            }
            return total;
        }
        //역대각선의 합
        public int SumAntiDiago(){//역대각선
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++){
                total += this.mabang[i, count - i - 1];
            }
            return total;
        }
        //마방진 출력
        public void Print(){
            int count = top + 1;
            for (int i = 0; i < count; i++){
                for (int j = 0; j < count; j++){
                    Console.Write("{0}\t", mabang[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Successs?  {0}", IsCheck());
        }//Print
        //행열대각선역대각선의 합과 마방진 출력
        public void Prints(){
            int count = top + 1;
            for (int i = 0; i < count; i++){
                for (int j = 0; j < count; j++){
                    Console.Write("\t{0}", mabang[i, j]);
                }
                Console.Write("\tR:{0}\n", SumRow(i));
            }
            Console.Write("A:{0}", SumAntiDiago());
            for (int j = 0; j < count; j++){
                Console.Write("\tC:{0}", SumCol(j));
            }
            Console.Write("\tD:{0}\n", SumDiago());
            Console.WriteLine("Successs?  {0}", IsCheck());
        }//Prints 
    }
}
