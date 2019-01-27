using System;
using System.Threading;
public class CakeEater {
	private CakePlate cake;
    private string name;
    Thread eaterThread;
    public string Name{
        get { return name; }
        set { name = value; }
    }
	public CakeEater(CakePlate cake){
		setCakePlate(cake);
	}
	public void setCakePlate(CakePlate cake){
		this.cake=cake;
	}
	public CakePlate getCakePlate(){
		return cake;
	}
	public void run(){
		for(int i=0;i<50;i++){
            Console.Write("{0}: ", name); cake.eatBread();
		}
Console.WriteLine("{0}: 모든 빵을 다 먹었으니 쉬자.",name);
	}
    public void Start(string name){
        this.name = name;
        eaterThread = new Thread(new ThreadStart(run));
        eaterThread.Name = name;
        eaterThread.Start();
    } 
}
