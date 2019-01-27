using System;
using Com.JungBo.Logic;
namespace DictioaryProject{
    public class Program{
        static void Main(string[] args){
            string yesOrNo = "Do you want to continue? (Y/N)";
            string message = "";
            Console.WriteLine("Play Card Game!!");

            CardGame game = new CardGame();
            game.Play();

            int count = 1;
            Console.WriteLine(yesOrNo);
            while ((message = Console.ReadLine()).ToUpper().Equals("Y")){
                Console.WriteLine("{0} 번째 Card Game Game", count++);
                game.Continue();//경기를 계속한다.
                game.Play();
                Console.WriteLine(yesOrNo);
            }
        }
    }
}
