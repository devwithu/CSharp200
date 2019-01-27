using System;
namespace Com.JunBo.Basic {   
    //��������Ʈ ����
    public delegate void Attack();
    public delegate void DoIt(String str);
    
    public class Zilot {

        public void Ziler(){
            Console.WriteLine("��ī�Ӱ� ��!");
        }
        public void Ziler(string str){
            Console.WriteLine("{0}(��)�� ��!",str);
        }
    }
    public class Dragon {

        public void Boom(){
            Console.WriteLine("��ź����!");
        }
        public void Boom(string str){
            Console.WriteLine("{0}(��)�� ����!", str);
        }
    }

    public class Program{
        public static void Main(string[] args){
            
            Zilot z88 = new Zilot();
            Attack act3 = new Attack(z88.Ziler);
            act3();

            Zilot z1 = new Zilot();
            Zilot z2 = new Zilot();

            Dragon g1 = new ----00-=(Dragon();
            Dragon g2 = new Dragon();

            //��Ƽ ��������Ʈ
            Attack act1 = new Attack(z1.Ziler);
            act1 += new Attack(z2.Ziler);
            act1 += new Attack(g1.Boom);
            act1 += new Attack(g2.Boom);
            act1 -= new Attack(g2.Boom);
            act1();
            //�ƱԸ�Ʈ�� �ִ� ��������Ʈ
            DoIt doit = new DoIt(z1.Ziler);
            doit += new DoIt(g1.Boom);
            doit("Į");

        }
    }
}
