using System;
using System.Threading;
public class CakePlate {
 private int breadCount=0;   //������ ���� ����
 public CakePlate() {}
 public  void makeBread(){
  lock(this){
    if(breadCount>=10){
	    try{
		    Console.WriteLine("���� ���´�. ��ٸ���.");
            Monitor.Wait(this);//���� ���� ������ ��ٸ���.
	    }catch(Exception){}
    }
    breadCount++;//���� 10���� �ȵǸ� �� ������.
    Console.WriteLine("���� 1�� �� ����  �� "+breadCount+"��");
    Monitor.PulseAll(this);//�����ߴ� ���� �ٽ� ����
  }
 }
 public  void eatBread(){
  lock(this){
    if(breadCount<1){
	    try{
		    Console.WriteLine("���� ���ڶ� ��ٸ�.");
            Monitor.Wait(this);//���� ���� ������ ��ٸ���.
	    }catch(Exception){}
    }
    breadCount--;//���� ������ ����.
    Console.WriteLine("���� 1�� ����  �� "+breadCount+"��");
    Monitor.PulseAll(this);//�����ߴ� ���� �ٽ� ����
  }
 }
}
