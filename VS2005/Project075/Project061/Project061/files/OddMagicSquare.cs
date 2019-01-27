using System;
namespace Com.JunBo.Logic{
    //2�����迭
    public class OddMagicSquare{
        private int[,] mabang;//2���� �迭 ����

        public OddMagicSquare(int n) {
            this.mabang = new int[n, n];//����, �ʱ�ȭ
        }//������

        public void Make() {
            int top = mabang.GetLength(0)-1;  //���� ��
            int x = 0;        //����
            int y = top / 2;  //�߾�
            mabang[x, y] = 1;
            for (int i = 2; i <= (top + 1) * (top+1); i++){
                int tempX = x;
                int tempY = y;

                if (x - 1 < 0){  //����
                    x = top;     //�Ʒ���
                }
                else {
                    x--;
                }
                if (y - 1 < 0){   //���ʺ�
                    y = top;      //������
                }
                else{
                    y--;
                }
                //�̹� �����ϴ°�?
                if(mabang[x,y]!=0){
                    x = tempX + 1;   //����ġ���� ��ĭ�Ʒ�
                    y = tempY;       //����ġ
                }
                mabang[x, y] = i;
            }

        }//Make
        //row�� ���� ���Ѵ�.������ üũ���� �Ϻ�
        private int SumRow(int row){
            int count = mabang.GetLength(1);
            int total = 0;
            for (int i = 0; i < count; i++){
                //row�� ���Ծ��� col�� ���Ѵ�.
                total += this.mabang[row, i];
            }
            return total;
        }
        //�������� ����Ѵ�.
        public void Print(){
            for (int i = 0; i < mabang.GetLength(0); i++){
                for (int j = 0; j < mabang.GetLength(1); j++){
                    Console.Write("{0}\t", mabang[i, j]);
                }
                //row�� �� ���
                Console.Write("R:{0}\n",SumRow(i));
            }
        }//Print
    }//class
}//namespace
