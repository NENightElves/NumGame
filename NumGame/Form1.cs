//窗体代码版本v0.1.006Alpha
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using num_game_core;

namespace NumGame
{
    public partial class Form1 : Form
    {
        int target;
        int[] c = new int[3];
        int[] p = new int[3];
        int step_tmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void check_target()
        {

        }

        private void reset()
        {
            button1.Text = Convert.ToString(1);
            button2.Text = Convert.ToString(1);
            button3.Text = Convert.ToString(1);
            button4.Text = Convert.ToString(1);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Text = "开始，电脑先";
            button6.Text = "开始，玩家先";
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private bool check_win()
        {
            if ((c[1] == target) && (c[2] == target)) { MessageBox.Show("电脑胜利！"); reset(); return true; }
            if ((p[1] == target) && (p[2] == target)) { MessageBox.Show("玩家胜利！"); reset(); return true; }
            return false;
        }

        private void make_text()
        {
            button1.Text = Convert.ToString(c[1]);
            button2.Text = Convert.ToString(c[2]);
            button3.Text = Convert.ToString(p[1]);
            button4.Text = Convert.ToString(p[2]);
        }

        private void plus(int ri, int rj)
        {
            c[ri] = (c[ri] + p[rj]) % 10;
            make_text();

            check_win();
        }

        private void plus_p(int i, int j)
        {
            p[i] = (p[i] + c[j]) % 10;
            make_text();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (button6.Enabled == false) { reset(); return; }
            c[1] = 1; c[2] = 1; p[1] = 1; p[2] = 1;
            make_text();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = false;
            button5.Text = "重置";
            check_target();
            target = Convert.ToInt32(textBox1.Text);

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            c[1] = 1; c[2] = 1; p[1] = 1; p[2] = 1;
            make_text();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = false;
            button5.Text = "重置";
            check_target();
            target = Convert.ToInt32(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false; button4.Enabled = false;
            button1.Enabled = true; button2.Enabled = true;
            step_tmp = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false; button4.Enabled = false;
            button1.Enabled = true; button2.Enabled = true;
            step_tmp = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plus_p(step_tmp, 1);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            if (check_win()) return;

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plus_p(step_tmp, 2);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            if (check_win()) return;

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //numgamecomputing num = new numgamecomputing(9);
            //num.choosecompleted += plus;
            //c[1] = 2; c[2] = 7; p[1] = 5; p[2] = 9;
            //num.generate(c, p, 0);
        }
    }
}
