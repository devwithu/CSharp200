using System;
namespace Com.JungBo.Logic{
    //�����հ�
	public class InstallmentSavings{
		//���ݱ��ϱ�
		public static double Savings(double a, double r,int n){
			double tot=0;
			double temp=a;   //a(1+r)^n
			int year=n*12;   //1���� 12��
			for(int i=0;i<year;i++){
				temp*=(1+r/100.0/12.0);  //4.6/100/12
				tot+=temp;
			}
			return tot;
		}
	}
}
