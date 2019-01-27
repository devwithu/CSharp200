using System;
namespace Com.JungBo.Logic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NImageArray image = new NImageArray(12);
            image.Make();
            image.Print();
            image.Make();
            image.Print();
        }
    }
}
