using System;
using Com.JungBo.Infor;
using System.IO;
namespace Project101
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DriverView drivew = new DriverView();
            drivew.ShowDrives();
            drivew.ShowComputerInfor();
            drivew.ShowDriveInfor();
        }
    }
}
