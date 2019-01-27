using System;
namespace Com.JungBo.Game{
 public class Hitter{
    private int[] lott;//배열선언
    private int m;
    public Hitter(int m) {
        this.m = m;
    }
    public Hitter() : this(3) { }
    //타자가 친공
    public int[] Ball {
        get { return this.lott; }
    }
    private void Init(int m) {
        lott = new int[m]; //배열생성, 초기화-->0
        BaseBallUtil.Fill(lott, -1);
    }
    //콘솔로 한 수 입력받기
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
    //세 수 입력받기
    public void MakeNum(params int[] num){
        Init(m);
        for (int i = 0; i < num.Length; i++){
            lott[i] = num[i];
        }
    }//
    //콘솔에서 서로 다른 세 수 입력받기
    private void Make() {
        Console.WriteLine("서로다른 세수를 입력하세요.");
        MakeNum(this.MakeNum(), this.MakeNum(), this.MakeNum());
        while (Contain()) {
            Console.WriteLine("다시 서로다른 세수를 입력하세요.");
            MakeNum(this.MakeNum(), this.MakeNum(), this.MakeNum());
        }
        Console.WriteLine("서로 다른 수가 입력되었습니다.");
    }//
    public void ReMake(){
        Init(m);
        this.Make();
    }//
    //같은 수를 콘솔에서 입력받았는가?
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
