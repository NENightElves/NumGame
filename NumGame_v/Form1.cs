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
        bool f;
        int step_tmp, step_measure;

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
            b_p.Enabled = false;
            b_m.Enabled = false;
            b_t.Enabled = false;
            b_d.Enabled = false;
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

        private void step_button()
        {
            b_p.Enabled = true;
            b_m.Enabled = true;
            b_t.Enabled = true;
            b_d.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void step_measure_button()
        {
            b_p.Enabled = false;
            b_m.Enabled = false;
            b_t.Enabled = false;
            b_d.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void cal(int ri, int rj, int rk)
        {
            if (rk == 1) c[ri] = numgamecomputing_v.plus(c[ri], p[rj]);
            if (rk == 2) c[ri] = numgamecomputing_v.minus(c[ri], p[rj]);
            if (rk == 3) c[ri] = numgamecomputing_v.time(c[ri], p[rj]);
            if (rk == 4) c[ri] = numgamecomputing_v.div(c[ri], p[rj]);
            make_text();

            check_win();
        }

        private void plus_p(int i, int j, int k)
        {
            if (((p[i] == 0) || (c[j] == 0)) && ((k == 3) || (k == 4))) { MessageBox.Show("乘除不允许带0运算！"); f = false; return; }
            f = true;
            if (k == 1) p[i] = numgamecomputing_v.plus(p[i], c[j]);
            if (k == 2) p[i] = numgamecomputing_v.minus(p[i], c[j]);
            if (k == 3) p[i] = numgamecomputing_v.time(p[i], c[j]);
            if (k == 4) p[i] = numgamecomputing_v.div(p[i], c[j]);

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

            numgamecomputing_v num = new numgamecomputing_v(target);
            num.choosecompleted += cal;
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
            step_button();
            step_tmp = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false; button4.Enabled = false;
            step_button();
            step_tmp = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plus_p(step_tmp, 1, step_measure);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            if (check_win()) return;

            if (f == true)
            {
                numgamecomputing_v num = new numgamecomputing_v(target);
                num.choosecompleted += cal;
                num.generate(c, p, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plus_p(step_tmp, 2, step_measure);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            if (check_win()) return;

            if (f == true)
            {
                numgamecomputing_v num = new numgamecomputing_v(target);
                num.choosecompleted += cal;
                num.generate(c, p, 0);
            }
        }

        private void b_p_Click(object sender, EventArgs e)
        {
            step_measure = 1;
            step_measure_button();
        }

        private void b_m_Click(object sender, EventArgs e)
        {
            step_measure = 2;
            step_measure_button();
        }

        private void b_t_Click(object sender, EventArgs e)
        {
            step_measure = 3;
            step_measure_button();
        }

        private void b_d_Click(object sender, EventArgs e)
        {
            step_measure = 4;
            step_measure_button();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //numgamecomputing_v num = new numgamecomputing_v(9);
            //num.choosecompleted += cal;
            //c[1] = 5; c[2] = 9; p[1] = 9; p[2] = 0;
            //num.generate(c, p, 0);
        }
    }
}
