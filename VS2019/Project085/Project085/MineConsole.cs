using System;
namespace Com.JungBo.Games{
    public class MineConsole{
        Block[,] board;
        Position[] pos;
        int boardsize = 20;
        int mine = 20;
        public MineConsole() { InitMine();  }

        // ���带 �ʱ�ȭ �Ѵ�.
        private void InitMine(){
            board = new Block[boardsize, boardsize];// ����
            pos = new Position[mine];  // ���� ��ġ ����
            for (int i = 0; i < boardsize; i++){
                for (int j = 0; j < boardsize; j++){
                    board[i, j].bState = BombState.EMPTY;
                    board[i, j].oState = OpenState.CLOSE;
                    board[i, j].down = false;
                }
            }
            SetMine(); // ���� ����
            CalMine();  // ���� ���
        }
        // ���ڸ� �������� ��ġ�Ѵ�.
        private void SetMine() {
            Random r = new Random();
            int count = 0;
            int row = 0;
            int col = 0;

            while (true){
                if (count == mine) break;
                row = r.Next(boardsize);
                col = r.Next(boardsize);
                if (board[row, col].bState != BombState.BOMB){
                    pos[count].row = row;
                    pos[count].col = col;
                    count++;
                    board[row, col].bState = BombState.BOMB;
                }
            }
        }
        // �ֺ��� ���� ���� ���
        private void CalMine(){
            for (int t = 0; t < mine; t++){
                int x = pos[t].row;
                int y = pos[t].col;
                for (int i = x - 1; i <= x + 1; i++){
                  for (int j = y - 1; j <= y + 1; j++){
                      //�ڽ��� ��ź�� �ƴϰ� ���ۿ� ���� �ʴٸ�
                      if (i >= 0 && j >= 0 && i <= (boardsize - 1) &&
                         j <= (boardsize - 1) &&
                         board[i, j].bState != BombState.BOMB)
                         board[i, j].bState++;
                  }
                }
            }
        }
        //��ź�� ��ġ�ϰ�, �ֺ��� ��ź ����ϰ�
        public void Make(){
            SetMine();
            CalMine();
        }
        //���ڰ��� ȭ�鿡 ���̱�
        public void Print() {
            for (int i = 0; i < boardsize; i++){
                for (int j = 0; j < boardsize; j++){
                    //2�ڷ� ��� enum�� int�� ��ȯ�ؼ�
                    Console.Write("{0,2} ",(int)(board[i,j].bState));
                }
                Console.WriteLine();
            }
        }

    }

}