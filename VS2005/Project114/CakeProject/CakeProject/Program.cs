using System;
using System.Threading;
namespace CakeProject {
    public class Program {
        public static void Main(string[] args){
            CakePlate plate = new CakePlate();
            CakeEater eater = new CakeEater(plate);
            CakeMaker maker = new CakeMaker(plate);

            maker.Start("maker");
            eater.Start("eater");
        }
    }
}
