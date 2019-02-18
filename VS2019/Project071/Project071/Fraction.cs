using System;
using Com.JungBo.Exc;  //UnFittalbeException
namespace Com.JungBo.Maths{
    public class Fraction{
        private int bunja; //분자
        private int bunmo; //분모

        //생성자-분모가 0일 수 없다. 
        public Fraction(int bunja, int bunmo) {
            if(bunmo==0){
             throw new UnFittalbeException("분모가 0일수 없습니다.");
            }
            else if (bunja == 0){
                this.bunmo = 1;
            }
            else {
                this.bunja = bunja;
                this.bunmo = bunmo;
            }
        }//

        public Fraction(Fraction bs): this(bs.Bunja, bs.Bunmo){}
        public Fraction(): this(0, 1){}

        public int Bunja{
            get { return bunja; }
            set { this.bunja = value; }

        }
        public int Bunmo{
            get { return bunmo; }
            set {
                if (value == 0){
                    throw 
                  new UnFittalbeException("분모가 0일수 없습니다.");
                }
                else {
                    this.bunmo = value; 
                }
            }
        }
        public override string ToString(){
            return string.Format("{0}/{1}", bunja, bunmo);
        }//
    }
}
