using System;
namespace Com.JungBo.Logic
{
    public class FourMagicSquare
    {
        private int[ , ] mabang;//2���� �迭 ����
        private int top;//n-1


        public FourMagicSquare() :this(4){ }//�⺻������
        public FourMagicSquare(int n)
        {
            this.Init(n);
        }//������
        /// <summary>
        /// ������ row�� ���� �޾Ƽ� rowXrow 2���� �迭�� �����Ѵ�.
        /// </summary>
        /// <param name="n">������ row�� ��</param>
        public void Init(int n) {
            this.top = n - 1;
            this.mabang = new int[n, n];//����, �ʱ�ȭ
            //int row = this.mabang.GetLength(0);
            //int col = this.mabang.GetLength(1);
        }

        public void Make() {
            LeftToRight();
            //Reverse();
            Change();
        }//Make
        //���������� -->private
        /// <summary>
        /// 4X4�϶� 1���� 16���� 1�� �����ϸ� 16ĭ�� ä���.
        /// ���� �������
        /// nXn�϶� 1���� n*n���� 1�� �����ϸ� 16ĭ�� ä���.
        /// </summary>
        private void LeftToRight() {
            int count = this.top + 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    this.mabang[i, j] = i * count + j + 1;
                }
            }
        }
        /// <summary>
        /// 4X4�϶� 16���� 1���� 1�� �����ϸ� ���ǿ� �ː��� ĭ�� ä���.
        /// ���� �������
        /// nXn�϶�  n*n ���� 1���� 1�� �����ϸ� ���ǿ� �ː��� ĭ�� ä���.
        /// </summary>
        private void Reverse() {
            int count = this.top + 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {

                    if ((i >= 0 && i < count / 4) ||
                        (i >= count / 4 * 3 && i < count))
                    {
                        if (j >= count / 4 && j < count / 4 * 3)
                        {
                            this.mabang[i, j] =
                                count * count - (i * count + j);
                        }
                    }
                    else {
                        if ((j >= 0 && j < count / 4) ||
                         (j >= count / 4 * 3 && j < count)) {
                             this.mabang[i, j] =
                                    count * count - (i * count + j);
                        }
                    }

                }
            }
        }//

        public void Change() {
            int count = this.top + 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count/2; j++)
                {

                    if ((i >= 0 && i < count / 4) ||
                        (i >= count / 4 * 3 && i < count))
                    {
                        if (j >= count / 4 && j < count / 4 * 3)
                        {
                            int temp = this.mabang[i, j];
                            this.mabang[i, j] =
                                this.mabang[top - i, top - j];
                            this.mabang[top - i, top - j] = temp;
                                
                        }
                    }
                    else
                    {
                        if ((j >= 0 && j < count / 4) ||
                         (j >= count / 4 * 3 && j < count))
                        {
                            int temp = this.mabang[i, j];
                            this.mabang[i, j] =
                                this.mabang[top - i, top - j];
                            this.mabang[top - i, top - j] = temp;
                        }
                    }

                }
            }
        }

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
        { //�밢��
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[i, i];
            }
            return total;
        }
        public int SumAntiDiago()
        {//���밢��
            int count = this.top + 1;
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                total += this.mabang[i, count - i - 1];
            }
            return total;
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
    }
}
