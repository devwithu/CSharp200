using System;
using System.Threading;
public class CakeMaker  {
	private CakePlate cake;
    private string name;
    Thread makerThread;
    public string Name{
        get { return name; }
        set { name = value; }
    }
	public CakeMaker(CakePlate cake){
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
            Console.Write("{0}: ", name);
            cake.makeBread();//빵만들기
		}
Console.WriteLine("{0}:빵을 다 만들었으니 쉬자.", name);
	}
    public void Start(string name) {
        this.name = name;
      makerThread = new Thread(new ThreadStart(run));
        makerThread.Name = name;
        makerThread.Start();
    }
}
