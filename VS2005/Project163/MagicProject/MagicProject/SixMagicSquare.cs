using System;
namespace Com.JungBo.Logic{
 public class SixMagicSquare{
    private int[,] mabang;//2���� �迭 ����
    private int top;//n-1
    //A,B,C,D �迭
    private int[,,] tm;
    public SixMagicSquare() :this(6){ }//�⺻������
    public SixMagicSquare(int n){
        this.Init(n);
    }//������
    public void Init(int n) {
        this.top = n - 1;
        this.mabang = new int[n, n];//����, �ʱ�ȭ
        this.tm = new int[4, n / 2, n / 2];
    }
    public void Make() {
        MakeA();
        MakeB();
        MakeCD();
        this.Copy();
    }//Make
    //3�� 0�����
    private void MakeA() {
        int count = this.top + 1;
        for (int i = 0; i < count/2; i++){
            for (int j = 0; j < count/4; j++){
                if (i == count / 4){
                    this.tm[0, i, j+1] = 3;
                }
                else {
                    this.tm[0, i, j ] = 3;
                }
            }
        }
    }
     //1�� 2�����
    private void MakeB(){
        int count = this.top + 1;
        for (int i = 0; i < count / 2; i++){
            for (int j = 0; j < count / 2; j++){
                this.tm[1, i, j] = 1;
            }
        }
        for (int i = 0; i < count / 2; i++){
            for (int j = 0; j < count / 2 -(count/4-1); j++){
                this.tm[1, i, j ] = 2;
            }
        }
    }
     //AB�� �ݴ�� ����� 
    private void MakeCD() {
        int count = this.top + 1;
        for (int i = 0; i < count / 2; i++){
            for (int j = 0; j < count/2 ; j++){
                if(this.tm[0,i,j]==0){
                    this.tm[2, i, j] = 3;
                }else if(this.tm[0,i,j]==3){
                    this.tm[2, i, j] = 0;
                }
                if (this.tm[1, i, j] == 1){
                    this.tm[3, i, j] = 2;
                }else if (this.tm[1, i, j] == 2){
                    this.tm[3, i, j] = 1;
                }
            }
        }
    }
     //N/2XN/2�� �� ������ ���ϱ�
    private void Copy() {
        int count = this.top + 1;
        int multi = (count / 2) * (count / 2);
        OddMagicSquare odd =new OddMagicSquare(count/2);
        odd.Make();//Ȧ�� ������ �ϼ�
        int[,] oddM = odd.Mabang;//Property
        for (int i = 0; i < count / 2; i++){
            for (int j = 0; j < count / 2; j++){
                mabang[i, j] = 
                    multi * this.tm[0, i, j] + oddM[i,j];
                mabang[i, j + count / 2] =
                    multi * this.tm[1, i, j] + oddM[i, j];
                mabang[i + count / 2, j] =
                    multi* this.tm[2, i, j] + oddM[i, j];
                mabang[i + count / 2, j + count / 2] =      
                    multi*this.tm[3, i, j] + oddM[i, j];
            }
        }
    }
    public bool IsCheck(){
        bool isC = true;
        int count = top + 1;
        int[] ic = new int[2 * count + 2];
        for (int k = 0; k < count; k++)
        {
            ic[k] = SumRow(k);
            ic[k + count] = SumCol(k);
        }//
        ic[2 * count] = SumDiago();
        ic[2 * count + 1] = SumAntiDiago();

        for (int i = 1; i < ic.Length; i++)
        {
            if (ic[0] != ic[i])
            {
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
    { //�밢��
        int count = this.top + 1;
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += this.mabang[i, i];
        }
        return total;
    }
    public int SumAntiDiago()
    {//���밢��
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
