using System;
namespace Com.JungBo.Game{
 public class BaseBallGame{
    private Pitcher pit;//투수
    private Hitter hit;//타자
    private Empire em;//심판
    public BaseBallGame(){
        pit = new Pitcher();
        hit = new Hitter();
        em = new Empire();
    }
    public void Play(){
        bool isWin = false;
        pit.ReMake(); //투수 공 던지기
        em.Pit = pit.Ball;//심판에게 투수공 저장
        //BaseBallUtil.Print(em.Pit);//투수공 보기
        int count = 1;
        while (count <= 10){
            hit.ReMake();//타자 공 치기
            em.Hit = hit.Ball;//심판에게 타자 공 저장
            if (em.Strike() == 3){
                Console.WriteLine("You Win in {0}",count);
                isWin = true;
                break;
            }
            else{
               string msg="반복회수{2}: {0}Strike!!  {1}Ball!!";
               Console.WriteLine(msg,em.Strike(),em.Ball(),count);
               isWin = false;
            }
            count++;
        }
        if (!isWin){
            Console.WriteLine("You Lose, Pitcher is ");
            BaseBallUtil.Print(em.Pit);
        }
    }//
 }
}
