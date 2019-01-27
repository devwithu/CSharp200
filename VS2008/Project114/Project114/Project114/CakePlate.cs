using System;
using System.Threading;
public class CakePlate {
	private int breadCount=0;
    object oo = new object();//lock�� ���� ��� ��ü
	public CakePlate() {
	}
	public  void makeBread(){
        Monitor.Enter(oo);
	    if(breadCount>=10){
		    try{
			    Console.WriteLine("���� ���´�. ��ٸ���.");
                Monitor.Wait(oo);
		    }catch(Exception){}
	    }
	    breadCount++;//���� 10���� �ȵǸ� �� ������.
Console.WriteLine("���� 1�� �� ����  �� "+breadCount+"��");
        Monitor.PulseAll(oo);
        Monitor.Exit(oo);
	}
	public  void eatBread(){
        Monitor.Enter(oo);
	    if(breadCount<1){
		    try{
			    Console.WriteLine("���� ���ڶ� ��ٸ�.");
                Monitor.Wait(oo);
		    }catch(Exception){}
	    }
	    breadCount--;//���� ������ ����.
	 Console.WriteLine("���� 1�� ����  �� "+breadCount+"��");
        Monitor.PulseAll(oo);
        Monitor.Exit(oo);
	}
}
