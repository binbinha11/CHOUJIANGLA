using System;
using System.IO;
using System.Collections;
namespace Study1
{
    class Rectangle
    {
        //成员变量
        private double length;
        private double width;

        public void Acceptdetails()
        {
            Console.WriteLine("请输入长度：");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入宽度：");
            try
            {
                width = Convert.ToDouble(Console.ReadLine());
            }
            catch {
                Console.WriteLine("输入错误");
                return;
            }

        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("长度： {0}", length);
            Console.WriteLine("宽度： {0}", width);
            Console.WriteLine("面积： {0}", GetArea());
        }
        public void TestArray() {
            int[] array1 = new int[] {1,2,3,4,5,6,7,8,9,10,11,12 };
            foreach (int i in array1) {
                Console.WriteLine(i);
            }
        }
        public void writefile() {
            string[] name = new string[] {"12","34","45","56","78" };
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lizb2\\Desktop\\1.txt")) {
                foreach (string i in name) {
                    sw.WriteLine(i);
                }
            }
        }
        public void readfile(ref ArrayList result) {
            string line = "";
            using (StreamReader sr = new StreamReader("C:\\Users\\lizb2\\Desktop\\1.txt"))
            {
                while ((line = sr.ReadLine()) != null) {
                    result.Add(line);
                }
            }
        }
    }//end class Rectangle    
    class ExecuteRectangle
    {
        //static void main(string[] args)
        //{
        //    arraylist arraylist = new arraylist();
        //    rectangle r = new rectangle();
        //    r.acceptdetails();
        //    r.display();
        //    r.testarray();
        //    r.writefile();
        //    r.readfile(ref arraylist);
        //    foreach (string i in arraylist) {
        //        console.writeline(i);
        //    }
        //}
    }
}
