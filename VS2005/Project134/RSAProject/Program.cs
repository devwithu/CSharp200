using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            ImageArray image = new ImageArray(12);
            image.Make();
            image.Print();
            image.ReMake();
            image.Print();
        }
    }
}
