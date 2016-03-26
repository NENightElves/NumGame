namespace NumGame
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_p = new System.Windows.Forms.Button();
            this.b_m = new System.Windows.Forms.Button();
            this.b_t = new System.Windows.Forms.Button();
            this.b_d = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(28, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(177, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(28, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(177, 147);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 208);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(292, 55);
            this.button5.TabIndex = 4;
            this.button5.Text = "开始，电脑先";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(28, 271);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(292, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "开始，玩家先";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "目标数字";
            // 
            // b_p
            // 
            this.b_p.Enabled = false;
            this.b_p.Location = new System.Drawing.Point(339, 86);
            this.b_p.Name = "b_p";
            this.b_p.Size = new System.Drawing.Size(143, 55);
            this.b_p.TabIndex = 8;
            this.b_p.Text = "+";
            this.b_p.UseVisualStyleBackColor = true;
            this.b_p.Click += new System.EventHandler(this.b_p_Click);
            // 
            // b_m
            // 
            this.b_m.Enabled = false;
            this.b_m.Location = new System.Drawing.Point(339, 147);
            this.b_m.Name = "b_m";
            this.b_m.Size = new System.Drawing.Size(143, 55);
            this.b_m.TabIndex = 9;
            this.b_m.Text = "-";
            this.b_m.UseVisualStyleBackColor = true;
            this.b_m.Click += new System.EventHandler(this.b_m_Click);
            // 
            // b_t
            // 
            this.b_t.Enabled = false;
            this.b_t.Location = new System.Drawing.Point(339, 208);
            this.b_t.Name = "b_t";
            this.b_t.Size = new System.Drawing.Size(143, 55);
            this.b_t.TabIndex = 10;
            this.b_t.Text = "*";
            this.b_t.UseVisualStyleBackColor = true;
            this.b_t.Click += new System.EventHandler(this.b_t_Click);
            // 
            // b_d
            // 
            this.b_d.Enabled = false;
            this.b_d.Location = new System.Drawing.Point(339, 271);
            this.b_d.Name = "b_d";
            this.b_d.Size = new System.Drawing.Size(143, 55);
            this.b_d.TabIndex = 11;
            this.b_d.Text = "/";
            this.b_d.UseVisualStyleBackColor = true;
            this.b_d.Click += new System.EventHandler(this.b_d_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 355);
            this.Controls.Add(this.b_d);
            this.Controls.Add(this.b_t);
            this.Controls.Add(this.b_m);
            this.Controls.Add(this.b_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_p;
        private System.Windows.Forms.Button b_m;
        private System.Windows.Forms.Button b_t;
        private System.Windows.Forms.Button b_d;
    }
}

