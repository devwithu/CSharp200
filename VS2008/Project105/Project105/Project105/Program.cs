using System;
using Com.JungBo.Infor;
namespace Project104
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileSearcher fsr = new FileSearcher();
            //재귀를 돌면서 하위디렉토리의 정보 모두 출력
            //재귀는 많은 시간이 걸릴 수 있다.
            fsr.InforView(
@"C:\Documents and Settings\Administrator\My Documents");
        }
    }
}
