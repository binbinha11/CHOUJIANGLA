using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        Class1 class1 = new Class1();
        List<Rectangle> l = new List<Rectangle>();
        Rectangle r;
        Pen bluePen = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
            //dataGridView1.RowCount = 10;
            //dataGridView1.ColumnCount = 2;
            //dataGridView1.Columns[0].HeaderCell.Value = "编号";
            //dataGridView1.Columns[1].HeaderCell.Value = "名称";
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            ////获取进程名称
            //string ProcessName = textBox1.Text;
            ////创建Process 类的对象
            //Process p = new Process();
            ////设置进程名称
            //p.StartInfo.FileName = ProcessName;
            ////启动进程
            //p.Start();
            //Image image = Image.FromFile("C:\\Users\\lizb2\\Desktop\\无标题.jpg");
            //this.BackgroundImage = image;
            //int x, y;
            //int x1, y1;
            ////button1.Top = 100;
            ////button1.Left = 100;
            //Point screenPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标
            //x1 = screenPoint.X;
            //y1 = screenPoint.Y;


            //Point button1Point = button1.PointToClient(Control.MousePosition); //鼠标相对于button1左上角的坐标
            //x = button1Point.X;
            //y = button1Point.Y;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

        }

        private void Multiple()
        {
            ;
            width = dataGridView1.Width;
            height = dataGridView1.Height;
            w = dataGridView1.Width / 10;
            h = dataGridView1.Height / 15;
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
            
            l = class1.ArrayToRectangle(Class1.all);
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
                    this.dataGridView1.Refresh();
                    break;
                case Keys.Down:    //   ↓键
                    break;
                case Keys.Left:    //   ←键
                    class1.Left();
                    this.dataGridView1.Refresh();
                    break;
                case Keys.Right:   //   →键
                    break;
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (class1.start()){
                this.dataGridView1.Refresh();
            }
            else {
                MessageBox.Show("OVER!");
                timer1.Stop();
            }
            
        }
    }
}
