using System; //System�� �ִ� Console�� ����Ѵ�.

namespace Com.Jungbo.Basic
{
    /// <summary>
    /// �μ��� �Է¹޴´�. �� ���� ���� int�� ��ȯ��Ų��.
    /// �μ��� ���Ͽ� ����� ����Ѵ�.
    /// </summary>
    public class HelloMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("������ �Ϸ��� �մϴ�. �� ���� �Է��ϼ���.");

            Console.Write("ù��° ���� �Է��ϼ���: ");
            int num1 = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ

            Console.Write("�ι�° ���� �Է��ϼ���: ");
            int num2 = int.Parse(Console.ReadLine());//�� ��° �� �Է��� ��ȯ

            //{0}��ġ�� num1��, {1}��ġ�� num2�� ����.
            Console.WriteLine("�μ��� ��: {0}+{1}={2}",num1,num2,num1+num2);
        }
    }
}
