using System;
namespace Com.JunBo.Basic
{
    //델리게이트 선언
    public delegate void Attack();
    public delegate void DoIt(String str);

    public class Zilot
    {

        public void Ziler()
        {
            Console.WriteLine("날카롭게 찔러!");
        }
        public void Ziler(string str)
        {
            Console.WriteLine("{0}(으)로 찔러!", str);
        }
    }
    public class Dragon
    {

        public void Boom()
        {
            Console.WriteLine("폭탄던져!");
        }
        public void Boom(string str)
        {
            Console.WriteLine("{0}(를)을 던져!", str);
        }
    }

    public class Program
    {
        public static void Main(string[] args){
            
            Zilot z88 = new Zilot();
            Attack act3 = new Attack(z88.Ziler);
            act3();

            Zilot z1 = new Zilot();
            Zilot z2 = new Zilot();

            Dragon g1 = new Dragon();
            Dragon g2 = new Dragon();

            //멀티 델리게이트
            Attack act1 = new Attack(z1.Ziler);
            act1 += new Attack(z2.Ziler);
            act1 += new Attack(g1.Boom);
            act1 += new Attack(g2.Boom);
            act1 -= new Attack(g2.Boom);
            act1();
            //아규먼트가 있는 델리게이트
            DoIt doit = new DoIt(z1.Ziler);
            doit += new DoIt(g1.Boom);
            doit("칼");

        }
    }
}
