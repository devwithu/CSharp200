using System;
namespace Com.JungBo.Logic{
    public class IReduceFraction{

        private int bunja;  //분자
        private int bunmo;  //분모
        //분자 프로퍼티
        public int Bunja{
            get { return bunja; }
        }
        //분모 프로퍼티
        public int Bunmo{
            get { return bunmo; }
        }
        public void SetIReduceFraction(int bunja, int bunmo) {
            if (bunmo == 0){
                throw new UnFittableException(
                    "분모가 0일수 없습니다. ");
            }
            else if (bunja == 0){
                this.bunmo = 1;
            }
            else{
                try{
                    this.bunja = bunja / UclidMath.GCD(
                        bunja > 0 ? bunja : -1 * bunja,
                        bunmo > 0 ? bunmo : -1 * bunmo);
                    this.bunmo = bunmo / UclidMath.GCD(
                        bunja > 0 ? bunja : -1 * bunja,
                        bunmo > 0 ? bunmo : -1 * bunmo);
                }
                catch (UnFittableException ufe){
                    throw ufe;
                }
            }
        }
        //복사생성자
        public IReduceFraction(IReduceFraction bs) 
        :this(bs.Bunja,bs.Bunmo){}
        //생성자
        public IReduceFraction(int bunja, int bunmo) {
            SetIReduceFraction(bunja,bunmo);
        }//
        public override string ToString(){
            return string.Format("{0}/{1}",
                bunja, bunmo=(bunja==0?1:bunmo));
        }//
        //연산자 오버로딩
        public static IReduceFraction operator+
            (IReduceFraction bs1, IReduceFraction bs2){
            return new IReduceFraction(
                (bs1.Bunja*bs2.Bunmo+bs1.Bunmo*bs2.Bunja),
                (bs1.Bunmo*bs2.Bunmo));
        }
        public static IReduceFraction operator -
            (IReduceFraction bs1, IReduceFraction bs2){
            return new IReduceFraction(
            (bs1.Bunja * bs2.Bunmo - bs1.Bunmo * bs2.Bunja),
                (bs1.Bunmo * bs2.Bunmo));
        }//
        public static IReduceFraction operator *
            (IReduceFraction bs1, IReduceFraction bs2){
            return new IReduceFraction(
                (bs1.Bunja * bs2.Bunja),
                (bs1.Bunmo * bs2.Bunmo));
        }//
        public static IReduceFraction operator /
            (IReduceFraction bs1, IReduceFraction bs2){
            return new IReduceFraction(
          (bs1.Bunja * bs2.Bunmo),(bs1.Bunmo * bs2.Bunja));
        }//

        public static bool operator==
            (IReduceFraction bs1, IReduceFraction bs2){
            return bs1.Equals(bs2);
        }//
        public static bool operator !=
           (IReduceFraction bs1, IReduceFraction bs2){
            return ! bs1.Equals(bs2);
        }//
        //Equals 오버라이딩
        public override bool Equals(object obj){
            IReduceFraction irrF=obj as IReduceFraction;
            return bunja == irrF.Bunja &&bunmo == irrF.Bunmo;
        }
        public override int GetHashCode(){
            return bunja.GetHashCode() ^
                 bunmo.GetHashCode() + 37;
        }
    }
}
