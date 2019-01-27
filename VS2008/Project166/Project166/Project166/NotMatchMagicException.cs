using System;
namespace Com.JungBo.Logic
{
    public class NotMatchMagicException:ApplicationException
    {
        public NotMatchMagicException(string message) 
        :base(message){ }
        public NotMatchMagicException()
            :this("1, 2 마방진은 존재하지 않습니다."){ }

    }
}
