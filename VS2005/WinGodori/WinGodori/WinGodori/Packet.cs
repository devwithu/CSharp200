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

    // ���� ��Ģ
    // ������ ���۵Ǹ� 
    // ������ ����� ó������ ������ ��� ī���� �ε����� �����Ѵ� ( 50 ��)
    // �޴� ����� ó������ ������ ��� ī�带 �޴´�
    // �������ʹ� �ڽ��� ģ ī���� �ε����� ���� �޴´�.

     class Packet
    {
        public byte cmd;            // ��ɾ�
        public int[] total_card = new int[48];  // ó���� ��� ī�带 �ѹ� �޴´�
        public int cardnum;  // ���� ī�� �ε�

        public Packet(byte cmd, int[] buffer)   // �����ڷ� ��Ŷ�� ����
        {                                      // 201 byte packet   
            this.cmd = cmd;
            this.total_card = buffer;
        }
        // ģ ī�忡 �ε����� ��Ŷ�Ѵ�.
        public Packet(byte cmd, int cnum) // 5byte packet 
        {
            this.cmd = cmd;
            this.cardnum = cnum;
        }
        // �ڽ��� byte[]�� �ٲپ��ִ� �Լ�
        // ��ü ī�带 ����Ʈ��
        public byte[] GetBytes()
        {
            byte[] data = new byte[193];

            data[0] = cmd;
            int j = 0;
            //������ �޾Ƽ� �й� ���� ī���̹Ƿ� ī������� �ٲ��ش�.
            //������Լ� �� ī�尡 ������̰� �ڽ��� ī�尡 ������̹Ƿ�
            for (int i = 10; i < 20; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);
            for (int i = 0; i < 10; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);
            for (int i = 20; i < 48; i++, j++)
                Buffer.BlockCopy(BitConverter.GetBytes(total_card[i]), 0, data, (j * 4) + 1, 4);

            return data;
        }
        // ģ ī�忡 ī���ȣ���� ����Ʈ��
        public byte[] GetBytesCardNum()
        {
            byte[] data = new byte[5];

            data[0] = cmd;
            Buffer.BlockCopy(BitConverter.GetBytes(cardnum), 0, data, 1, 4);

            return data;
        }

        // byte[] -> packet �� ����� �ִ� ������
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