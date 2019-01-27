using System;
namespace Com.JungBo.Maths{
    //Taylor �޿� ���� ���� 22
    public class PowerSeries{
        //Taylor ���� 22
        public static double Taylor(double x){
            double sum = 1.0;
            double temp = 1.0;
            for (double i = 1.0; i <= 40.0; i++){
                temp *= (x / i);
                sum += temp;
            }
            return sum;
        }// Taylor �޼�
        //���Ϸ� �ڻ��� �޼�
        public double TaylorCos(double x){
            double sum = 1;
            double temp = 1.0;
            for (int i = 1; i <= 40; i++){
                temp *= (x / i);
                switch (i % 4){
                    case 1:
                    case 3: break;
                    case 2: sum += (-1) * temp; break;
                    case 0: sum += temp; break;
                }
            }
            return sum;
        }
        //���Ϸ� ���� �޼�
        public double TaylorSin(double x){
            double sum = 0;
            double temp = 1.0;
            for (int i = 1; i <= 40; i++){
                temp *= (x / i);
                switch (i % 4){
                    case 0:
                    case 2: break;
                    case 1: sum += temp; break;
                    case 3: sum += (-1) * temp; break;
                }
            }
            return sum;
        }
        //Math.Sin()�� �� �Ҽ� 13�ڸ� ���� ��ġ
        public void PrintSinValue() {
            for (int i = 0; i <= 360; i++){
                Console.Write("{0}\t\t\t",
                         TaylorSin(i * Math.PI / 180.0));
                Console.WriteLine("{0}",
                    Math.Sin(i * Math.PI / 180.0));
            }
        }
        //Math.Cos()�� �� �Ҽ� 13�ڸ� ���� ��ġ
        public void PrintCosValue(){
            for (int i = 0; i <= 360; i++){
                Console.Write("{0}\t\t\t",
                         TaylorCos(i * Math.PI / 180.0));
                Console.WriteLine("{0}",
                    Math.Cos(i * Math.PI / 180.0));
            }
        }
    }
}
