using System;
namespace Com.JungBo.Logic
{
    public abstract class AbstractMagic:IMagic
    {
        protected int[,] mabang;//2차원 배열 선언
        protected int top;//n-1

        public AbstractMagic(int n)
        {
            Init(n);
        }


        protected virtual void Init(int n)
        {
            this.top = n - 1;
            this.mabang = new int[n, n];//생성, 초기화
        }

        public void Print()
        {
            int count = top + 1;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write("{0}\t", mabang[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Successs?  {0}",
                                         this.IsCheck());
        }//Print
        public void Prints()
        {
            int count = top + 1;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write("\t{0}", mabang[i, j]);
                }
                Console.Write("\tR:{0}\n", SumRow(i));
            }
            Console.Write("A:{0}", SumAntiDiago());
            for (int j = 0; j < count; j++)
            {

                Console.Write("\tC:{0}", SumCol(j));

            }
            Console.Write("\tD:{0}\n", SumDiago());

            Console.WriteLine("Successs?  {0}",
                                         this.IsCheck());
        }//Prints
        public bool IsCheck()
        {
            bool isC = true;
            int count = top + 1;
            int[] ic = new int[2 * count + 2];
            for (int k = 0; k < count; k++)
            {
                ic[k] = SumRow(k);
                ic[k + count] = SumCol(k);
            }//
            ic[2 * count] = SumDiago();
            ic[2 * count + 1] = SumAntiDiago();

            for (int i = 1; i < ic.Length; i++)
            {
                if (ic[0] != ic[i])
                {
                    isC = false;
                    break;
                }
            }
            return isC;
        }//
        public int SumRow(int row)
        {
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[row, i];
            }
            return total;
        }
        public int SumCol(int col)
        {
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[i, col];
            }
            return total;
        }
        public int SumDiago()
        { //대각선
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[i, i];
            }
            return total;
        }
        public int SumAntiDiago()
        {//역대각선
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[i, count - i - 1];
            }
            return total;
        }
        public abstract void Make();

        public virtual void PositionPrint() {
            int count = this.top + 1;
           
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    string s = string.Format("({0},{1})\t",i,j);
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }

    }
}
