using System;
namespace Com.JungBo.Logic{
 public class FourMagicSquare{
    private int[ , ] mabang;//2차원 배열 선언
    private int top;//n-1
    public FourMagicSquare() :this(4){ }//기본생성자
    public FourMagicSquare(int n){
        this.Init(n);
    }//생성자
//마방진 row의 수를 받아서 rowXrow 2차원 배열을 생성한다.
    public void Init(int n) {
        this.top = n - 1;
        this.mabang = new int[n, n];//생성, 초기화
    }
    public void Make() {
        LeftToRight();
        Reverse();
        //Change();
    }//Make
    //nXn일때 1부터 n*n까지 1씩 증가하며 16칸을 채운다.
    private void LeftToRight() {
        int count = this.top + 1;
        for (int i = 0; i < count; i++){
            for (int j = 0; j < count; j++){
                this.mabang[i, j] = i * count + j + 1;
            }
        }
    }
    //nXn일때  n*n 부터 1까지 1씩 감소하며 
    //조건에 알맍은 칸을 채운다.
    private void Reverse() {
        int count = this.top + 1;
        for (int i = 0; i < count; i++){
            for (int j = 0; j < count; j++){
                if ((i >= 0 && i < count / 4) ||
                    (i >= count / 4 * 3 && i < count)){
                    if (j >= count / 4 && j < count / 4 * 3){
                        this.mabang[i, j] =
                            count * count - (i * count + j);
                    }
                }
                else {
                    if ((j >= 0 && j < count / 4) ||
                     (j >= count / 4 * 3 && j < count)) {
                         this.mabang[i, j] =
                                count * count - (i * count + j);
                    }
                }
            }
        }
    }//
    public void Change() {
        int count = this.top + 1;
        for (int i = 0; i < count; i++){
            for (int j = 0; j < count/2; j++){
                if ((i >= 0 && i < count / 4) ||
                    (i >= count / 4 * 3 && i < count)){
                    if (j >= count / 4 && j < count / 4 * 3){
                        int temp = this.mabang[i, j];
                        this.mabang[i, j] =
                            this.mabang[top - i, top - j];
                        this.mabang[top - i, top - j] = temp;
                            
                    }
                }
                else{
                    if ((j >= 0 && j < count / 4) ||
                     (j >= count / 4 * 3 && j < count)){
                        int temp = this.mabang[i, j];
                        this.mabang[i, j] =
                            this.mabang[top - i, top - j];
                        this.mabang[top - i, top - j] = temp;
                    }
                }
            }
        }
    }

    public bool IsCheck(){
        bool isC = true;
        int count = top + 1;
        int[] ic = new int[2 * count + 2];
        for (int k = 0; k < count; k++){
            ic[k] = SumRow(k);
            ic[k + count] = SumCol(k);
        }//
        ic[2 * count] = SumDiago();
        ic[2 * count + 1] = SumAntiDiago();
        for (int i = 1; i < ic.Length; i++){
            if (ic[0] != ic[i]){
                isC = false;
                break;
            }
        }
        return isC;
    }//
    public int SumRow(int row)
    {
        int count = this.top + 1;
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += this.mabang[row, i];
        }
        return total;
    }
    public int SumCol(int col)
    {
        int count = this.top + 1;
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += this.mabang[i, col];
        }
        return total;
    }
    public int SumDiago()
    { //대각선
        int count = this.top + 1;
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += this.mabang[i, i];
        }
        return total;
    }
    public int SumAntiDiago()
    {//역대각선
        int count = this.top + 1;
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += this.mabang[i, count - i - 1];
        }
        return total;
    }
    public void Print()
    {
        int count = top + 1;

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                Console.Write("{0}\t", mabang[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("Successs?  {0}",
                                     this.IsCheck());
    }//Print
    public void Prints()
    {
        int count = top + 1;

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                Console.Write("\t{0}", mabang[i, j]);
            }
            Console.Write("\tR:{0}\n", SumRow(i));
        }
        Console.Write("A:{0}", SumAntiDiago());
        for (int j = 0; j < count; j++)
        {

            Console.Write("\tC:{0}", SumCol(j));

        }
        Console.Write("\tD:{0}\n", SumDiago());

        Console.WriteLine("Successs?  {0}",
                                     this.IsCheck());
    }//Prints
 }
}
