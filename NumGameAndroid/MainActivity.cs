using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using num_game_core;

namespace NumGameAndroid
{
    [Activity(Label = "NumGameAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        int target;
        int[] c = new int[3];
        int[] p = new int[3];
        int step_tmp;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;

            reset();

        }

        #region 必要函数
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
            TextView editText1 = FindViewById<TextView>(Resource.Id.editText1);

            if ((c[1] == 9) && (c[2] == 9)) { editText1.Text = "电脑胜利！"; reset(); return true; }
            if ((p[1] == 9) && (p[2] == 9)) { editText1.Text = "玩家胜利！"; reset(); return true; }
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
        #endregion


        #region button事件
        private void button5_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            TextView editText1 = FindViewById<TextView>(Resource.Id.editText1);

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
            target = Convert.ToInt32(editText1.Text);

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
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
            TextView editText1 = FindViewById<TextView>(Resource.Id.editText1);

            c[1] = 1; c[2] = 1; p[1] = 1; p[2] = 1;
            make_text();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = false;
            button5.Text = "重置";
            check_target();
            target = Convert.ToInt32(editText1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);

            button3.Enabled = false; button4.Enabled = false;
            button1.Enabled = true; button2.Enabled = true;
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

            button3.Enabled = false; button4.Enabled = false;
            button1.Enabled = true; button2.Enabled = true;
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
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);

            plus_p(step_tmp, 2);

            button3.Enabled = true; button4.Enabled = true;
            button1.Enabled = false; button2.Enabled = false;

            if (check_win()) return;

            numgamecomputing num = new numgamecomputing(target);
            num.choosecompleted += plus;
            num.generate(c, p, 0);
        }
        #endregion

    }
}

