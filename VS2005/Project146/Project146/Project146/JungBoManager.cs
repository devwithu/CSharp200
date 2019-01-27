using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Kisa{
    public class JungBoManager{
        //파일을 읽어서 제품정보문자열을 List에 저장
        YenaItFiles yena = new YenaItFiles();
        //제품정보문자열을 제품 개체로 바꿔서 저장
        List<Product> proList = new List<Product>(10);
        //주어진 조건에 맞는 제품 List를 얻는 메서드 포함
        ProductList pros = new ProductList();

        public void printJungBo(string fname) {
            yena.FileRead(fname);  //읽어서 정보문자열 List에 저장
            //yena.Print();        //저장된 내용 확인
            stringToProduct();
        }
        //정보문자열을 Product List바꿔서 저장
        public void stringToProduct(){
            List<string> pstr = yena.ProductList;
            proList = pros.getAllProducts(pstr);
        }

        public void solveOne(){ 
            string [] gradeStr={"C"};
            //제조등급이 C
            List<Product> splist = 
                pros.getAllProdInGrade(gradeStr, proList);
            List<Product> molist = 
                pros.getAllProdWithPMoney(80, splist);
            //제품 비교를 위한 것
            ProductComparator pcom = new ProductComparator();
            //조건대로 정렬
            molist.Sort(pcom);
            PrintProduct(molist);
            //System.Console.WriteLine(molist[4].ToString());
            string resulsts=""+
                (molist[4].GetPAmount()+molist[4].GetPPoint());
            yena.FileWrites("../../ans1.txt",resulsts.Trim());
            yena.FileWrites("../../ans11.txt", molist);
        }
        public void solveTwo() {
            int pPoint = 30;
            //제조포인트가 30이상
            List<Product> ppointList =
                pros.getAllProdWithPPoint(pPoint, proList);
            PPointComparator ppcom = new PPointComparator();
            ppointList.Sort(ppcom);
            PrintPpoint(ppointList);
            string resulsts = "" +
                (ppointList[0].GetPMoney() * ppointList[0].GetPPoint());
            yena.FileWrites("../../ans2.txt", resulsts.Trim());
            yena.FileWrites("../../ans21.txt", ppointList);
        }
        //Product List출력, 판매량+제조포인트 순
        public void PrintProduct(List<Product> resultList){
            foreach (Product var in resultList){
              string ss = string.Format("{0:D3} {1:D3} {2:D3} {3}",
                    var.GetPGrade(), var.GetPMoney(), 
                    (var.GetPAmount() + var.GetPPoint())
                    ,var.ToString());
                Console.WriteLine(ss);
            }
        }
        //매출액*제조포인트 순
        public void PrintPpoint(List<Product> resultList){
            foreach (Product var in resultList){
                string ss = string.Format("{0:D} {1:D3} {2:D3} ",
                      var.GetPPoint(), 
                      (var.GetPMoney() * var.GetPPoint())
                      , var.ToString());
                Console.WriteLine(ss);
            }
        }
        //Product List출력
        public void PrintProduct(){
            foreach (Product var in proList){
                Console.WriteLine(var);
            }
        }
    }
}
