using System;
namespace Com.JungBo.Logic{
 public class MatrixD{
    private double[,] matrxsA;//A
    public double[,]  MatrxsA{
        get {
      return MatrixTrans<double>.Mat2Clone(matrxsA);//��������
        }
    }
    public MatrixD(double[,] mats){
        SetMatrxsA(mats);
    }
    public MatrixD(){}
    //���� ������-> ���� ���縦 ���� ���
    public MatrixD(MatrixD md)  {
        matrxsA = md.MatrxsA;//������Ƽ�� �̿��� ���� ����
    }
    public void SetMatrxsA(double[,] mats){
        //2���� �迭�� 2�����迭�� ���� ����
        matrxsA = MatrixTrans<double>.Mat2Clone(mats);//��������
    }
    //����� ���ϱ�
    public static MatrixD operator ~(MatrixD md){
        //���� 174�� ����� ���ϱ�
        return new MatrixD(Make(md));
    }
    //�� ����� ��
    public static MatrixD operator *(MatrixD md1,MatrixD md2){
        return new MatrixD(MatrixMulti(md1.MatrxsA, md2.MatrxsA));
    }
    //�� ����� ����
    public static MatrixD operator +(MatrixD md1, MatrixD md2){
        return new MatrixD(MatrixAdd(md1.MatrxsA, md2.MatrxsA));
    }
    private static double[,] MatrixMulti(double[,] a, double[,] b){
        int mRow = a.GetLength(0);
        int mCol = a.GetLength(1);
        int nRow = b.GetLength(0);
        int nCol = b.GetLength(1);
        double[,] c = new double[mRow, nCol];
        for (int i = 0; i < mRow; i++)
        {
            for (int j = 0; j < nCol; j++)
            {
                c[i, j] = 0.0;
                for (int k = 0; k < nRow; k++)
                {
                    //Cij=Sigma[Aik x BKj]
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return c;
    }//
    private static double[,] MatrixAdd(double[,] a, double[,] b){
        int mRow = a.GetLength(0);
        int mCol = a.GetLength(1);
        double[,] c = new double[mRow, mCol];
        for (int i = 0; i < mRow; i++){
            for (int j = 0; j < mCol; j++){
                c[i, j] = a[i, j] + b[i, j];
            }
        }
        return c;
    }//
    public void PrintMatrxsA(){
        int row = matrxsA.GetLength(0);
        int col = matrxsA.GetLength(1);
        for (int i = 0; i < row; i++){
            for (int j = 0; j < col; j++){
                System.Console.Write("{0}\t", matrxsA[i, j]);
            }
            System.Console.WriteLine();
        }
    }//
    public int RowNum {
        get { return this.matrxsA.GetLength(0); }
    }
    public int ColNum{
        get { return this.matrxsA.GetLength(1); }
    }
    //���� 174
    private static double[,]  Make(MatrixD md){
        double[,] matrxAS = md.MatrxsA;
        int rowAS = matrxAS.GetLength(0);//������ ��ĸ� ������� ���� �� �ִ�.
        int colAS = matrxAS.GetLength(1);
        double[,] matrx=new double[rowAS,2*colAS];
        int row = matrx.GetLength(0);//������ ��ĸ� ������� ���� �� �ִ�.
        int col = matrx.GetLength(1);
        for (int i = 0; i < rowAS; i++){
            //A ����
            for (int j = 0; j < colAS; j++){
                matrx[i, j] = matrxAS[i, j];
            }
            //E ����
            matrx[i, i + colAS] = 1;
        }
        for (int k = 0; k < row; k++){
            double max = 0.0;//�࿡�� ���� ū ���� ���ϱ�
            int pivotRow = k;//���� ū ���� �ִ� ������ġ ã��
            for (int j = k; j < row; j++){
           //x���� pivot�� �����ϸ� y�� ���� pivot,�״��� z�� ����
                //�׷��Ƿ� Į���� �ٲ㰡�� Ȯ���Ѵ�.
                double tempMax = Math.Abs(matrx[j, k]);
                if (max < tempMax){
                    max = tempMax;
                    pivotRow = j;//�࿡�� ���� ū ���� ã�� ���� ��ġ����
                }
            }
            if (k != pivotRow){
            //�Ǻ���� ������ġ�� ���ٸ� �ٲ��� �ʴ´�.
                //������ �Ǻ��ٰ� �ٲ۴�.
                for (int j = 0; j < col; j++){//��� ���� �ٲ�� �Ѵ�.
                    Swap(ref matrx[k, j], ref matrx[pivotRow, j]);
                }
            }
            double pivot = matrx[k, k];//�Ǻ��� (0,0),(1,1),(2,2)�� �ִ�.
            for (int j = k; j < col; j++){
                matrx[k, j] /= pivot;//�࿡�� ���� ū ���� 1�� �ٲ۴�.
            }
            for (int i = 0; i < row; i++){
                if (i != k){
                    double delta = matrx[i, k];
                    for (int j = k; j < col; j++){
                        matrx[i, j] -= delta * matrx[k, j];
                    }
                }
            }
        }
        //E--> A_1�� ���� �� �⺻��ķ� ����
        for (int i = 0; i < rowAS; i++){
            for (int j = 0; j < colAS; j++){
                matrxAS[i, j] = matrx[i, j + rowAS];
            }
        }
        return matrxAS;
    }
    private static void Swap(ref double a, ref double b) {
        double temp = a;
        a = b;
        b = temp;
    }//
 }
}
