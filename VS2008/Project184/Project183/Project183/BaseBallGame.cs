using System;
namespace Com.JungBo.Game{
 public class BaseBallGame{
    private Pitcher pit;//����
    private Hitter hit;//Ÿ��
    private Empire em;//����
    public BaseBallGame(){
        pit = new Pitcher();
        hit = new Hitter();
        em = new Empire();
    }
    public void Play(){
        bool isWin = false;
        pit.ReMake(); //���� �� ������
        em.Pit = pit.Ball;//���ǿ��� ������ ����
        //BaseBallUtil.Print(em.Pit);//������ ����
        int count = 1;
        while (count <= 10){
            hit.ReMake();//Ÿ�� �� ġ��
            em.Hit = hit.Ball;//���ǿ��� Ÿ�� �� ����
            if (em.Strike() == 3){
                Console.WriteLine("You Win in {0}",count);
                isWin = true;
                break;
            }
            else{
               string msg="�ݺ�ȸ��{2}: {0}Strike!!  {1}Ball!!";
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
