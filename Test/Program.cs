using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] intarray = new int[3, 2];
            Byte[] barray= new Byte[1024];
            barray[0] = 1;
            barray[10] = 1;
            barray[20] = 1;
            intarray = Bytes2Array(barray);
        }
        public static int[,] Bytes2Array(byte[] bytes)
        {
            byte[] b = new byte[4];
            int x = 0, y = 0;
            int[,] vs = new int[3, 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                b[i % 4] = bytes[i];
                if (i % 4 == 3)
                {
                    if (x>=3||y>=2) {
                        break;
                    }
                    vs[x, y] = BitConverter.ToInt32(b, 0);
                    y++;
                    b[0] = 0;
                    b[1] = 0;
                    b[2] = 0;
                    b[3] = 0;
                    if (y % 2 == 0)
                    {
                        x++;
                        y = 0;
                    }
                }
            }
            return vs;
        }
    }
}
