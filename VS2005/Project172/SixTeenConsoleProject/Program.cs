using System;
namespace Com.JungBo.Logic{
    public class Program{
        public static void Main(string[] args){
            //row+inversion+location=> Ȧ���� ����
            int row = 4;
            Lotto lot = new Lotto(row * row);
            lot.Remake();
            //������ �迭 �����(���� �ٸ� ��)
            int[] n = lot.Ball();
            MatrixTrans<int>.Print(n);
            //2���� �迭�� ��ȯ
            int[,] m = MatrixTrans<int>.Mat1to2(n, row, row);
            MatrixTrans<int>.Print(m);
            SixTeenInvert siv = new SixTeenInvert(m);
            //������ �� �� IVN ���ϱ�
            siv.InvertNumbers();
            Console.WriteLine("IVN : {0}",siv.InverNum);
            //0�̳� 16�� �ִ� ��ġ
            Console.WriteLine("0(16)�� �ִ� ��: {0}",siv.ZeroRow());
            Console.WriteLine("���Ǽ� : {0}",row);
            if (!siv.IsPossible()){
                Console.WriteLine("�ϼ��� �Ұ����� �����Դϴ�.");
            }
            else {
                Console.WriteLine("�ϼ��� ������ �����Դϴ�.");
            }
        }
    }
}
