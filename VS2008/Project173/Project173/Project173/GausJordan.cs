using System;
namespace Com.JungBo.Logic{
    //x + 2y + 4z = 11
    //2x + 5y + 2z = 3
    //4x - y + z = 8
    public class GausJordan {
        double[,] a ={{ 1, 2, 4 },{ 2, 5, 2 },{4, -1,1}};
        double[] y ={ 11,3,8 };
        private int n;
        public GausJordan(){
            n = a.GetLength(0);
        }//
        public void GetGaus(){
            this.PrintGaus(); 
            double delta=0;
            for (int k = 0; k < n; k++){
                for (int i = 0; i < n; i++){
                    delta = a[i, k] / a[k, k];
                    for (int j = k; j < n; j++){
                        if (i != k && j == k){
                            a[i, j] = 0.0;
                        }
                        else if (i != k && j > k){
                            a[i, j] -= delta * a[k, j];
                        }
                    }
                    if (i != k){
                        y[i] -= delta * y[k];
                    }
                }
                Console.WriteLine();
                this.PrintGaus();
            }
            Console.WriteLine();
            for (int k = 0; k < n; k++){
             Console.WriteLine("X{0} = {1}",(k+1),y[k]/a[k,k]);
            }
        }//
        private void PrintGaus() {
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n; j++){
                    Console.Write("{0} X{1}\t",
                        a[i, j]>=0?a[i,j].ToString():
                        string.Format("({0})",a[i,j]),(j+1));
                    if (j != n - 1){
                        Console.Write(" +\t");
                    }                    
                }
                Console.Write(" = ");
                Console.WriteLine(y[i]);
            }
        }//
    }
}
