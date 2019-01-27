using System;
using System.Collections.Generic;
namespace Com.JungBo.Kisa{
    //Product ��ü���� ��
public class ProductComparator: IComparer<Product> {
    //�ΰ��� Product�� ���Ѵ�. 
    //�Ǹŷ�+��������Ʈ�� ��
public int Compare(Product sg1, Product sg2){
	int pMoney1=sg1.GetPAmount();//�Ǹŷ�
    int pMoney2 = sg2.GetPAmount();//
	int pPoint1=sg1.GetPPoint();//��������Ʈ
	int pPoint2=sg2.GetPPoint();
	int prodNum1=sg1.GetProdNum();
	int prodNum2=sg2.GetProdNum();
	if((pMoney1+pPoint1)>(pMoney2+pPoint2)){  
		return -1;  //��������
	}
    else if ((pMoney1 + pPoint1) == (pMoney2 + pPoint2)){
		if(prodNum1>prodNum2){
			return 1;//��������
		}
		else if(prodNum1==prodNum2){
			return 0;//���� ��ȣ�� ��� �̷� ���� ����.
		}
		else{
			return -1;//��������
		}
	}
	else {
		return 1;//��������
	}
  }
 }
}
