using System;
namespace Com.JungBo.Game{
 public class Hitter{
    private int[] lott;//�迭����
    private int m;
    public Hitter(int m) {
        this.m = m;
    }
    public Hitter() : this(3) { }
    //Ÿ�ڰ� ģ��
    public int[] Ball {
        get { return this.lott; }
    }
    private void Init(int m) {
        lott = new int[m]; //�迭����, �ʱ�ȭ-->0
        BaseBallUtil.Fill(lott, -1);
    }
    //�ַܼ� �� �� �Է¹ޱ�
    public int MakeNum() {
        int temp = 0;
        try { 
            temp=int.Parse(Console.ReadLine());
        }
        catch {
            temp=0;
        }
        return temp;
    }//
    //�� �� �Է¹ޱ�
    public void MakeNum(params int[] num){
        Init(m);
        for (int i = 0; i < num.Length; i++){
            lott[i] = num[i];
        }
    }//
    //�ֿܼ��� ���� �ٸ� �� �� �Է¹ޱ�
    private void Make() {
        Console.WriteLine("���δٸ� ������ �Է��ϼ���.");
        MakeNum(this.MakeNum(), this.MakeNum(), this.MakeNum());
        while (Contain()) {
            Console.WriteLine("�ٽ� ���δٸ� ������ �Է��ϼ���.");
            MakeNum(this.MakeNum(), this.MakeNum(), this.MakeNum());
        }
        Console.WriteLine("���� �ٸ� ���� �ԷµǾ����ϴ�.");
    }//
    public void ReMake(){
        Init(m);
        this.Make();
    }//
    //���� ���� �ֿܼ��� �Է¹޾Ҵ°�?
    public bool Contain(){ 
        bool isC = false;
        for (int i = 0; i < lott.Length; i++){
            for (int j = 0; j< lott.Length ; j++){
                if(i!=j && lott[i]==lott[j]){
                    isC = true;
                    break;
                }
            }
        }
        return isC;
    }//
  }
}
