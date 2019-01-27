using System;
namespace Com.JunBo.Logic{
    public abstract class AbstractMagic  {

        protected int[,] mabang;//2���� �迭 ����

        public AbstractMagic(int n){
            this.mabang = new int[n, n];//����, �ʱ�ȭ
        }//������
        
        //�߻�޼���
        public abstract void Make();

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
    }
}
