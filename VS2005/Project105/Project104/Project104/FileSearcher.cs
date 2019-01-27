using System;
using System.IO;
namespace Com.JungBo.Infor{
    public class FileSearcher{
        public void InforView(string fname)  {
            //현재 디렉토리의 하위디렉토리
            string[] dirs = Directory.GetDirectories(fname);

            foreach (string dir in dirs){
                DirectoryInfo direcs = new DirectoryInfo(dir);
                //디렉토리 정보
                Console.WriteLine("------------------------------");
                Console.WriteLine("이름 : {0}", direcs.Name);
                Console.WriteLine("속성 : {0}", direcs.Attributes);
                Console.WriteLine("상세이름 : {0}", direcs.FullName);
                //Console.WriteLine("작성일 : {0}", direcs.CreationTime);
                //더이상 하위 디렉토리를 갖지 않으면
                if (!Directory.Exists(dir)){
                    return;//끝 - 끝나는 조건이 명시되어야 한다.
                }
                else {   //주의 하위 디렉토리를 모두 보여준다.
                    //하위 디렉토리가 있다면 자신을 호출 -재귀
                    InforView(dir);
                }
            }
        }
    }//class
}
