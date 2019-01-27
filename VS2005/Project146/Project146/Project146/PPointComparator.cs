using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Kisa{
    public class PPointComparator : IComparer<Product>{
    //�����*��������Ʈ�� ũ��� ��
    public int Compare(Product sg1, Product sg2){
        int pMoney1 = sg1.GetPMoney();//�����
        int pMoney2 = sg2.GetPMoney();//
        int pPoint1 = sg1.GetPPoint();//��������Ʈ
        int pPoint2 = sg2.GetPPoint();
        int prodNum1 = sg1.GetProdNum();
        int prodNum2 = sg2.GetProdNum();
        if ((pMoney1 * pPoint1) > (pMoney2 * pPoint2)){
            return -1;  //��������
        }
        else if ((pMoney1 * pPoint1) == (pMoney2 * pPoint2)){
            return 0;
        }
        else{
            return 1;//��������
        }
     }
   }
}
