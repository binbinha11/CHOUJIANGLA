using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int width;
        int height;
        int w;
        int h;
        int width2;
        int height2;
        int w2;
        int h2;
        public static bool start = false;
        public TextureBrush Txbrus;
        SocketAll socketAll = new SocketAll(Class1.all2, Class1.all);
        Class1 class1 = new Class1();
        List<Rectangle> l = new List<Rectangle>();
        Rectangle r;
        Pen bluePen = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                this.Width, this.Height, BoundsSpecified.Location);
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }
        private void Multiple()
        {
            width = dataGridView1.Width;
            height = dataGridView1.Height;
            w = dataGridView1.Width / 10;
            h = dataGridView1.Height / 15;

            width2 = dataGridView2.Width;
            height2 = dataGridView2.Height;
            w2 = dataGridView2.Width / 10;
            h2 = dataGridView2.Height / 15;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X={0},Y={1}", e.X, e.Y);
        }
        private void DrawGrid(int width, int height, int w, int h, PaintEventArgs e)
        {
            Point p1 = new Point();
            Point p2 = new Point();

            p1.X = 0; p2.X = width;
            for (int y = 0; y <= height; y = y + h)
            {
                p1.Y = y; p2.Y = y;
                DrawLine(p1, p2, e);
            }
            p1.Y = 0; p2.Y = height;
            for (int x = 0; x <= width; x = x + w)
            {
                p1.X = x; p2.X = x;
                DrawLine(p1, p2, e);
            }
        }
        private void DrawLine(Point p1, Point p2, PaintEventArgs e)
        {
           e.Graphics.DrawLine(bluePen, p1, p2);
        }
        private void DatagirdView1_Paint(object sender, PaintEventArgs e)
        {
            l = class1.ArrayToRectangle(Class1.all,25);
            this.Multiple();
            DrawGrid(width, height, w, h, e);
            foreach (Rectangle r1 in l)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), r1);
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cr = e.KeyChar;
            //cr你想要的。
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:      //   ↑键 转方向
                    class1.ChangedShape();
                    break;
                case Keys.Down:    //   ↓键
                    if (start){
                        class1.start();
                    }
                    else {
                        MessageBox.Show("NO START!");
                    }      
                    break;
                case Keys.Left:    //   ←键
                    class1.Left();
                    break;
                case Keys.Right:   //   →键
                    class1.Right();    
                    break;
            }
            this.dataGridView1.Refresh();
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.textBox1.Text = class1.core.ToString();
            Class1.all2 = SocketAll.array;
            if (class1.start()){
                start = true;
                this.dataGridView1.Refresh();
                this.dataGridView2.Refresh();
            }
            else {
                MessageBox.Show("OVER!");
                timer1.Stop();
                start = false;
            }
            
        }

        private void Button2_Click(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            start = false;
            class1.ReStart();
            this.dataGridView1.Refresh();
            SocketAll.CloseSocket();
        }

        private void DatagirdView2_Paint(object sender, PaintEventArgs e)
        {
            l = class1.ArrayToRectangle(Class1.all2, 15);
            this.Multiple();
            DrawGrid(width2, height2, w2, h2, e);
            foreach (Rectangle r1 in l)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), r1);
            }
        }

        private void 服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketAll.OpenSocket(true);
        }

        private void 客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketAll.OpenSocket(false);   
        }
    }
}
