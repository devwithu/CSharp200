using System;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("���ϴ� ���ڿ��� �Է��ϼ���.");
            string message = Console.ReadLine();//���ڿ� ����
            Console.WriteLine("���ڿ� ���: {0}", message);

            Console.WriteLine("������ ������ �Ϸ��� �մϴ�.");
            Console.Write("ù��° ���� �Է��ϼ���: ");
            //ù ��° �� �Է��� ��ȯ
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("�ι�° ���� �Է��ϼ���: ");
            //�� ��° �� �Է��� ��ȯ
            int num2 = int.Parse(Console.ReadLine());

            //{0}��ġ�� num1��, {1}��ġ�� num2�� ����.
            Console.WriteLine("�μ��� ��: {0}+{1}={2}",
                num1, num2, num1 + num2);

            Console.WriteLine("�Ǽ��� ������ �Ϸ��� �մϴ�.");
            Console.Write("ù��° ���� �Է��ϼ���: ");
            double num3 = double.Parse(Console.ReadLine());

            Console.Write("�ι�° ���� �Է��ϼ���: ");
            double num4 = double.Parse(Console.ReadLine());

            //{0}��ġ�� num3��, {1}��ġ�� num4�� ����.
            Console.WriteLine("�μ��� ��: {0}+{1}={2}", 
                num3, num4, num3+ num4);
        }
    }
}
