using System;
namespace Com.JungBo.Logic{
    public class IReduceFraction{

        private int bunja;  //����
        private int bunmo;  //�и�
        //���� ������Ƽ
        public int Bunja{
            get { return bunja; }
        }
        //�и� ������Ƽ
        public int Bunmo{
            get { return bunmo; }
        }
        public void SetIReduceFraction(int bunja, int bunmo) {
            if (bunmo == 0){
                throw new UnFittableException(
                    "�и� 0�ϼ� �����ϴ�. ");
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
        //���������
        public IReduceFraction(IReduceFraction bs) 
        :this(bs.Bunja,bs.Bunmo){}
        //������
        public IReduceFraction(int bunja, int bunmo) {
            SetIReduceFraction(bunja,bunmo);
        }//
        public override string ToString(){
            return string.Format("{0}/{1}",
                bunja, bunmo=(bunja==0?1:bunmo));
        }//
        //������ �����ε�
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
        //Equals �������̵�
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
