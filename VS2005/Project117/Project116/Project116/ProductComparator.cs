using System;
using System.Collections.Generic;
namespace Com.JungBo.Kisa{
    //Product 개체끼리 비교
public class ProductComparator: IComparer<Product> {
    //두개의 Product를 비교한다. 
    //판매량+제조포인트로 비교
public int Compare(Product sg1, Product sg2){
	int pMoney1=sg1.GetPAmount();//판매량
    int pMoney2 = sg2.GetPAmount();//
	int pPoint1=sg1.GetPPoint();//제조포인트
	int pPoint2=sg2.GetPPoint();
	int prodNum1=sg1.GetProdNum();
	int prodNum2=sg2.GetProdNum();
	if((pMoney1+pPoint1)>(pMoney2+pPoint2)){  
		return -1;  //내림차순
	}
    else if ((pMoney1 + pPoint1) == (pMoney2 + pPoint2)){
		if(prodNum1>prodNum2){
			return 1;//오름차순
		}
		else if(prodNum1==prodNum2){
			return 0;//같은 번호가 없어서 이런 경우는 없다.
		}
		else{
			return -1;//내림차순
		}
	}
	else {
		return 1;//오름차순
	}
  }
 }
}
