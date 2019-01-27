using System;
namespace Com.JungBo.Logic{
    public class FourMagicSquare : AbstractMagic{

        public FourMagicSquare(int n):base(n) { }
        public FourMagicSquare() : this(4) { }

        public  override void Make()
        {
            LeftToRight();
            //Reverse();
            Change();
        }//Make
        //접근제한자 -->private
        /// <summary>
        /// 4X4일때 1부터 16까지 1씩 증가하며 16칸을 채운다.
        /// 같은 방법으로
        /// nXn일때 1부터 n*n까지 1씩 증가하며 16칸을 채운다.
        /// </summary>
        private void LeftToRight()
        {
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
        /// 4X4일때 16부터 1까지 1씩 감소하며 조건에 알맍은 칸을 채운다.
        /// 같은 방법으로
        /// nXn일때  n*n 부터 1까지 1씩 감소하며 조건에 알맍은 칸을 채운다.
        /// </summary>
        private void Reverse()
        {
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
                    else
                    {
                        if ((j >= 0 && j < count / 4) ||
                         (j >= count / 4 * 3 && j < count))
                        {
                            this.mabang[i, j] =
                                   count * count - (i * count + j);
                        }
                    }

                }
            }
        }//

        public void Change()
        {
            int count = this.top + 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count / 2; j++)
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



    }
}
