using System;
using System.Text;
namespace Com.JungBo.Kisa{
[Serializable]
public class Product{
//----����ʵ�
private int      prodNum;  //������ȣ ���� 6  x
private string   prodPart; //�������� ���� 1
private string   pName;   //�����  ���� 4
private int      pValue;  //�ܰ�  ���� 3
private int      pAmount;// �ǸŶ� ���� 3
private string   pPant;    // �����ڵ� ���� 1
private string   pConsum;    // �ŷ��ڵ� ���� 1
private int      pPoint;// ��������Ʈ ���� 3 xx
private int      pCount;// ��� Ƚ�� ���� 3
private int      pMoney;// ����� ���� 3   xxx
private string   pGrade;// ������� ���� 1
//---������Ƽ
public int GetPAmount() {return pAmount;}
public string GetPConsum(){return pConsum;}
public int GetPCount() {return pCount;}
public string GetPGrade() {return pGrade;}
public int GetPMoney() {return pMoney;}
public string GetPName() {return pName;}
public string GetPPant() {return pPant;}
public int GetPPoint() {return pPoint;}
public int GetProdNum() {return prodNum;}
public string GetProdPart(){return prodPart;}
public int GetPValue() {return pValue;}
public void SetPAmount(int i){pAmount = i;}
public void SetPConsum(string str){pConsum=str;}
public void SetPCount(int i) {pCount = i;}
public void SetPGrade(string str) {pGrade =str;}
public void SetPMoney(int i) {pMoney = i;}
public void SetPName(string str) {pName = str;}
public void SetPPant(string str) {pPant = str;}
public void SetPPoint(int i) {pPoint = i;}
public void SetProdNum(int i) {prodNum = i;}
public void SetProdPart(string str){prodPart=str;}
public void SetPValue(int i) {pValue = i;}
//---�޼���
public void SetProduct(string[] s){
	this.SetProdNum(Convert.ToInt32(s[0].Trim()));
	this.SetProdPart(s[1].Trim());
	this.SetPName(s[2].Trim());
	this.SetPValue(Convert.ToInt32(s[3].Trim()));
	this.SetPAmount(Convert.ToInt32(s[4].Trim()));
	this.SetPPant(s[5].Trim());
	this.SetPConsum(s[6].Trim());
	this.SetPPoint(Convert.ToInt32(s[7].Trim()));
	this.SetPCount(Convert.ToInt32(s[8].Trim()));
	this.SetPMoney(Convert.ToInt32(s[9].Trim()));
	this.SetPGrade(s[10].Trim());
}
//---ToString �������̵�
public override string ToString(){
	StringBuilder bf = new StringBuilder();
	bf.Append(this.prodNum + "/")
	.Append(this.prodPart + "/")
	.Append(this.pName + "/")
	.Append(this.pValue + "/")
	.Append(this.pAmount + "/")
	.Append(this.pPant + "/")
	.Append(this.pConsum + "/")
	.Append(this.pPoint + "/")
	.Append(this.pCount + "/")
	.Append(this.pMoney + "/")
	.Append(this.pGrade);
	return bf.ToString();
  }
 }
}
