using System;
namespace Com.JungBo.Games{
    public enum BombState { EMPTY = 0, ONE = 1, TWO,THREE, FOUR,
    FIVE, SIX, SEVEN, EIGHT, END = 10, FLAGEND = 11, BOMB = 12 };
    public enum OpenState { CLOSE = 0, OPEN, FLAG, QUESTION };
    public struct Block{
        public BombState bState;
        public OpenState oState;
        public bool down;
    };
    public struct Position{
        public int row;
        public int col;
    };
    public struct Order{
        public int first;
        public int second;
        public int third;
    };
}