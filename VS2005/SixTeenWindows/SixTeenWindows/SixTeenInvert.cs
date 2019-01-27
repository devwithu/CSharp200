using System;
using System.Collections.Generic;
using System.Text;
using Matrix2to1;
namespace Win16Tiles
{
    public class SixTeenInvert
    {
        private int inverNum = 0;

        public int InverNum
        {
            get { return inverNum; }
        }
        private int[,] sti;
        public SixTeenInvert(int[,] sti) {
            this.sti = this.DeepCopy(sti);
        }//

        public int[,] DeepCopy(int[,] sti) {
            int row = sti.GetLength(0);
            int col = sti.GetLength(1);
            int[,] m = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    m[i, j] = sti[i, j];
                }
            }
            return m;
        }//


        public void InvertNumbers() {
            int[] m = Matrix2to1.MatrixTrans.Mat2to1(sti);
            int num = m.GetLength(0);
            for (int i = 0; i < num-1; i++)
            {
                for (int j = i+1; j < num; j++)
                {
                    if(m[j]!=0 && m[i]>m[j]){
                        inverNum++;
                    }
                }
            }
        }

        public int ZeroRow()
        {
            int locate = 0;
            int col = sti.GetLength(1);
            int[] m = Matrix2to1.MatrixTrans.Mat2to1(sti);
            int num = m.GetLength(0);
            for (int i = 0; i < num ; i++)
            {
               if(m[i]==0){
                   locate = i / col;
                   break;
               }
            }
            return locate;
        }//

    }
}
