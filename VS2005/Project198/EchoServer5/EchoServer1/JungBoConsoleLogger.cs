using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
namespace Com.JungBo.Logger
{
    public class JungBoConsoleLogger: IJungBoLogger
    {
        private static Mutex mutex = new Mutex();
 

        public void Write(string message)
        {
            mutex.WaitOne();
            string dstes = DateTime.Now.ToString("[yyyy-MM-dd:hh-mm-ss]: ");
            Console.Write(dstes);
            Console.WriteLine(message);
            mutex.ReleaseMutex();
        }

        public void WriteAll(IList<string> messageList)
        {
            mutex.WaitOne();
            string dstes = DateTime.Now.ToString("[yyyy-MM-dd:hh-mm-ss]: ");
            Console.WriteLine(dstes);
            foreach (string message in messageList)
            {
                Console.WriteLine(message);
            }
            mutex.ReleaseMutex();
        }
    }
}
