using System;
using System.Collections;//IComparer
namespace Com.JungBo.School{
    public class YenaGradeComparer:IComparer{
        //IComparer�� Comparer����-> �� ��ü��
        public int Compare(object x, object y){
            YenaGrade yg1 = x as YenaGrade;
            YenaGrade yg2 = y as YenaGrade;
            //����� ���� �Ϳ��� ���� ������
            if (yg1.Avg > yg2.Avg){
                return -1; //DES
            }
            else if (yg1.Avg < yg2.Avg){
                return 1;//ASC
            }
            else {//����� ������� ���������� �Ǵ�
                if (yg1.Kor > yg2.Kor){
                    return -1; //DES
                }
                else if (yg1.Kor < yg2.Kor){
                    return 1;//ASC
                }
                else return 0;
            }
        }//Compare
    }
}
