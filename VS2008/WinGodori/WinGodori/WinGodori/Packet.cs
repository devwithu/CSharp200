using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace WinGodori
{
    enum CMD { START = 1, HIT = 2, UNDO = 3 }

    // 전송 규칙
    // 게임이 시작되면 
    // 보내는 사람은 처음에는 무조건 모든 카드의 인덱스를 전송한다 ( 50 장)
    // 받는 사람은 처음에는 무조건 모든 카드를 받는다
    // 다음부터는 자신이 친 카드의 인덱스를 전송 받는다.

     class Packet
    {
        public byte cmd;            // 명령어
        public int[] total_card = new int[48];  // 처음에 모든 카드를 한번 받는다
        public int cardnum;  // 받은 카드 인덱

        public Packet(byte cmd, int[] buffer)   // 생성자로 패킷을 생성
        {                                      // 201 byte packet   
            this.cmd = cmd;
            this.total_card = buffer;
        }
        // 친 카드에 인덱스를 패킷한다.
        public Packet(byte cmd, int cnum) // 5byte packet 
        {
            this.cmd = cmd;
            this.cardnum = cnum;
        }
        // 자신을 byte[]로 바꾸어주는 함수
        // 전체 카드를 바이트로
        public byte[] GetBytes()
        {
            byte[] data = new byte[193];

            data[0] = cmd;
            int j = 0;
            //상대방이 받아서 분배 해줄 카드이므로 카드순서를 바꿔준다.
            //상대편에게서 내 카드가 상대편이고 자신의 카드가 상대편이므로
            for (int i = 10; i < 20; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);
            for (int i = 0; i < 10; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);
            for (int i = 20; i < 48; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);

            return data;
        }
        // 친 카드에 카드번호만을 바이트로
        public byte[] GetBytesCardNum()
        {
            byte[] data = new byte[5];

            data[0] = cmd;
            Buffer.BlockCopy(BitConverter.GetBytes(cardnum), 0, data, 1, 4);

            return data;
        }

        // byte[] -> packet 를 만들어 주는 생성자
        public Packet(byte[] data, int cnt)
        {
            if (cnt == 11)
            {
                if (data.Length != 193) throw new Exception("Bad Packet");

                cmd = data[0];
                for (int i = 0; i < 48; i++)
                    total_card[i] = BitConverter.ToInt32(data, (i * 4) + 1);
            }
            else
            {
                if (data.Length != 5) throw new Exception("Bad Packet2");

                cmd = data[0];
                cardnum = BitConverter.ToInt32(data, 1);
            }
        }
    }
}