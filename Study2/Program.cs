using System;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Study2
{
    class Program
    {
        static void Main(string[] args)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

            string sendMessage = "你好";//发送到服务端的内容
            clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));//向服务器发送数据，需要发送中文则需要使用Encoding.UTF8.GetBytes()，否则会乱码
            Console.WriteLine("向服务器发送消息：" + sendMessage);

            //接受从服务器返回的信息
            //string recvStr = "";
            //byte[] recvBytes = new byte[1024];
            //int bytes;
            //List<ArraySegment<byte>> byteList = new List<ArraySegment<byte>>(2);
            //byteList.Add(recvBytes);
            //byteList.Add(recvBytes);
            //bytes = clientSocket.Receive(byteList);
            //foreach (var item in byteList)
            //{
            //    recvStr += Encoding.UTF8.GetString(item);
            //    Console.WriteLine("服务端发来消息：{0}\n", recvStr);
            //}
            int jj;
            byte[] vs = new byte[4];
            clientSocket.Receive(vs);
            jj = BitConverter.ToInt32(vs);
            Console.WriteLine("服务端发来消息：{0}\n", jj);
            clientSocket.Close(); //关闭连接并释放资源
            Console.ReadLine();
        }
    }
}
