using System;
namespace Com.JungBo.Maths{
    //단축연산자.
    public class PowerSeries{
     
        public static double Taylor(double x){
            double sum = 1.0;
            double temp = 1.0;

            for (double i = 1.0; i <= 20.0; i++){
                temp *= (x / i);
                sum += temp;
            }

            return sum;
        }// Taylor
    }
}
