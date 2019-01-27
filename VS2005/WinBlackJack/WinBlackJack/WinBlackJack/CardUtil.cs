using System;
using System.Collections.Generic;
using System.Text;

namespace WinBlackJack
{
    [FlagsAttribute]
    public enum BJCMD { DOUBLE = 1, HIT = 2, STAND = 4 }
    public enum STATE { NOTBJ = 1, BJ = 2, BUST = 4 }
    public enum CMDSTATE { NORMAL, INSURANCETIME, FIRSTDEAL }

    public class CardUtil
    {
        public readonly static char[] SUIT = {'S','H','D','C'};
        public readonly static string[] DECK = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
    }
}
