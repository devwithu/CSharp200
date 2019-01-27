using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic
{
    public class MatrixD
    {
        private double[,] matrxsA;//A

        public double[,]  MatrxsA
        {
            get {
                return MatrixTrans<double>.Mat2Clone(matrxsA);//깊은복사
            }
        }
        public MatrixD(double[,] mats)
        {
            SetMatrxsA(mats);
        }
        public MatrixD()
        {
        }
        //복사 생성자-> 깊은 복사를 위한 방법
        public MatrixD(MatrixD md)  
        {
            matrxsA = md.MatrxsA;//프로퍼티를 이용한 깊은 복사
        }
       
        public void SetMatrxsA(double[,] mats)
        {
            //2차원 배열을 2차원배열로 깊은 복사
            matrxsA = MatrixTrans<double>.Mat2Clone(mats);//깊은복사
        }

        //역행렬 구하기
        public static MatrixD operator ~(MatrixD md)
        {
            return new MatrixD(Make(md));
        }
        //두 행렬의 곱
        public static MatrixD operator *(MatrixD md1,MatrixD md2)
        {
            return new MatrixD(MatrixMulti(md1.MatrxsA, md2.MatrxsA));
        }

        public void PrintMatrxsA()
        {
            int row = matrxsA.GetLength(0);
            int col = matrxsA.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    System.Console.Write("{0}\t", matrxsA[i, j]);
                }
                System.Console.WriteLine();
            }
        }//
        public int RowNum {
            get { return this.matrxsA.GetLength(0); }
        }
        public int ColNum
        {
            get { return this.matrxsA.GetLength(1); }
        }

        private static double[,]  Make(MatrixD md)
        {
            double[,] matrxAS = md.MatrxsA;
            int rowAS = matrxAS.GetLength(0);//정방형 행렬만 역행렬을 구할 수 있다.
            int colAS = matrxAS.GetLength(1);

            double[,] matrx=new double[rowAS,2*colAS];

            int row = matrx.GetLength(0);//정방형 행렬만 역행렬을 구할 수 있다.
            int col = matrx.GetLength(1);

            for (int i = 0; i < rowAS; i++)
            {
                //A 세팅
                for (int j = 0; j < colAS; j++)
                {
                    matrx[i, j] = matrxAS[i, j];

                }
                //E 세팅
                matrx[i, i + colAS] = 1;
            }

            for (int k = 0; k < row; k++)
            {
                double max = 0.0;//행에서 가장 큰 값을 구하기
                int pivotRow = k;//가장 큰 값이 있는 행의위치 찾기

                for (int j = k; j < row; j++)
                {//x에서 pivot을 선택하면 y에 대한 pivot,그다음 z에 대한
                    //그러므로 칼럼을 바꿔가며 확인한다.
                    double tempMax = Math.Abs(matrx[j, k]);
                    if (max < tempMax)
                    {
                        max = tempMax;
                        pivotRow = j;//행에서 가장 큰 값을 찾아 행의 위치저장
                    }
                }
                if (k != pivotRow)
                {//피봇행과 현재위치가 같다면 바꾸지 않는다.


                    //한줄을 피봇줄과 바꾼다.
                    for (int j = 0; j < col; j++)//모든 열을 바꿔야 한다.
                    {
                        Swap(ref matrx[k, j], ref matrx[pivotRow, j]);
                    }
                }

                double pivot = matrx[k, k];//피봇은 (0,0),(1,1),(2,2)에 있다.

                for (int j = k; j < col; j++)
                {
                    matrx[k, j] /= pivot;//행에서 가장 큰 값을 1로 바꾼다.
                }

                for (int i = 0; i < row; i++)
                {
                    if (i != k)
                    {
                        double delta = matrx[i, k];

                        for (int j = k; j < col; j++)
                        {
                            matrx[i, j] -= delta * matrx[k, j];
                        }
                    }
                }
            }

            //E--> A_1를 만든 후 기본행렬로 저장
            for (int i = 0; i < rowAS; i++)
            {
                for (int j = 0; j < colAS; j++)
                {
                    matrxAS[i, j] = matrx[i, j + rowAS];
                }
            }
            return matrxAS;
        }

        private static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }//


        private static double[,] MatrixMulti(double[,] a, double[,] b)
        {
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
        }
        private static double[,] MatrixAdd(double[,] a, double[,] b)
        {
            int mRow = a.GetLength(0);
            int mCol = a.GetLength(1);
            double[,] c = new double[mRow, mCol];
            for (int i = 0; i < mRow; i++)
            {
                for (int j = 0; j < mCol; j++)
                {
                    c[i,j]=a[i,j]+b[i,j];
                }
            }
            return c;
        }
    }
}
