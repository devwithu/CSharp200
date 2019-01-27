using System;
using Com.JungBo.Maths;
namespace Project040{
    public class MainClass{
        public void Show() {
            Console.WriteLine("3���� �ϸ� {0}�� �Ǵ� ���Ҽ�: "
                               , 4 * new Z(1, Math.Sqrt(3)));
            Z[] zz = DeMoivre.CompRoot(3,
                                 4 * new Z(1, Math.Sqrt(3)));
            for (int i = 0; i < zz.Length; i++)
            {
                Console.WriteLine(zz[i]);
            }
            Console.WriteLine("3���� �ϸ� {0}�� �Ǵ� ���Ҽ�����:"
                               , 4 * new Z(1, Math.Sqrt(3)));

            double[] zza = DeMoivre.Thetas(3,
                                 4 * new Z(1, Math.Sqrt(3)));
            for (int i = 0; i < zza.Length; i++)
            {
                Console.WriteLine(DeMoivre.ToDegree(zza[i]));
            }
        }
    }
}
