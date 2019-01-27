using System;
using Com.JungBo.Maths;
using Com.JungBo.Infor;
namespace CloneProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Z z0 = new Z(3, 5);
            Z z1 = new Z(4, 6);
            Z z2 = z1;                //얕은 복사
            Z z3 = new Z(z0);         //깊은 복사
            Z z4 = z0.Clone() as Z;  //얕은 복사

            Console.WriteLine("z0={0}", z0);  //3+5i
            Console.WriteLine("z1={0}", z1);  //4+6i
            Console.WriteLine("z2={0}", z2);  //4+6i
            Console.WriteLine("z3={0}", z3);  //3+5i
            Console.WriteLine("z4={0}", z4);  //3+5i

            ChangeZ(z0);    //3+5i -> 13-5i
            ChangeZ(z2);    //4+6i -> 14-4i


            Console.WriteLine("z0={0}", z0);  //13-5i
            Console.WriteLine("z1={0}", z1);  //14-4i  z1과 z2는 얕은복사
            Console.WriteLine("z2={0}", z2);  //14-4i  z1과 z2는 얕은복사
            Console.WriteLine("z3={0}", z3);  //3+5i   z0와 z3은 깊은복사
            Console.WriteLine("z4={0}", z4);  //3+5i   z0와 z4은 깊은복사

            //깊은 복사  []은 readonly해도 변경할 수 있다. 섹션 57 참고
            FundInform inform = new FundInform();
            string[] fundM = inform.Clone() as string[];

            foreach (string var in fundM)
            {
                Console.WriteLine(var);
            }

        }
        //주소에 의한 전달
        public static void ChangeZ(Z zz)
        {
            zz.X += 10;
            zz.Y -= 10;
        }
    }
}
