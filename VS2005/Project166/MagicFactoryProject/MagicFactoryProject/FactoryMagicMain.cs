using System;
namespace Com.JungBo.Logic{
    public class FactoryMagicMain{
        public static void Main(string[] args){
            Console.WriteLine("마방진 숫자를 입력하세요 (n>=3)");
            IMagic magic = null;
            try{
                int n = int.Parse(Console.ReadLine());
                magic = MagicFactory.Factory(n);
                magic.Make();
                magic.Prints();
            }catch (NotMatchMagicException nme){
                Console.WriteLine(nme.Message);
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }finally {
                Console.WriteLine("MagicSquare End!");
            }
        }
    }
}
