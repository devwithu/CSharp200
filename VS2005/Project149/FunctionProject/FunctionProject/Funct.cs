using System;
namespace Com.JungBo.Maths {
    public class Funct {
        private double x;//f(x)의 x
        private double[] m;//6x^2-->[6,0,0]

        public Funct(double x, double[] n){
            this.x = x;
            m = new double[n.Length];
            Array.Copy(n, 0, m, 0, n.Length);//깊은복사
        }
        //x를 나중에 대입
        public Funct(double[] n): this(0, n){}
        //x 프로퍼티
        public double X{
            get { return x; }
            set { x = value; }
        }
        public double Function(){ //f(x)
            int count = m.Length;
            double value = 0.0;
            for (int i = 0; i < count; i++){
                value += (m[i] * Math.Pow(x, count - 1 - i));
            }
            return value;
        }//
    }
}
