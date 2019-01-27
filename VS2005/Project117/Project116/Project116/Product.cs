using System;
using System.Text;
namespace Com.JungBo.Kisa{
[Serializable]
public class Product{
//----멤버필드
private int      prodNum;  //제조번호 숫자 6  x
private string   prodPart; //제조구분 문자 1
private string   pName;   //담당자  문자 4
private int      pValue;  //단가  숫자 3
private int      pAmount;// 판매랑 숫자 3
private string   pPant;    // 공장코드 문자 1
private string   pConsum;    // 거래코드 문자 1
private int      pPoint;// 제조포인트 숫자 3 xx
private int      pCount;// 출고 횟수 숫자 3
private int      pMoney;// 매출액 숫자 3   xxx
private string   pGrade;// 제조등급 문자 1
//---프로퍼티
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
//---메서드
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
//---ToString 오버라이드
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
