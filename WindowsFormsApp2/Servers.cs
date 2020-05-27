using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Servers
    {
        static Socket serverSocket;
        static Socket clientSocket;
        static Thread thread;
        static public void Start()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 3001);
                serverSocket = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(ipep);
                serverSocket.Listen(10);
                clientSocket = serverSocket.Accept();
                thread = new Thread(new ThreadStart(doWork));
                thread.Start();
            }
            catch
            {
                Console.WriteLine("服务器未开启！");
            }

        }
        private static void doWork()
        {
            Socket s = clientSocket;//客户端信息 
            IPEndPoint ipEndPoint = (IPEndPoint)s.RemoteEndPoint;
            String address = ipEndPoint.Address.ToString();
            String port = ipEndPoint.Port.ToString();
            Byte[] inBuffer = new Byte[8 * 1024];
            Byte[] outBuffer = new Byte[8 * 1024];
            
            try
            {
                while (true)
                {
                    outBuffer = Array2Bytes(Class1.all);
                    s.Send(outBuffer, outBuffer.Length, SocketFlags.None);
                    s.Receive(inBuffer, 8 * 1024, SocketFlags.None);
                    Class1.all2 = Bytes2Array(inBuffer);
                    //s.Receive(inBuffer, 1024, SocketFlags.None);//如果接收的消息为空 阻塞 当前循环 
                    //inBufferStr = Encoding.ASCII.GetString(inBuffer);
                    //Console.WriteLine(address + ":" + port + "说:");
                    //Console.WriteLine(inBufferStr);
                    //outBufferStr = Console.ReadLine();
                    //outBuffer = Encoding.ASCII.GetBytes(outBufferStr);
                    //s.Send(outBuffer, outBuffer.Length, SocketFlags.None);
                    Thread.Sleep(100);
                }
            }
            catch
            {
                Console.WriteLine("客户端已关闭！");
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
        public static void Stop() {
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
