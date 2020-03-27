using System;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    class ClientSocket
    {
        public static bool flag;
        public static int[,] send = new int[15, 10];
        public static int[,] receives = new int[15, 10];
        private static byte[] result = new byte[600];
        public Socket clientSocket;
        public ClientSocket(int[,] p_send)
        {
            flag = true;
            send = p_send;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //设定服务器IP地址  
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 2000)); //配置服务器IP与端口  
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
        }
        public void Main() {
            Thread myThread = new Thread(ListenClientConnect);//通过多线程监听客户端连接  
            myThread.Start();
            
        }
        private void ListenClientConnect()
        {
            while (true)
            {
                int receiveNumber = clientSocket.Receive(result);
                if (receiveNumber == 0)
                    return;
                receives = Bytes2Array(result);
                //给Client端返回信息
                clientSocket.Send(Array2Bytes(send));
                if (!flag)
                {
                    clientSocket.Close(); //关闭连接并释放资源
                    break;
                }  
            }
        }
        public byte[] Array2Bytes(int[,] array)
        {
            byte[] bytes = new byte[4 * array.Length / array.GetLength(1) * array.GetLength(1)];
            int n = 0;
            for (int i = 0; i < array.Length / array.GetLength(1); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    byte[] byInt = BitConverter.GetBytes(array[i, j]);
                    for (int k = 0; k < 4; k++)
                    {
                        bytes[n++] = byInt[k];
                    }

                }
            return bytes;
        }
        public int[,] Bytes2Array(byte[] bytes)
        {
            int x = 0, y = 0;
            int[,] vs = new int[15, 10];
            for (int i = 0; i < bytes.Length; i++)
            {
                byte[] b = new byte[4];
                b[i % 4] = bytes[i];
                if (i % 4 == 3)
                {
                    vs[x, y] = BitConverter.ToInt32(b, 0);
                    y++;
                    b[0] = 0;
                    b[1] = 0;
                    b[2] = 0;
                    b[3] = 0;
                    if (y % 10 == 0)
                    {
                        x++;
                        y = 0;
                    }
                }
            }
            return vs;
        }
        public static void stop()
        {
            flag = true;
        }
    }
}
