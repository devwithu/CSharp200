using System;
namespace Com.JungBo.Logic{
   public class Hanoi{
    int tray = 3;
    public Hanoi(int tray) {
        this.tray = tray;
    }
    public void HanoiTower(int n, String a, String b, String c) {
        if (n == 1){
            Console.WriteLine(a + " bar쪽에 있던 링이 "
                                        + b + " bar쪽으로 이동");
        }
        else {
            this.HanoiTower(n-1,a,c,b);
            Console.WriteLine(a + " bar쪽에 있던 링이 "
                                         + b + " bar쪽으로 이동");
            this.HanoiTower(n - 1, c, b, a);
        }
    }
    public void show() {
        HanoiTower(tray,"A","B","C");
    }
   }
}
