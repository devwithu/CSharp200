using System;
namespace Com.JungBo.Logic {
    //2차원 배열
    public class TetrisRotate{
        int[,] m =  { { 1, 1, 1, 1,1,0 }, { 0, 0, 0, 0,1, 0 },
                { 0, 0, 0, 0,1, 0 },{0, 0, 0, 0,1, 0  },
                { 0, 0, 0, 0,1, 0  },{ 0, 0, 0, 0,1, 0  }};

        public void Print(){
            int row = m.GetLength(0);//row
            int col = m.GetLength(1);//col

            for (int i = 0; i < row; i++){
                for (int j = 0; j < col; j++){
                    if (m[i, j] == 1){
                        Console.Write("■");
                    }
                    else{
                        Console.Write("□");
                    }
                }
                Console.WriteLine();
            }
        }
    }//class
}
