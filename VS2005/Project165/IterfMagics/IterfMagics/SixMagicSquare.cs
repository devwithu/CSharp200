using System;
namespace Com.JungBo.Logic{
    public class SixMagicSquare : AbstractMagic
    {

        //A,B,C,D 배열
        private int[, ,] tm;

        public SixMagicSquare(int n) :base(n){ }
        public SixMagicSquare() : this(6) { }
        protected override void Init(int n)
        {
            this.top = n - 1;
            this.mabang = new int[n, n];//생성, 초기화
            this.tm = new int[4, n / 2, n / 2];
        }
        public override void Make()
        {
            MakeA();
            MakeB();
            MakeCD();
            this.Copy();
        }
        private void MakeA()
        {
            int count = this.top + 1;
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < count / 4; j++)
                {
                    if (i == count / 4)
                    {
                        this.tm[0, i, j + 1] = 3;
                    }
                    else
                    {
                        this.tm[0, i, j] = 3;
                    }
                }
            }
        }
        private void MakeB()
        {
            int count = this.top + 1;
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < count / 2; j++)
                {
                    this.tm[1, i, j] = 1;
                }
            }
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < count / 2 - (count / 4 - 1); j++)
                {
                    this.tm[1, i, j] = 2;
                }
            }
        }

        private void MakeCD()
        {
            int count = this.top + 1;
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < count / 2; j++)
                {
                    if (this.tm[0, i, j] == 0)
                    {
                        this.tm[2, i, j] = 3;
                    }
                    else if (this.tm[0, i, j] == 3)
                    {
                        this.tm[2, i, j] = 0;
                    }

                    if (this.tm[1, i, j] == 1)
                    {
                        this.tm[3, i, j] = 2;
                    }
                    else if (this.tm[1, i, j] == 2)
                    {
                        this.tm[3, i, j] = 1;
                    }
                }
            }
        }
        private void Copy()
        {
            int count = this.top + 1;
            int multi = (count / 2) * (count / 2);
            OddMagicSquare odd =
                new OddMagicSquare(count / 2);
            odd.Make();//홀수 마방진 완성
            int[,] oddM = odd.Mabang;//Property
            for (int i = 0; i < count / 2; i++)
            {
                for (int j = 0; j < count / 2; j++)
                {
                    this.mabang[i, j] =
                        multi * this.tm[0, i, j] + oddM[i, j];
                    this.mabang[i, j + count / 2] =
                        multi * this.tm[1, i, j] + oddM[i, j];
                    this.mabang[i + count / 2, j] =
                        multi * this.tm[2, i, j] + oddM[i, j];
                    this.mabang[i + count / 2, j + count / 2] = multi * this.tm[3, i, j] + oddM[i, j];
                }
            }
        }

        
    }
}
