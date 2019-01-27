using System;
namespace Com.JungBo.Logic{
    public class Program{
        public static void Main(string[] args){
            //row+inversion+location=> 홀수면 가능
            int row = 4;
            Lotto lot = new Lotto(row * row);
            lot.Remake();
            //일차원 배열 만들기(서로 다른 수)
            int[] n = lot.Ball();
            MatrixTrans<int>.Print(n);
            //2차원 배열로 변환
            int[,] m = MatrixTrans<int>.Mat1to2(n, row, row);
            MatrixTrans<int>.Print(m);
            SixTeenInvert siv = new SixTeenInvert(m);
            //뒤집어 진 수 IVN 구하기
            siv.InvertNumbers();
            Console.WriteLine("IVN : {0}",siv.InverNum);
            //0이나 16이 있는 위치
            Console.WriteLine("0(16)이 있는 행: {0}",siv.ZeroRow());
            Console.WriteLine("행의수 : {0}",row);
            if (!siv.IsPossible()){
                Console.WriteLine("완성이 불가능한 퍼즐입니다.");
            }
            else {
                Console.WriteLine("완성이 가능한 퍼즐입니다.");
            }
        }
    }
}
