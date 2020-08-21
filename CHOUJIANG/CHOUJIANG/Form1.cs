using CHOUJIANG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CHOUJIANG
{
    public partial class Form1 : Form
    {

        int i = 0, rd, cnt = 0, a = 0;
        PictureBox[] pic = new PictureBox[8];
        bool b = true;

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Enabled = true;
            Random r = new Random();
            rd = r.Next(40, 57);
            if (cnt >= 0)
            {
                if (b == true)
                {
                    b = false;
                    return;
                }
                pic[cnt].Location = new Point(pic[cnt].Location.X + 10, pic[cnt].Location.Y + 10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval += 5;
            if (a % 2 == 0)                           //定义一个变量，进行奇偶判断，从而实现PictureBox大小的动态变化
            {
                pic[cnt].Size = new Size(120, 120);     //改变PictureBox的大小
                pic[cnt].Location = new Point(pic[cnt].Location.X - 10, pic[cnt].Location.Y - 10);
                a++;
            }
            else if (a % 2 == 1)
            {
                pic[cnt].Size = new Size(100, 100);
                pic[cnt].Location = new Point(pic[cnt].Location.X + 10, pic[cnt].Location.Y + 10);
                cnt++;
                a++;
            }
            if (cnt > 7)
            {
                cnt = 0;
            }
            /*通过奇偶判断，实现选中控件的放大停留*/
            //判断生成的随机a的值是否比生成的随机数大，并将对应PictureBox变大，然后停止
            if (a > rd && a % 2 == 1)
            {
                a = 0;
                timer1.Enabled = false;

                //实例每个选中的pictureBox的事件，通过弹框提示用户抽到的内容
                switch (cnt)
                {
                    case 7: MessageBox.Show("恭喜您，中奖了！奖品是一个小CK！"); break;
                    case 6: MessageBox.Show("恭喜您，中奖了！奖品是一条手链！"); break;
                    case 5: MessageBox.Show("恭喜您，中奖了！奖品是一个红包！"); break;
                    case 4: MessageBox.Show("恭喜您，中奖了！奖品是一个小CK！"); break;
                    case 3: MessageBox.Show("恭喜您，中奖了！奖品是一个红包！"); break;
                    case 2: MessageBox.Show("恭喜您，中奖了！奖品是一个口红！"); break;
                    case 1: MessageBox.Show("恭喜您，中奖了！奖品是一个红包！"); break;
                    case 0: MessageBox.Show("恭喜您，中奖了！奖品是清空购物车！"); break;
                    default: break;
                }
                button1.Enabled = true;
                timer1.Interval = 10;
            }

        }

        private void button1_click(object sender, EventArgs e)
        {
            
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (Control picB in this.Controls)         //遍历窗体中所有PictureBox，并将窗体的PictureBox加入数组中
            {
                if (picB.GetType() == typeof(PictureBox))
                {
                    pic[i] = (PictureBox)picB;
                    i++;
                }
            }
        }
    }
}
