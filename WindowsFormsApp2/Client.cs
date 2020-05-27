using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApp2
{
    class Client
    {
        static Socket clientSocket;
        static Thread thread;

        static public void Start()
        {
            try
            {
                thread = new Thread(new ThreadStart(doWork));
                thread.Start();
            }
            catch
            {
                Console.WriteLine("链接失败");
            }
        }
        private static void doWork()
        {
            //将网络端点表示为IP地址和端口 用于socket侦听时绑定  
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3001); //填写自己电脑的IP或者其他电脑的IP，如果是其他电脑IP的话需将ConsoleApplication_socketServer工程放在对应的电脑上。 
            clientSocket = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //将Socket连接到服务器  
            try
            {
                clientSocket.Connect(ipep);
                String outBufferStr;
                Byte[] outBuffer = new Byte[8 * 1024];
                Byte[] inBuffer = new Byte[8 * 1024];
                while (true)
                {
                    //发送消息  
                    //outBufferStr = Console.ReadLine();
                    //outBuffer = Encoding.ASCII.GetBytes(outBufferStr);
                    //clientSocket.Send(outBuffer, outBuffer.Length, SocketFlags.None);

                    //接收服务器端信息        
                    //clientSocket.Receive(inBuffer, 1024, SocketFlags.None);//如果接收的消息为空 阻塞 当前循环 
                    //Console.WriteLine("服务器说：");
                    //Console.WriteLine(Encoding.ASCII.GetString(inBuffer));
                    outBuffer = Array2Bytes(Class1.all);
                    clientSocket.Send(outBuffer, outBuffer.Length, SocketFlags.None);
                    clientSocket.Receive(inBuffer, 8 * 1024, SocketFlags.None);
                    Class1.all2 = Bytes2Array(inBuffer);
                    Thread.Sleep(100);
                }
            }
            catch
            {
                Console.WriteLine("服务未开启！");
            }
        }
        public static byte[] Array2Bytes(int[,] array)
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
        public static int[,] Bytes2Array(byte[] bytes)
        {
            int x = 0, y = 0;
            int[,] vs = new int[15, 10];
            byte[] b = new byte[4];
            for (int i = 0; i < bytes.Length; i++)
            {
                b[i % 4] = bytes[i];
                if (i % 4 == 3)
                {
                    if (x >= 15 || y >= 10) break;
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
        public static void Stop()
        {
            try
            {
                thread.Abort();
            }
            catch
            {

            }

        }
    }
}
