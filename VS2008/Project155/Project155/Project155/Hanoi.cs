using System;
namespace Com.JungBo.Logic{
 public class Hanoi{
    public void HanoiTower(int n, String a, String b, String c) {
        if (n == 1){
            Console.WriteLine("{0}���� {1}���� �ű�: ", a, b);
        }
        else {
            this.HanoiTower(n-1,a,c,b);
            Console.WriteLine("{0}���� {1}���� �ű�: ", a, b);
            this.HanoiTower(n - 1, c, b, a);
        }
    }
 }
}
