using System;//Environment
using System.IO;//DriveInfo
namespace Com.JungBo.Infor {
    public class DriverView {
        //내 컴퓨터 드라이브 보이기
        public void ShowDrives(){
            string[] drivers = Environment.GetLogicalDrives();
            Console.WriteLine("Drives");
            foreach (string st in drivers){
                Console.WriteLine("{0}", st);
            }
        }//
        //내 컴퓨터 드라이브 상세 보이기
        public void ShowDriveInfor(){
            DriveInfo[] drivers = DriveInfo.GetDrives();
            Console.WriteLine("Drives");
            foreach (DriveInfo st in drivers){
                Console.WriteLine("-----------------");
                //switch(st.DriveType){
                //    case DriveType.CDRom:
                //        PrintDriverInfo(st); break;
                //    case DriveType.Fixed:
                //        PrintDriverInfo(st); break;
                //    default:
                //        PrintDriverInfo(st); break;
                //}
                PrintDriverInfo(st);
            }
        }//
        private void PrintDriverInfo(DriveInfo dinfo) {
            Console.WriteLine("DriveType: {0}", dinfo.DriveType);
            Console.WriteLine("Name: {0}", dinfo.Name);
            Console.WriteLine("RootDirectory: {0}", dinfo.RootDirectory);
            if(dinfo.IsReady){  //드라이버가 준비되었나
                Console.WriteLine("TotalSize: {0}", dinfo.TotalSize);
                Console.WriteLine("VolumeLabel: {0}", dinfo.VolumeLabel);
                Console.WriteLine("DriveFormat: {0}", dinfo.DriveFormat);
            }
        }
        public void ShowComputerInfor() {
            string platform = Environment.OSVersion.Platform.ToString();
            string servicepack=Environment.OSVersion.ServicePack;
            //Major, Minor
            string version=Environment.OSVersion.Version.ToString();
            string versionString=Environment.OSVersion.VersionString;
            string workme=(Environment.WorkingSet/1000).ToString();
            int processcount = Environment.ProcessorCount;
            string netbios = Environment.MachineName;
            string domain = Environment.UserDomainName;
            string dir = Environment.CurrentDirectory;
            Console.WriteLine("Platform : {0}", platform);
            Console.WriteLine("ServicePack : {0}", servicepack);
            Console.WriteLine("Version : {0}", version);
            Console.WriteLine("VersionString : {0}", versionString);
            Console.WriteLine("WorkingSet : {0}KB", workme);
            Console.WriteLine("ProcessorCount : {0}", processcount);
            Console.WriteLine("MachineName : {0}", netbios);
            Console.WriteLine("UserDomainName : {0}", domain);
            Console.WriteLine("CurrentDirectory : {0}", dir);
        }
    }
}
