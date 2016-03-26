using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using num_game_core;

namespace NumGame_v_Android
{
    [Activity(Label = "NumGame_v_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int target;
        int[] c = new int[3];
        int[] p = new int[3];
        bool f;
        int step_tmp, step_measure;
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;
            b_p.Click += b_p_Click;
            b_m.Click += b_m_Click;
            b_t.Click += b_t_Click;
            b_d.Click += b_d_Click;

            reset();

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }




        #region 函数

        private void check_target()
        {

        }

        private void reset()
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);


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
            text.Text = "点击按钮开始";
            button5.Enabled = true;
            button6.Enabled = true;
            b_p.Enabled = false;
            b_m.Enabled = false;
            b_t.Enabled = false;
            b_d.Enabled = false;
        }

        private bool check_win()
        {
            TextView text = FindViewById<TextView>(Resource.Id.textView1);

            if ((c[1] == target) && (c[2] == target)) { text.Text = "电脑胜利！"; return true; }
            if ((p[1] == target) && (p[2] == target)) { text.Text = "电脑胜利！"; return true; }
            return false;
        }

        private void make_text()
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            button1.Text = Convert.ToString(c[1]);
            button2.Text = Convert.ToString(c[2]);
            button3.Text = Convert.ToString(p[1]);
            button4.Text = Convert.ToString(p[2]);
        }

        private void step_button()
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            b_p.Enabled = true;
            b_m.Enabled = true;
            b_t.Enabled = true;
            b_d.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void step_measure_button()
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            b_p.Enabled = false;
            b_m.Enabled = false;
            b_t.Enabled = false;
            b_d.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void cal(int ri, int rj, int rk)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            if (rk == 1) c[ri] = numgamecomputing_v.plus(c[ri], p[rj]);
            if (rk == 2) c[ri] = numgamecomputing_v.minus(c[ri], p[rj]);
            if (rk == 3) c[ri] = numgamecomputing_v.time(c[ri], p[rj]);
            if (rk == 4) c[ri] = numgamecomputing_v.div(c[ri], p[rj]);
            make_text();

            check_win();
        }

        private void plus_p(int i, int j, int k)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);


            if (((p[i] == 0) || (c[j] == 0)) && ((k == 3) || (k == 4))) { text.Text = "乘除不允许带0运算！"; f = false; return; }
            f = true;
            if (k == 1) p[i] = numgamecomputing_v.plus(p[i], c[j]);
            if (k == 2) p[i] = numgamecomputing_v.minus(p[i], c[j]);
            if (k == 3) p[i] = numgamecomputing_v.time(p[i], c[j]);
            if (k == 4) p[i] = numgamecomputing_v.div(p[i], c[j]);

            make_text();
        }


        #endregion



        #region 窗体

        private void button5_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


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
            target = Convert.ToInt32(textbox1.Text);

            numgamecomputing_v num = new numgamecomputing_v(target);
            num.choosecompleted += cal;
            num.generate(c, p, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            c[1] = 1; c[2] = 1; p[1] = 1; p[2] = 1;
            make_text();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = false;
            button5.Text = "重置";
            check_target();
            target = Convert.ToInt32(textbox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            button3.Enabled = false; button4.Enabled = false;
            step_button();
            step_tmp = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


            button3.Enabled = false; button4.Enabled = false;
            step_button();
            step_tmp = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


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
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button b_p = FindViewById<Button>(Resource.Id.b_p);
            Button b_m = FindViewById<Button>(Resource.Id.b_m);
            Button b_t = FindViewById<Button>(Resource.Id.b_t);
            Button b_d = FindViewById<Button>(Resource.Id.b_d);
            EditText textbox1 = FindViewById<EditText>(Resource.Id.editText1);


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


        #endregion
    }
}

