using System;
namespace Com.JunBo.Logic{
    public abstract class AbstractMagic : IMagic {

        protected int[,] mabang;//2���� �迭 ����

        public AbstractMagic(int n){
            this.mabang = new int[n, n];//����, �ʱ�ȭ
        }//������
        
        //�߻�޼���
        public abstract void Make();

        
        public virtual void Print(){
            for (int i = 0; i < mabang.GetLength(0); i++){
                for (int j = 0; j < mabang.GetLength(1); j++){
                    Console.Write("{0}\t", mabang[i, j]);
                }
                //row�� �� ���
                Console.Write("R:{0}\n", SumRow(i));
            }
        }//Print
        //row�� ���� ���Ѵ�.
        protected int SumRow(int row){
            int count = mabang.GetLength(1);
            int total = 0;
            for (int i = 0; i < count; i++){
                //row�� ���Ծ��� col�� ���Ѵ�.
                total += this.mabang[row, i];
            }
            return total;
        }//SumRow
        protected int SumCol(int col){
            int count = mabang.GetLength(0);
            int total = 0;
            for (int i = 0; i < count; i++){
                total += this.mabang[i, col];
            }
            return total;
        }//
    }
}
