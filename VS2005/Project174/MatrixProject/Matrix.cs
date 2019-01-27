using System;
namespace Com.JungBo.Logic{
 public class Matrix{
private double[,] matrxsA;//A
private double[,] reversA;//A_1
private double[,] calculs;//A|E|Y
private double[,] matrxsY;//Y
private double[,] reversY;//A_1Y
public Matrix(int n, int m){
    matrxsA = new double[n, n];
    reversA = new double[n, n];
    calculs = new double[n, 2 * n + m];
    matrxsY = new double[n, m];
    reversY = new double[n, m];
}
public Matrix(int n): this(n, 1){}
//��������-->�ϴ���
public void SetMatrxsA(double[,] mats){
    matrxsA = MatrixTrans<double>.Mat2Clone(mats);
}
public void SetMatrxsY(double[,] mats){
   matrxsY = MatrixTrans<double>.Mat2Clone(mats);
}
public void SetMatrixs(double[,] matA, double[,] matY){
    this.SetMatrxsA(matA);//A�� ���� ����
    this.SetMatrxsY(matY);//Y�� ���� ����
    //------------------------------------
    int row = calculs.GetLength(0);
    int col = calculs.GetLength(1);
    int m = matrxsY.GetLength(1);
    //A | E | Y ����
    for (int i = 0; i < row; i++) {
        //A ����
        for (int j = 0; j < row; j++){
            calculs[i, j] = matrxsA[i, j];
        }
        //E ���� �밢�� 1�ֱ�
        calculs[i, i + row] = 1;
        //Y ����
        for (int k = 0; k < m; k++){
            calculs[i, k + 2*row] = matrxsY[i,k];
        }
    }
}
public void Make() {
    //������ ��ĸ� ������� ���� �� �ִ�.
    int row = calculs.GetLength(0);
    int col = calculs.GetLength(1);
    for (int k = 0; k < row; k++){
        double max = 0.0;//�࿡�� ���� ū ���� ���ϱ�
        int pivotRow = k;//���� ū ���� �ִ� ������ġ ã��
        for (int j = k; j < row; j++){
        //x���� pivot�� �����ϸ� y�� ���� pivot,�״��� z
        //�׷��Ƿ� Į���� �ٲ㰡�� Ȯ���Ѵ�.
            double tempMax=Math.Abs(calculs[j,k]);
            if (max < tempMax){
                max = tempMax;
                //�࿡�� ���� ū ���� ã�� ���� ��ġ����
                pivotRow = j;
            }
        }
        //�Ǻ���� ������ġ�� ���ٸ� �ٲ��� �ʴ´�.
        if(k!=pivotRow){
            Console.WriteLine("{0}���� �Ǻ��� �ִ� {1}��� �ٲ۴�.",
                k + 1, pivotRow+1);
            PrintCalculs();
            Console.WriteLine("-----------------------");
            //������ �Ǻ��ٰ� �ٲ۴�.
            for (int j = 0; j < col; j++){//��� ���� �ٲ�� �Ѵ�.
                Swap(ref calculs[k, j], ref calculs[pivotRow, j]);
            }
        }
        double pivot  = calculs[k, k];//�Ǻ��� (0,0),(1,1),(2,2)�� �ִ�.
        PrintCalculs();
        Console.WriteLine("{0}�� {0}���� 1�� ����� ���� �Ǻ�"+
          " {1}(��)�� ������ �� �൵ ��� ������.", (k + 1), pivot);
        Console.WriteLine("------------------------------");
        for (int j = k; j < col; j++){
            calculs[k, j] /= pivot;//�࿡�� ���� ū ���� 1�� �ٲ۴�.
        }
        PrintCalculs();
        Console.WriteLine("-------------------");
        for (int i = 0; i < row; i++){
            if (i != k){
                double delta = calculs[i, k];
                Console.WriteLine("{0}�࿡ {1}�� ���Ͽ� {2}���� ����.",
                    (k + 1), delta, (i + 1));
                for (int j = k; j < col; j++){
                    calculs[i, j] -=  delta* calculs[k, j];
                }
                PrintCalculs();
                Console.WriteLine("----------------");
            }
        }
    }
    MakeReverse();
    MakeReversY();
}
private void MakeReverse(){
    int row = reversA.GetLength(0);
    int col = reversA.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < col; j++){
            reversA[i, j] = calculs[i, j + row];
        }
    }
}
private void MakeReversY(){
    int row = matrxsY.GetLength(0);
    int col = matrxsY.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < col; j++){
            reversY[i, j] = calculs[i, j + 2 * row];
        }
    }
}
public void Swap(ref double a, ref double b){
    double temp = a;
    a = b;
    b = temp;
}//
public void PrintCalculs(){
    int row = calculs.GetLength(0);
    int col = calculs.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < col; j++){
            System.Console.Write("{0}\t", calculs[i, j]);
        }
        System.Console.WriteLine();
    }
}//
public void PrintReversA(){
    int row = reversA.GetLength(0);
    int col = reversA.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < col; j++){
            System.Console.Write("{0}\t", reversA[i, j]);
        }
        System.Console.WriteLine();
    }
}//
public void PrintMatrxsY(){
    int row = matrxsY.GetLength(0);
    int col = matrxsY.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < col; j++){
            System.Console.Write("{0}\t", matrxsY[i, j]);
        }
        System.Console.WriteLine();
    }
}//
public void PrintReverseY()
{
    int row = matrxsY.GetLength(0);
    int col = matrxsY.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            System.Console.Write("{0}\t", reversY[i, j]);
        }
        System.Console.WriteLine();
    }
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
 }
}
