using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Logic {

    public class UnFittableException:ApplicationException
    {
        public UnFittableException(string message)
        :base(message){ }
        public UnFittableException()
        :this("0�̳� ������ �ü� �����ϴ�."){ }
    }
}
