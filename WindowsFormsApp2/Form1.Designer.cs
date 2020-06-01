namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.服务端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束服务端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束接收端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(250, 375);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.DatagirdView1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "ReStart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(113, 21);
            this.textBox1.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(424, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(150, 225);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.Paint += new System.Windows.Forms.PaintEventHandler(this.DatagirdView2_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务端ToolStripMenuItem,
            this.客户端ToolStripMenuItem,
            this.结束服务端ToolStripMenuItem,
            this.结束接收端ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 服务端ToolStripMenuItem
            // 
            this.服务端ToolStripMenuItem.Name = "服务端ToolStripMenuItem";
            this.服务端ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.服务端ToolStripMenuItem.Text = "服务端";
            this.服务端ToolStripMenuItem.Click += new System.EventHandler(this.服务端ToolStripMenuItem_Click);
            // 
            // 客户端ToolStripMenuItem
            // 
            this.客户端ToolStripMenuItem.Name = "客户端ToolStripMenuItem";
            this.客户端ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.客户端ToolStripMenuItem.Text = "客户端";
            this.客户端ToolStripMenuItem.Click += new System.EventHandler(this.客户端ToolStripMenuItem_Click);
            // 
            // 结束服务端ToolStripMenuItem
            // 
            this.结束服务端ToolStripMenuItem.Name = "结束服务端ToolStripMenuItem";
            this.结束服务端ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.结束服务端ToolStripMenuItem.Text = "结束服务端";
            this.结束服务端ToolStripMenuItem.Click += new System.EventHandler(this.结束服务端ToolStripMenuItem_Click);
            // 
            // 结束接收端ToolStripMenuItem
            // 
            this.结束接收端ToolStripMenuItem.Name = "结束接收端ToolStripMenuItem";
            this.结束接收端ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.结束接收端ToolStripMenuItem.Text = "结束接收端";
            this.结束接收端ToolStripMenuItem.Click += new System.EventHandler(this.结束接收端ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 413);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束服务端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束接收端ToolStripMenuItem;
    }
}

