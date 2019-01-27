using System;
using System.Collections.Generic;
using System.Text;

namespace VidioShop2007
{
    public class FoundException : ApplicationException
    {
        public FoundException(string message) : base(message)
        {
        }

        public FoundException() : this("고객이 이미 등록 되어 있습니다")
        {
        }
    }
}
