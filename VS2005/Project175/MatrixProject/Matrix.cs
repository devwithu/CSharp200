using System;
namespace Com.JungBo.Logic{
 public class Matrix{
    private double[,] matrxsA;//A
    private double[,] reversA;//A_1
    private double[,] calculs;//A|E|Y
    private double[,] matrxsY;//Y

    public Matrix(int n, int m){
        matrxsA = new double[n, n];
        reversA = new double[n, n];
        calculs = new double[n, 2 * n + m];
        matrxsY = new double[n, m];
    }
    public Matrix(int n): this(n, 1){}
    //깊은복사-->일대일
    public void SetMatrxsA(double[,] mats){
        matrxsA = MatrixTrans<double>.Mat2Clone(mats);
    }
    public void SetMatrxsY(double[,] mats){
       matrxsY = MatrixTrans<double>.Mat2Clone(mats);
    }
    public void SetMatrixs(double[,] matA, double[,] matY){
        this.SetMatrxsA(matA);//A에 깊은 복사
        this.SetMatrxsY(matY);//Y에 깊은 복사
        //------------------------------------
        int row = calculs.GetLength(0);
        int col = calculs.GetLength(1);
        int m = matrxsY.GetLength(1);
        //A | E | Y 세팅
        for (int i = 0; i < row; i++) {
            //A 세팅
            for (int j = 0; j < row; j++){
                calculs[i, j] = matrxsA[i, j];
            }
            //E 세팅 대각선 1넣기
            calculs[i, i + row] = 1;
            //Y 세팅
            for (int k = 0; k < m; k++){
                calculs[i, k + 2*row] = matrxsY[i,k];
            }
        }
    }
    public void Make() {
        //정방형 행렬만 역행렬을 구할 수 있다.
        int row = calculs.GetLength(0);
        int col = calculs.GetLength(1);
        for (int k = 0; k < row; k++){
            double max = 0.0;//행에서 가장 큰 값을 구하기
            int pivotRow = k;//가장 큰 값이 있는 행의위치 찾기
            for (int j = k; j < row; j++){
            //x에서 pivot을 선택하면 y에 대한 pivot,그다음 z
            //그러므로 칼럼을 바꿔가며 확인한다.
                double tempMax=Math.Abs(calculs[j,k]);
                if (max < tempMax){
                    max = tempMax;
                    //행에서 가장 큰 값을 찾아 행의 위치저장
                    pivotRow = j;
                }
            }
            //피봇행과 현재위치가 같다면 바꾸지 않는다.
            if(k!=pivotRow){
                Console.WriteLine("{0}행을 피봇이 있는 {1}행과 바꾼다.",
                    k + 1, pivotRow+1);
                PrintCalculs();
                Console.WriteLine("-----------------------");
                //한줄을 피봇줄과 바꾼다.
                for (int j = 0; j < col; j++){//모든 열을 바꿔야 한다.
                    Swap(ref calculs[k, j], ref calculs[pivotRow, j]);
                }
            }
            double pivot  = calculs[k, k];//피봇은 (0,0),(1,1),(2,2)에 있다.
            PrintCalculs();
            Console.WriteLine("{0}행 {0}렬을 1로 만들기 위해 피봇"+
              " {1}(으)로 나누고 그 행도 모두 나눈다.", (k + 1), pivot);
            Console.WriteLine("------------------------------");
            for (int j = k; j < col; j++){
                calculs[k, j] /= pivot;//행에서 가장 큰 값을 1로 바꾼다.
            }
            PrintCalculs();
            Console.WriteLine("-------------------");
            for (int i = 0; i < row; i++){
                if (i != k){
                    double delta = calculs[i, k];
                    Console.WriteLine("{0}행에 {1}를 곱하여 {2}행을 뺀다.",
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
        MakeMatrxsY();
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
    private void MakeMatrxsY(){
        int row = matrxsY.GetLength(0);
        int col = matrxsY.GetLength(1);
        for (int i = 0; i < row; i++){
            for (int j = 0; j < col; j++){
                matrxsY[i, j] = calculs[i, j + 2 * row];
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
