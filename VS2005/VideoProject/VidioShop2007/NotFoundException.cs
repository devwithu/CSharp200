using System;
using System.Collections.Generic;
using System.Text;

namespace VidioShop2007
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException() : this("해당 고객이 등록되어 있지 않습니다")
        {
        }
    }
}
