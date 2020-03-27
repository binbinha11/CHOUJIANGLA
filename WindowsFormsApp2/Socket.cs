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
    class SocketAll
    {
        //创建套接字  
        public static int[,] array;
        static int[,] all;
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static Socket clientSocket;
        static bool flag;//true:serve false:client
        private static byte[] result = new byte[16];
        public SocketAll(int[,] p_array,int[,] p_all) {
            array = p_array;
            all = p_all;
        }
        public static void OpenSocket(bool p_flag)
        {
            flag = p_flag;
            if (flag){
               SocketServie();
            }else{
                SocketClient();
            }
            
        }

        private static void SocketClient()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 2000)); //配置服务器IP与端口  

            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
            while (true)
            {
                int receiveNumber = clientSocket.Receive(result);
                if (receiveNumber == 0)
                    return;
                array = Bytes2Array(result);
                clientSocket.Send(Array2Bytes(all));
                System.Threading.Thread.Sleep(1000);  //2秒
            }
           
        }

        public static void SocketServie()
        {
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
        private static void ListenClientConnect()
        {
            while (true)
            {
                clientSocket = socket.Accept();
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage()
        {
            Socket myClientSocket = clientSocket;
            while (true)
            {
                try
                {
                    int receiveNumber = myClientSocket.Receive(result);
                    if (receiveNumber == 0)
                        return;
                    array = Bytes2Array(result);
                    myClientSocket.Send(Array2Bytes(all));
                    System.Threading.Thread.Sleep(1000);  //2秒
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
            int x = 0,y = 0;
            int[,] vs = new int[15,10];
            for (int i = 0; i < bytes.Length; i ++) {
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
        public static void CloseSocket() {
            try
            {
                clientSocket.Close(); //发送完数据关闭Socket并释放资源
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
