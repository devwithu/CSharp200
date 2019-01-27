using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Kisa{
    public class JungBoManager{
        //������ �о ��ǰ�������ڿ��� List�� ����
        YenaItFiles yena = new YenaItFiles();
        //��ǰ�������ڿ��� ��ǰ ��ü�� �ٲ㼭 ����
        List<Product> proList = new List<Product>(10);
        //�־��� ���ǿ� �´� ��ǰ List�� ��� �޼��� ����
        ProductList pros = new ProductList();

        public void printJungBo(string fname) {
            yena.FileRead(fname);  //�о �������ڿ� List�� ����
            //yena.Print();        //����� ���� Ȯ��
            stringToProduct();
        }
        //�������ڿ��� Product List�ٲ㼭 ����
        public void stringToProduct(){
            List<string> pstr = yena.ProductList;
            proList = pros.getAllProducts(pstr);
        }

        public void solveOne(){ 
            string [] gradeStr={"C"};
            //��������� C
            List<Product> splist = 
                pros.getAllProdInGrade(gradeStr, proList);
            List<Product> molist = 
                pros.getAllProdWithPMoney(80, splist);
            //��ǰ �񱳸� ���� ��
            ProductComparator pcom = new ProductComparator();
            //���Ǵ�� ����
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
            //��������Ʈ�� 30�̻�
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
        //Product List���, �Ǹŷ�+��������Ʈ ��
        public void PrintProduct(List<Product> resultList){
            foreach (Product var in resultList){
              string ss = string.Format("{0:D3} {1:D3} {2:D3} {3}",
                    var.GetPGrade(), var.GetPMoney(), 
                    (var.GetPAmount() + var.GetPPoint())
                    ,var.ToString());
                Console.WriteLine(ss);
            }
        }
        //�����*��������Ʈ ��
        public void PrintPpoint(List<Product> resultList){
            foreach (Product var in resultList){
                string ss = string.Format("{0:D} {1:D3} {2:D3} ",
                      var.GetPPoint(), 
                      (var.GetPMoney() * var.GetPPoint())
                      , var.ToString());
                Console.WriteLine(ss);
            }
        }
        //Product List���
        public void PrintProduct(){
            foreach (Product var in proList){
                Console.WriteLine(var);
            }
        }
    }
}
