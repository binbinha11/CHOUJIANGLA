using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Class1
    {
        static int width = 10;
        static int height = 15;
        public int x, y, core;
        char q;
        public int[,]shapeall = new int[4,4];
        static public int[,]a = new int[3, 2] { { 0, 1 },{ 0, 1 },{1, 1 } };
        static public int[,]b = new int[3, 2] { { 1, 0 }, { 1, 0 }, { 1, 1 } };
        static public int[,] c = new int[3, 2] { { 1, 0 }, { 1, 1 }, { 1, 0 } };
        static public int[,] d = new int[3, 2] { { 0, 1 }, { 1, 1 }, { 0, 1 } };
        static public int[,] e = new int[3, 2] { { 1, 1 }, { 1, 0 }, { 1, 0 } };
        static public int[,] f = new int[3, 2] { { 1, 1 }, { 0, 1 }, { 0, 1 } };
        static public int[,] p = new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } };
        static public int[,] t = new int[3, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 } };

        static public int[,] j = new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } };
        static public int[,] k = new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } };
        static public int[,] l = new int[2, 3] { { 1, 1, 1 }, { 1, 0, 0 } };
        static public int[,] m = new int[2, 3] { { 1, 1, 1 }, { 0, 0, 1 } };
        static public int[,] n = new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } };
        static public int[,] o = new int[2, 3] { { 1, 1, 1 }, { 0, 1, 0 } };
        static public int[,] r = new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } };
        static public int[,] s = new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } };
        static public int[,] g = new int[1, 4]{ { 1, 1, 1, 1 } };
        static public int[,] h = new int[4, 1] { { 1 }, { 1 }, { 1 },{ 1 } };
        static public int[,] i = new int[2, 2] { { 1, 1 }, { 1, 1 }};

        public static int[,]all = new int[height, width];
        
        public Class1() {
            x = 0;
            y = 0;
            core = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    all[i, j] = 0;
                }
            }
            this.CreateShape();

        }
        public List<Rectangle> ArrayToRectangle(int[,] array) {
            List<Rectangle> l = new List<Rectangle>();
            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j < width ; j++)
                {
                    if (array[i,j] % 2 == 1)
                    {
                        Rectangle r = new Rectangle((j) * 25 , (i) * 25 , 25 ,25);
                        l.Add(r);
                    }
                }
            }
            return l;
        }
        public bool IsOver() {
            for (int i = 0; i < width; i++)
            {
                if (all[0, i] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public void ChangedShape() {
            int[,] array = new int[4, 4];
            switch (q) {
                case 'a':
                    if (ClearZero(x, y, 2, 3, k))
                    {
                        q = 'k';
                        array = k;
                        ShapeToAll(array);
                    }
                    
                    break;
                case 'k':
                    if (ClearZero(x, y, 3, 2, e))
                    {
                        q = 'e';
                        array = e;
                        ShapeToAll(array);
                    }                  
                    break;
                case 'e':
                    if (ClearZero(x, y, 2, 3, m))
                    {
                        q = 'm';
                        array = m;
                        ShapeToAll(array);
                    }
                    break;
                case 'm':
                    if (ClearZero(x, y, 3, 2, a))
                    {
                        q = 'a';
                        array = a;
                        ShapeToAll(array);
                    }
                    break;
                case 'b':
                    if (ClearZero(x, y, 2, 3, l))
                    {
                        q = 'l';
                        array = l;
                        ShapeToAll(array);
                    } 
                    break;
                case 'l':
                    if (ClearZero(x, y, 3, 2, f))
                    {
                        q = 'f';
                        array = f;
                        ShapeToAll(array);
                    }
                    break;
                case 'f':
                    if (ClearZero(x, y, 2, 3, j))
                    {
                        q = 'j';
                        array = j;
                        ShapeToAll(array);
                    }
                    break;
                case 'j':
                    if (ClearZero(x, y, 3, 2, b))
                    {
                        q = 'b';
                        array = b;
                        ShapeToAll(array);
                    }
                    break;
                case 'c':
                    if (ClearZero(x, y, 2, 3, o))
                    {
                        q = 'o';
                        array = o;
                        ShapeToAll(array);
                    }
                    break;
                case 'o':
                    if (ClearZero(x, y, 3, 2, d))
                    {
                        q = 'd';
                        array = d;
                        ShapeToAll(array);
                    }
                    break;
                case 'd':
                    if (ClearZero(x, y, 2, 3, n))
                    {
                        q = 'n';
                        array = n;
                        ShapeToAll(array);
                    }
                    break;
                case 'n':
                    if (ClearZero(x, y, 3, 2, c))
                    {
                        q = 'c';
                        array = c;
                        ShapeToAll(array);
                    }
                    break;
                case 'g':
                    if (ClearZero(x, y, 4, 1, h))
                    {
                        q = 'h';
                        array = h;
                        ShapeToAll(array);
                    }
                    break;
                case 'h':
                    if (ClearZero(x, y, 1, 4, g))
                    {
                        q = 'g';
                        array = g;
                        ShapeToAll(array);
                    }
                    break;
                case 'p':
                    if (ClearZero(x, y, 2, 3, s))
                    {
                        q = 's';
                        array = s;
                        ShapeToAll(array);
                    }

                    break;
                case 's':
                    if (ClearZero(x, y, 3, 2, p))
                    {
                        q = 'p';
                        array = p;
                        ShapeToAll(array);
                    }
                    break;
                case 't':
                    if (ClearZero(x, y, 2, 3, r))
                    {
                        q = 'r';
                        array = r;
                        ShapeToAll(array);
                    }

                    break;
                case 'r':
                    if (ClearZero(x, y, 3, 2, t))
                    {
                        q = 't';
                        array = t;
                        ShapeToAll(array);
                    }
                    break;

            }
            if (array.Length != 16)
            {
                shapeall = array;
            }
            

        }
        public Boolean start() {  //下落
            int index = 0;
            bool flag = true;
            int length = shapeall.Length;
            if (length == 4) {
                length--;
            }
            for (int i = 0 + x; i < x + shapeall.Length/shapeall.GetLength(1); i++)
            {
                for (int j = 0 + y; j < y + shapeall.GetLength(1); j++)
                {
                    if ( i == 14 )
                    {
                        flag = false;
                        break;
                    }
                    if ((all[i, j] == 1 && all[i + 1 , j] == 3) ||
                        x + shapeall.Length / shapeall.GetLength(1) == height)
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            if (flag){
                for (int i = x + shapeall.Length / shapeall.GetLength(1) - 1; i >= x; i--)
                {
                    index++;
                    for (int j = 0 + y; j < y + shapeall.GetLength(1); j++)
                    {
                        if (all[i, j] == 1 && i != 14 && all[i + 1, j] == 0)
                        {
                            all[i + 1, j] = all[i, j];
                            all[i, j] = 0;

                        }
                    }
                }
                x++;
            }
            else {
                for (int i = x + shapeall.Length / shapeall.GetLength(1) - 1; i >= x; i--)
                {
                    for (int j = 0 + y; j < y + shapeall.GetLength(1); j++)
                    {
                        if (all[i, j] == 1)
                        {
                            all[i, j] = 3;
                        }
                    }
                }
                x = 0;
                y = 4;
                if (IsOver())
                {
                    core = 0;
                    return false;
                }
                
                this.CreateShape();
            }
            return true;
        }
        public void CreateShape() {
            AddCore();
            int z;
            int[,] array = new int[4, 4];
            Random r = new Random();
            z = r.Next(0,7);
            switch (z){
                case 0:
                    q = 'a'; 
                    array = a;
                    break;
                case 1:
                    q = 'b';
                    array = b;
                    break;
                case 2:
                    q = 'c';
                    array = c;
                    break;
                case 3:
                    q = 'p';
                    array = p;
                    break;
                case 4:
                    q = 't';
                    array = t;
                    break;
                case 5:
                    q = 'h';
                    array = h;
                    break;
                case 6:
                    q = 'i';
                    array = i;
                    break;
            }

            for (int k = 0; k < array.Length/(array.GetLength(1)); k++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    all[k, j + 4] = array[k, j];
                }
            }
            x = 0;
            y = 4;
            shapeall = array;
        }
        public void Left() {
            if ( y == 0 )
            {
                return;
            }
            for (int i = x; i < x + shapeall.Length / shapeall.GetLength(1); i++)
            {
                for (int j = y; j < y + shapeall.GetLength(1); j++)
                {
                    if (all[i, j - 1] != 3 && all[i, j] == 1)
                    {
                        break;
                    }
                    if (all[i, j - 1] == 3 && all[i, j] == 1){
                        return;
                    }
                }
            }
            for (int i = x; i < x + shapeall.Length / shapeall.GetLength(1); i++)
            {
                for (int j = y; j < y + shapeall.GetLength(1); j++)
                {
                    if (all[i, j] == 1 && all[i, j - 1] == 0)
                    {
                        all[i, j - 1] = all[i, j];
                        all[i, j] = 0;
                    }
                }
            }
            y--;
        }
        public void Right()
        {
            if (y + shapeall.GetLength(1) == width)
            {
                return;
            }
            for (int i = x; i < x + shapeall.Length / shapeall.GetLength(1); i++)
            {
                for (int j = y + shapeall.GetLength(1) - 1; j >= y; j--)
                {
                    if (all[i, j] == 1 && all[i, j + 1] != 3)
                    {
                        break;
                    }
                    if (all[i, j + 1] == 3 && all[i, j] == 1)
                    {
                        return;
                    }
                }
            }
            for (int i = 0 + x; i < x + shapeall.Length / shapeall.GetLength(1); i++)
            {
                for (int j = y + shapeall.GetLength(1) - 1; j >= y ; j--)
                {
                    if (all[i, j] == 1 && all[i, j + 1] == 0)
                    {
                        all[i, j + 1] = all[i, j];
                        all[i, j] = 0;
                    }
                }
            }
            y++;

        }
        public Boolean ClearZero(int x,int y,int w,int h,int[,] array) {
            if (x + array.Length / array.GetLength(1) > height)
            {
                return false;
            }
            for (int i = x; i < x + array.Length / array.GetLength(1); i++)
            { 
                for (int j = y; j < y + array.GetLength(1); j++)
                {
                    if (j >= width)
                    {
                        return false;
                    }
                    if (all[i, j] == 3 && array[i - x, j - y] == 1)
                    {
                        return false;
                    }
                }
            }
            for (int i = x; i < x + h; i++)
            {
                for (int j = y; j < y + w; j++)
                {
                    if (all[i, j] != 3)
                    {
                        all[i, j] = 0;
                    }
                }
            }
            return true;
        }
        public void ShapeToAll(int[,] array) {
            while (array.GetLength(1) + y > width)
            {
                y--;
            }
            for (int k = 0 + x; k < array.Length / (array.GetLength(1)) + x; k++)
            {
                for (int j = 0 + y; j < array.GetLength(1) + y; j++)
                {
                    if (all[k, j] != 3)
                    {
                        all[k, j] = array[k - x, j - y];
                    }
                }
            }
        }
        public void AddCore() {
            int i = height - 1, j;
            int[] l = new int[15] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
            while (i >= 0)
            {
                for (j = 0; j < width; j++)
                {
                    if (all[i, j] != 3){
                        l[i] = 1;
                        break;
                    }
                }
                i--;
            }
            i = 0;
            while ( i < height ) {
                if (l[i] == 0)
                {
                    for (int k = i; k > 0; k--)
                    {
                        for (int p = 0; p < width; p++)
                        {
                            if (all[k-1,p]!=1)
                            {
                                all[k, p] = all[k-1, p];
                            }
                        }
                    }
                    this.core++;
                }
                i++;
            }
        }
        public void ReStart() {
            core = 0;
            x = 0;
            y = 4;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    all[i, j] = 0;
                }  
            }
            this.CreateShape();
        }
    }
}
