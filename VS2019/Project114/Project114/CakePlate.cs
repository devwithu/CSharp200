using System;
using System.Threading;
public class CakePlate {
	private int breadCount=0;
    object oo = new object();//lock을 위한 멤버 개체
	public CakePlate() {
	}
	public  void makeBread(){
        Monitor.Enter(oo);
	    if(breadCount>=10){
		    try{
			    Console.WriteLine("빵이 남는다. 기다리자.");
                Monitor.Wait(oo);
		    }catch(Exception){}
	    }
	    breadCount++;//빵이 10개가 안되면 더 만들자.
Console.WriteLine("빵을 1개 더 만듬  총 "+breadCount+"개");
        Monitor.PulseAll(oo);
        Monitor.Exit(oo);
	}
	public  void eatBread(){
        Monitor.Enter(oo);
	    if(breadCount<1){
		    try{
			    Console.WriteLine("빵이 모자라 기다림.");
                Monitor.Wait(oo);
		    }catch(Exception){}
	    }
	    breadCount--;//빵이 있으니 먹자.
	 Console.WriteLine("빵을 1개 먹음  총 "+breadCount+"개");
        Monitor.PulseAll(oo);
        Monitor.Exit(oo);
	}
}
