using System;
using Com.JungBo.Logic;   //RSA
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int seed = 239; //97,157,167, 239
            //p< SEED <qÀÎ ¼Ò¼ö p,q
            RSA rsa = new RSA(seed);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
            rsa.Make();
            Console.WriteLine(rsa);
        }
    }
}
