using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Logic {

    public class UnFittableException:ApplicationException
    {
        public UnFittableException(string message)
        :base(message){ }
        public UnFittableException()
        :this("0이나 음수가 올수 없습니다."){ }
    }
}
