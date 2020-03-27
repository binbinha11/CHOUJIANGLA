using System;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    class ServeSocket
    {
        public static bool flag;
        public static int[,] send = new int[15,10];
        public static int[,] receives = new int[15,10];
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] result = new byte[600];
        public ServeSocket(int[,] p_send) {
            flag = true;
            send = p_send;
        }
        public void Main()
        {
            SocketServie();
        }
        public void SocketServie()
        {
            Console.WriteLine("服务端已启动");
            string host = "127.0.0.1";//IP地址
            int port = 2000;//端口
            socket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
            socket.Listen(100);//设定最多100个排队连接请求   
            Thread myThread = new Thread(ListenClientConnect);//通过多线程监听客户端连接  
            myThread.Start();
            Console.ReadLine();
        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = socket.Accept();
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result);
                    if (receiveNumber == 0)
                        return;
                    receives = Bytes2Array(result);
                    //给Client端返回信息
                    myClientSocket.Send(Array2Bytes(send));
                    if (!flag)
                    {
                        myClientSocket.Close(); //发送完数据关闭Socket并释放资源
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);//禁止发送和上传
                    myClientSocket.Close();//关闭Socket并释放资源
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
        public static void stop() {
            flag = true;
        }
    }
}
