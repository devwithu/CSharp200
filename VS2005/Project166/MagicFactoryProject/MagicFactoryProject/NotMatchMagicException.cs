using System;
namespace Com.JungBo.Logic
{
    public class NotMatchMagicException:ApplicationException
    {
        public NotMatchMagicException(string message) 
        :base(message){ }
        public NotMatchMagicException()
            :this("1, 2 �������� �������� �ʽ��ϴ�."){ }

    }
}
