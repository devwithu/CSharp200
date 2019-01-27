using System;
using Com.JungBo.School;
namespace Project104 {
    public class Program {
        public static void Main(string[] args){
            //����, ����-> �ʱ�ȭ �ȵ�
            YenaGrade[] yg = new YenaGrade[5];
            yg[0] = new YenaGrade(30, 60, 100);//�ʱ�ȭ
            yg[1] = new YenaGrade(90, 70, 80);
            yg[2] = new YenaGrade(40, 90, 60);
            yg[3] = new YenaGrade(60, 67, 89);
            yg[4] = new YenaGrade(100, 100, 80);
            Print(yg);
            //������������ ���� �������� DESC
            YenaGradeComparer ygcomp = new YenaGradeComparer();
            Array.Sort(yg, ygcomp);   //������ ����
            Console.WriteLine("========After==============");
            Print(yg);
            Array.Reverse(yg);  //ASC
            Console.WriteLine("========Reverse==============");
            Print(yg);
        }
        //�迭�� ������Ʈ�� ������� ���
        public static void Print(YenaGrade[] yg){
            foreach (YenaGrade ygrade in yg){
                Console.WriteLine(ygrade);
            }
        }
    }
}
