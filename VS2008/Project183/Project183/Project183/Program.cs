using System;
namespace Com.JungBo.Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string yesOrNo = "Do you want to continue? (Y/N)";
            string message = "";
            Console.WriteLine("Play Base Ball Game!!");

            BaseBallGame game = new BaseBallGame();
            game.Play();
            int count = 1;
            Console.WriteLine(yesOrNo);
            while ((message = Console.ReadLine()).ToUpper().Equals("Y"))
            {
                Console.WriteLine("{0} 번째 Base Ball Game", count++);
                game.Play();
                Console.WriteLine(yesOrNo);
            }
        }
    }
}
