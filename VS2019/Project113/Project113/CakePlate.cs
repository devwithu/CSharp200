using System;
using System.Threading;
public class CakePlate {
 private int breadCount=0;   //접시위 빵의 개수
 public CakePlate() {}
 public  void makeBread(){
  lock(this){
    if(breadCount>=10){
	    try{
		    Console.WriteLine("빵이 남는다. 기다리자.");
            Monitor.Wait(this);//빵을 먹을 때까지 기다린다.
	    }catch(Exception){}
    }
    breadCount++;//빵이 10개가 안되면 더 만들자.
    Console.WriteLine("빵을 1개 더 만듬  총 "+breadCount+"개");
    Monitor.PulseAll(this);//중지했던 일을 다시 시작
  }
 }
 public  void eatBread(){
  lock(this){
    if(breadCount<1){
	    try{
		    Console.WriteLine("빵이 모자라 기다림.");
            Monitor.Wait(this);//빵을 만들 때까지 기다린다.
	    }catch(Exception){}
    }
    breadCount--;//빵이 있으니 먹자.
    Console.WriteLine("빵을 1개 먹음  총 "+breadCount+"개");
    Monitor.PulseAll(this);//중지했던 일을 다시 시작
  }
 }
}
