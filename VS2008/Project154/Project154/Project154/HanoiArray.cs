using System;
namespace Com.JungBo.Logic{
  public class HanoiArray{
    int  tray=3;
    int bar=3;
    int [,] rings;
    public HanoiArray(int tray){
	    this.tray=tray;
	    rings=new int[tray,bar];
	    for(int i=0;i<rings.GetLength(0);i++){
		    int x=2*i+1;
		    rings[i,0]=x;
	    }
    }
    public int[,] GetRings(){
	    return rings;
    }      	
    public  void MoveHanoi(int [,] a,int num, 
                              char ringA,char ringB,char ringC){
	    if(num==1){
		    ShowHanoi(a,ringA,ringB);
	    }else {
		    MoveHanoi(a,num-1,ringA,ringC,ringB);
		    ShowHanoi(a,ringA,ringB);
		    MoveHanoi(a,num-1,ringC,ringB,ringA);
	    }
    }
    public void show() {
        ShowHanoi(this.rings);
        MoveHanoi(this.rings, tray, 'a', 'b', 'c');
    }
    public   void  ShowHanoi(int [,] a, char ringA,char ringB){
	    int aa=0;
	    int ab=1;
	    switch(ringA){
		    case 'a': aa=0;break;
		    case 'b': aa=1;break;
		    case 'c': aa=2;break;
	    }
	    switch(ringB){
		    case 'a': ab=0;break;
		    case 'b': ab=1;break;
		    case 'c': ab=2;break;
	    }
    	
	    Console.WriteLine(ringA+" bar쪽에 있던 링이 "
                                         +ringB+" bar쪽으로 이동");
	    Puts(a,aa,ab);
    	
	    for(int i=0;i<a.GetLength(0);i++){
		    Console.Write("[\t");
            for (int j = 0; j < a.GetLength(1); j++)
            {
			    Console.Write(a[i,j]+"\t");
		    }
		    Console.WriteLine("]");
	    }
        Console.WriteLine("==================================");
    }
    public   void  ShowHanoi(int [,] a){

        for (int i = 0; i < a.GetLength(0); i++)
        {
		    Console.Write("[\t");
            for (int j = 0; j < a.GetLength(1); j++)
            {
			    Console.Write(a[i,j]+"\t");
		    }
		    Console.WriteLine("]");
	    }
        Console.WriteLine("================================");
    }
    public   int   HasTray(int [,] a,int bar){
	    int no=-1;
        for (int i = 0; i < a.GetLength(0); i++)
        {
		    if(a[i,bar]!=0){
			    no=i;
			    break;
		    }
	    }
	    return no;
    }
    // change(a,2,2,0,0);==> 2,2의 값을 0,0으로 이동 
    //2,2의 값을 0으로 
    private void Change(int [,] a,int aa,int ab,int ba,int bb){
        Console.WriteLine("({0},{1})==>({2},{3})",aa,ab,ba,bb);
	    a[ba,bb]=a[aa,ab];
	    a[aa,ab]=0;
    }//
    public  void Puts(int [,]a,int barA, int barB){
      if(HasTray(a,barA)!=-1){
	    if(HasTray(a,barB)!=-1){
		    Change(a,HasTray(a,barA),barA,HasTray(a,barB)-1,barB);
	    }else{
		    Change(a,HasTray(a,barA),barA,a.GetLength(0)-1,barB);
	    }
      }
    }//
  }
}
