using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logger
{
    public interface IJungBoLogger
    {
        void Write(string message);
        void WriteAll(IList<string> messageList);
    }
}
