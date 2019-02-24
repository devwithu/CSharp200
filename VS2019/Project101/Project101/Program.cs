using System;
using System.IO;
using Com.JungBo.Infor;

namespace Com.JungBo.Basic
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