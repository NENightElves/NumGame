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

        private void check_win()
        {
            if ((c[1] == 9) && (c[2] == 9)) MessageBox.Show("电脑胜利！");
            if ((c[1] == 9) && (c[2] == 9)) MessageBox.Show("玩家胜利！");
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

            c[1] = Convert.ToInt32(button1.Text);
            c[2] = Convert.ToInt32(button2.Text);
            p[1] = Convert.ToInt32(button3.Text);
            p[2] = Convert.ToInt32(button4.Text);

            c[ri] = (c[ri] + p[rj]) % 10;
            make_text();

            check_win();
        }

        private void plus_p(int i, int j)
        {
            c[1] = Convert.ToInt32(button1.Text);
            c[2] = Convert.ToInt32(button2.Text);
            p[1] = Convert.ToInt32(button3.Text);
            p[2] = Convert.ToInt32(button4.Text);

            p[i] = (p[i] + c[j]) % 10;
            make_text();

            check_win();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            c[1] = 1; c[2] = 1; p[1] = 1; p[2] = 1;
            make_text();
            button1.Enabled = false;
            button2.Enabled = false;
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

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plus_p(step_tmp, 2);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }
    }
}
