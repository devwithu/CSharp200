using System;
using System.Collections.Generic;
namespace Com.JungBo.Kisa{
public class ProductList {

	private int[] catg={6,1,4,3,3,1,1,3,3,3,1};

    //0~6, 6~6+1, 6+1~6+1+4, 6+1+4~6+1+4+3
    //6+1+4~6+1+4+3~6+1+4~6+1+4+3+3, ...
    //6��, 1��, 4��, 3��, ...1�� ��ŭ �ڸ��� ���� ��.
    private int CatNumTo(int[] aa, int a){
        int toto = 0;
        if (aa.Length < a){
            toto = 0;
        }
        else{
            for (int i = 0; i <= a; i++){
                toto += aa[i];
            }
        }
        return toto;
    }
	public string [] Split(string str){
		string[] ss=new string[CatgLength()];
		ss[0]=str.Substring(0,catg[0]).Trim();//����, ����
		for(int i=1;i<ss.Length;i++){
            //100001Astch 19100AA 72 51 89B ����
            //100001/A/stch/ 19/100/A/A/ 72/ 51/ 89/B/
            //��ŭ�� �ڸ���.
			ss[i]=str.Substring(CatNumTo(catg,i-1),catg[i]).Trim();
		}
		return ss;
	}
    
	public Product SplistP(string str){
		Product p=new Product();
        //100001/A/stch/ 19/100/A/A/ 72/ 51/ 89/B/
        //�������ڿ��� /��ġ���� �߶� ���ڿ� �迭�� �����.
		string[] ss=Split(str);
		p.SetProduct(ss);
		return p;
	}
    //YenaItFiles���� �о���� �������ڿ��� 
    //Product�� ��ȯ �� List�� ����,  List�� ����
    public List<Product> getAllProducts(List<string> v){
        List<Product> list = new List<Product>(10);
		for(int i=0;i<v.Count;i++){
            Product p = SplistP(v[i]);//�ε����� �̿�  
                         //�������ڿ��� Product�� ��ȯ
			list.Add(p);              //List�� ����
		}
		return list;
	}
	//Product List �� ���ϴ� Grade�� �� (��{"A","C"})
	//Product �� List�� ������ �� List�� ����
    public List<Product> getAllProdInGrade(string[] ss1, 
                                       List<Product> v){
        List<Product> list = new List<Product>(10);
		for(int i=0;i<v.Count;i++){
            Product p = v[i];//�ε���
			for(int j=0;j<ss1.Length;j++){
				if(p.GetPGrade().Equals(ss1[j])){
					list.Add(p);
				}
			}
		}
		return list;
	}
    //������� ���� �̻�
    public List<Product> getAllProdWithPMoney(int pmoney,
                                        List<Product> v){
        List<Product> list = new List<Product>(10);
        for (int i = 0; i < v.Count; i++){
            Product p = v[i];//�ε���
            if (p.GetPMoney() >= pmoney){
                list.Add(p);
            }
        }
        return list;
    }
    //pPoint�� ���� �̻�
    public List<Product> getAllProdWithPPoint(int pPoint,
                                     List<Product> v) {
        List<Product> list = new List<Product>(10);
        for (int i = 0; i < v.Count; i++){
            Product p = v[i];//�ε���
            if (p.GetPPoint() >= pPoint){
                list.Add(p);
            }
        }
        return list;
    }

    //������ �ܰ��̻��� ��� Product�� List�� ����
    public List<Product> getAllProdWithDanga(int danga,
                                         List<Product> v){
        List<Product> list = new List<Product>(10);
		for(int i=0;i<v.Count;i++){
            Product p = v[i];//�ε���
			if(p.GetPValue()>=danga){
				list.Add(p);
			}
		}
		return list;
	}

    //������ ���ȸ���̻��� ��� Product�� List�� ����
    public List<Product> getAllProdWithPCount(int pcount,
                                          List<Product> v){
        List<Product> list = new List<Product>(10);
		for(int i=0;i<v.Count;i++){
            Product p = v[i];//�ε���
			if(p.GetPCount()>=pcount){
				list.Add(p);
			}
		}
		return list;
	}
   
	public string[] ToStringFromProduct(Product pro, int count){
		char[] delemiter={'/'};
		string[] st=pro.ToString().Split(delemiter,count);
		return st;
	}

	private int TotalLength(){
		int tot=0;
		for(int i=0;i<this.catg.Length;i++){
			tot+=this.catg[i];
		}
		return tot;
	}
	private int CatgLength(){
		return this.catg.Length;
	}
	public int PrintGasan(string str,Product p){
		int temp=0;
		if(str.Equals("A")){
			temp=p.GetPPoint()+PointsUtil.ADDPOINTA;
		}
		else if(str.Equals("B")){
			temp=p.GetPPoint()+PointsUtil.ADDPOINTB;
		}
		else if(str.Equals("C")){
			temp=p.GetPPoint()+PointsUtil.ADDPOINTC;
		}
		return temp;
	}
	public int PrintDiscount(string str,Product p){
		int temp=0;
		if(str.Equals("A")){
			temp=p.GetPValue()+PointsUtil.DISPOINTA;
		}
		else if(str.Equals("B")){
			temp=p.GetPValue()+PointsUtil.DISPOINTB;
		}
		else if(str.Equals("C")){
			temp=p.GetPValue()+PointsUtil.DISPOINTC;
		}
		return temp;
	}
 }
}
