#define Trace
using System;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;

public class Myclass
{
    //创建套接字  
    static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private static byte[] result = new byte[1024];
    static void Main(string[] args)
    {
        SocketServie();
    }
    public static void SocketServie()
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
    private static void ListenClientConnect()
    {
        while (true)
        {
            Socket clientSocket = socket.Accept();
            //clientSocket.Send(Encoding.UTF8.GetBytes("服务器连接成功"));
            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start(clientSocket);
        }
    }

    /// <summary>  
    /// 接收消息  
    /// </summary>  
    /// <param name="clientSocket"></param>  
    private static void ReceiveMessage(object clientSocket)
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
                Console.WriteLine("接收客户端{0} 的消息：{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(result, 0, receiveNumber));
                //给Client端返回信息
                int[] S = new int[54];
                
                for (int i = 0; i < 54; i++)
                {
                    S[i] = i;

                }
                //System.ArraySegment<byte> bs1 = new ArraySegment<byte>(Encoding.UTF8.GetBytes("aaaaaaaaa"));
                //List<ArraySegment<byte>> byteList = new List<ArraySegment<byte>>();
                //byteList.Add(bs1);
                //bs1 = new ArraySegment<byte>(Encoding.UTF8.GetBytes("bbbbbbbbbbbbb"));
                //byteList.Add(bs1);
                //myClientSocket.Send(byteList);
                byte[] vs = new byte[4];
                int jj = 123;
                vs = BitConverter.GetBytes(jj);
                myClientSocket.Send(vs);
                myClientSocket.Close(); //发送完数据关闭Socket并释放资源
                Console.ReadLine();
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
    byte[] Array2Bytes(int[,] array){
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

    private void Form1_Load(object sender, EventArgs e){
        int[,] arrInt = new int[3, 4];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
            {
                arrInt[i, j] = (i + 1) * (j + 1);
            }
        byte[] bytes = Array2Bytes(arrInt);
        File.WriteAllBytes("d:\\test.bin", bytes);
    }
}