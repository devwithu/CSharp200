using System;
namespace Com.JungBo.Logic{
   public class Hanoi{
    int tray = 3;
    public Hanoi(int tray) {
        this.tray = tray;
    }
    public void HanoiTower(int n, String a, String b, String c) {
        if (n == 1){
            Console.WriteLine(a + " bar�ʿ� �ִ� ���� "
                                        + b + " bar������ �̵�");
        }
        else {
            this.HanoiTower(n-1,a,c,b);
            Console.WriteLine(a + " bar�ʿ� �ִ� ���� "
                                         + b + " bar������ �̵�");
            this.HanoiTower(n - 1, c, b, a);
        }
    }
    public void show() {
        HanoiTower(tray,"A","B","C");
    }
   }
}
