using System;
namespace Com.JungBo.Logic
{
    public class FourMagicSquare : AbstractMagic{

        public FourMagicSquare(int n):base(n) { }
        public FourMagicSquare() : this(4) { }

        public  override void Make()
        {
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
        /// 4X4�϶� 16���� 1���� 1�� �����ϸ� ���ǿ� �ː��� ĭ�� ä���.
        /// ���� �������
        /// nXn�϶�  n*n ���� 1���� 1�� �����ϸ� ���ǿ� �ː��� ĭ�� ä���.
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
