using System;
using Com.JungBo.Infor;
namespace Project104{
    public class Program{
        public static void Main(string[] args){
            FileSearcher fsr = new FileSearcher();
            //��͸� ���鼭 �������丮�� ���� ��� ���
            //��ʹ� ���� �ð��� �ɸ� �� �ִ�.
            fsr.InforView(
@"C:\Documents and Settings\Administrator\My Documents");
        }
    }
}
