//核心代码版本v0.2.001Alpha
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace num_game_core
{
    public class numgamecomputing
    {

        private int m, n;
        private int[,] sp = new int[3, 3];
        private int endx;
        private int ri, rj;
        private int target;
        public delegate void choosecompleted_event(int a, int b);
        public event choosecompleted_event choosecompleted;

        public numgamecomputing(int a)
        //a为目标数字
        {
            int i, j;
            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    sp[i, j] = 0;
            m = 0; n = 0;
            endx = 1;
            //endx最好是奇数，并且大于0。在目前的generate下，过大可能导致抉择错误。
            target = a;
        }


        #region 事件性质的函数
        public void generate(int[] c, int[] p, int x)
        //x请用0带入！
        //c为电脑当前数字
        //p为玩家当前数字
        {
            int i, j, tmp;
            int[] tc = new int[3];
            int[] tp = new int[3];
            if (x > endx) return;

            //初始校正
            if (x == 0)
            {
                if (((c[1] + p[1]) % 10) == target) sp[1, 1] += 8;
                if (((c[1] + p[2]) % 10) == target) sp[1, 2] += 8;
                if (((c[2] + p[1]) % 10) == target) sp[2, 1] += 8;
                if (((c[2] + p[2]) % 10) == target) sp[2, 2] += 8;

                if ((((c[1] + p[1]) % 10) == target) && (p[2] == target)) { sp[1, 1] = 1000; sp[1, 2] = 1000; }
                if ((((c[1] + p[2]) % 10) == target) && (p[1] == target)) { sp[1, 1] = 1000; sp[1, 2] = 1000; }
                if ((((c[2] + p[1]) % 10) == target) && (p[2] == target)) { sp[2, 1] = 1000; sp[2, 2] = 1000; }
                if ((((c[2] + p[2]) % 10) == target) && (p[1] == target)) { sp[2, 1] = 1000; sp[2, 2] = 1000; }
            }

            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                {

                    tc[1] = c[1]; tc[2] = c[2];
                    tp[1] = p[1]; tp[2] = p[2];

                    if (x == 0) { m = i; n = j; }

                    if ((x % 2) == 0)
                    {
                        //电脑的局
                        tmp = (c[i] + p[j]) % 10;
                        tc[i] = tmp;
                        if (tc[i] == target) sp[m, n] += 3;
                        else if (tc[i] != tc[3 - i]) sp[m, n]++;
                        //电脑双target自动校正
                        if ((x == 0) && (tc[1] == target) && (tc[2] == target))
                        { sp[m, n] = int.MaxValue; choose(c, p); return; }
                        //电脑双target自动校正
                        generate(tc, tp, x + 1);
                    }
                    else
                    {
                        //玩家的局
                        tmp = (p[i] + c[j]) % 10;
                        tp[i] = tmp;
                        if (tp[i] == target) sp[m, n] -= 3;
                        else if (tp[i] != tp[3 - i]) sp[m, n]--;
                        //玩家双target自动校正
                        if ((x == 1) && (tp[1] == target) && (tp[2] == target) && (sp[m, n] != int.MaxValue))
                        { sp[m, n] = int.MinValue; return; }
                        //玩家双target自动校正                        
                        generate(tc, tp, x + 1);
                    }
                }

            if (x == 0)
            {
                //除9特例，防止拆9
                for (i = 1; i <= 2; i++)
                    for (j = 1; j <= 2; j++)
                        if ((c[i] == target) && (sp[i, j] != int.MinValue)) sp[i, j] -= 8;
                choose(c, p);
            }
        }




        private void choose(int[] c, int[] p)
        {
            int i, j, max;
            Random ran;
            ran = new Random();
            max = int.MinValue;

            //TEST:优先级测试
            Console.Write($"c[1]={c[1]}     c[2]={c[2]}     ");
            Console.WriteLine($"p[1]={p[1]}     p[2]={p[2]}     ");
            Console.Write($"sp[1,1]={sp[1, 1]}     sp[1,2]={sp[1, 2]}     ");
            Console.WriteLine($"sp[2,1]={sp[2, 1]}     sp[2,2]={sp[2, 2]}     \r\n");
            //

            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                {
                    if (max < sp[i, j]) { max = sp[i, j]; ri = i; rj = j; }
                    else if (max == sp[i, j])
                    {
                        if ((ran.Next(0, 2) == 0) || (sp[i, j] == int.MinValue))
                        { max = sp[i, j]; ri = i; rj = j; }
                    }
                }
            choosecompleted(ri, rj);
            //该事件为传回数据指用电脑的第ri个数加玩家的第rj个数之和，累加到电脑的第ri个数
        }


        #endregion



    }

    public class numgamecomputing_v
    {

        private int m, n, x;
        private int[,,] sp = new int[3, 3, 5];
        private int endx;
        private int ri, rj, rk;
        private int target;
        public delegate void choosecompleted_event(int a, int b, int c);
        public event choosecompleted_event choosecompleted;

        public numgamecomputing_v(int a)
        //a为目标数字
        {
            int i, j, k;
            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    for (k = 1; k <= 4; k++)
                        sp[i, j, k] = 0;
            m = 0; n = 0;
            endx = 1;
            //endx最好是奇数，并且大于0。在目前的generate下，过大可能导致抉择错误。
            target = a;
        }

        #region 基础加减乘除法

        public int plus(int a, int b)
        {
            int tmp;
            tmp = (a + b) % 10;
            return tmp;
        }

        public int minus(int a, int b)
        {
            int tmp;
            tmp = Math.Abs((a - b)) % 10;
            return tmp;
        }

        public int time(int a, int b)
        {
            int tmp;
            tmp = (a * b) % 10;
            return tmp;
        }

        public int div(int a, int b)
        {
            int tmp;
            tmp = Convert.ToInt32(Math.Floor(Convert.ToDecimal(a / b))) % 10;
            return tmp;
        }

        #endregion



        #region 事件性质的函数
        public void generate(int[] c, int[] p, int x)
        //x请用0带入！
        //c为电脑当前数字
        //p为玩家当前数字
        {
            int i, j, k, tmp;
            int[] tc = new int[3];
            int[] tp = new int[3];
            if (x > endx) return;

            //初始校正
            if (x == 0)
            {
                for (i = 1; i <= 2; i++)
                    for (j = 1; j <= 2; j++)
                    {
                        if (plus(c[i], p[j]) == target) sp[i, j, 1] += 8;
                        if (minus(c[i], p[j]) == target) sp[i, j, 2] += 8;
                        if (time(c[i], p[j]) == target) sp[i, j, 3] += 8;
                        if (div(c[i], p[j]) == target) sp[i, j, 4] += 8;

                        if ((plus(c[i], p[j]) == target) && (p[3 - j] == target)) { sp[i, 1, 1] = 1000; sp[i, 2, 1] = 1000; }
                        if ((minus(c[i], p[j]) == target) && (p[3 - j] == target)) { sp[i, 1, 2] = 1000; sp[i, 2, 2] = 1000; }
                        if ((time(c[i], p[j]) == target) && (p[3 - j] == target)) { sp[i, 1, 3] = 1000; sp[i, 2, 3] = 1000; }
                        if ((plus(c[i], p[j]) == target) && (p[3 - j] == target)) { sp[i, 1, 4] = 1000; sp[i, 2, 4] = 1000; }
                    }
            }

            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    for (k = 1; k <= 4; k++)
                    {

                        tc[1] = c[1]; tc[2] = c[2];
                        tp[1] = p[1]; tp[2] = p[2];

                        if (x == 0) { m = i; n = j; }

                        if ((x % 2) == 0)
                        {
                            //电脑的局
                            tmp = 0;
                            if (k == 1) tmp = plus(c[i], p[j]);
                            if (k == 2) tmp = minus(c[i], p[j]);
                            if (k == 3) tmp = time(c[i], p[j]);
                            if (k == 4) tmp = div(c[i], p[j]);

                            tc[i] = tmp;
                            if (tc[i] == target) sp[m, n, x] += 3;
                            else if (tc[i] != tc[3 - i]) sp[m, n, x]++;
                            //电脑双target自动校正
                            if ((x == 0) && (tc[1] == target) && (tc[2] == target))
                            { sp[m, n, x] = int.MaxValue; choose(c, p); return; }
                            //电脑双target自动校正
                            generate(tc, tp, x + 1);
                        }
                        else
                        {
                            //玩家的局
                            tmp = 0;
                            if (k == 1) tmp = plus(p[i], c[j]);
                            if (k == 2) tmp = minus(p[i], c[j]);
                            if (k == 3) tmp = time(p[i], c[j]);
                            if (k == 4) tmp = div(p[i], c[j]);

                            tp[i] = tmp;
                            if (tp[i] == target) sp[m, n, x] -= 3;
                            else if (tp[i] != tp[3 - i]) sp[m, n, x]--;
                            //玩家双target自动校正
                            if ((x == 1) && (tp[1] == target) && (tp[2] == target) && (sp[m, n, x] != int.MaxValue))
                            { sp[m, n, x] = int.MinValue; return; }
                            //玩家双target自动校正                        
                            generate(tc, tp, x + 1);
                        }
                    }

            if (x == 0)
            {
                //除9特例，防止拆9
                for (i = 1; i <= 2; i++)
                    for (j = 1; j <= 2; j++)
                        for (k = 1; k <= 4; k++)
                            if ((c[i] == target) && (sp[i, j, k] != int.MinValue)) sp[i, j, k] -= 8;
                choose(c, p);
            }
        }




        private void choose(int[] c, int[] p)
        {
            int i, j, k, max;
            Random ran;
            ran = new Random();
            max = int.MinValue;

            //TEST:优先级测试
            //Console.Write($"c[1]={c[1]}     c[2]={c[2]}     ");
            //Console.WriteLine($"p[1]={p[1]}     p[2]={p[2]}     ");
            //Console.Write($"sp[1,1]={sp[1, 1]}     sp[1,2]={sp[1, 2]}     ");
            //Console.WriteLine($"sp[2,1]={sp[2, 1]}     sp[2,2]={sp[2, 2]}     \r\n");
            //

            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    for (k = 1; k <= 4; k++)
                    {
                        if (max < sp[i, j, k]) { max = sp[i, j, k]; ri = i; rj = j; rk = k; }
                        else if (max == sp[i, j, k])
                        {
                            if ((ran.Next(0, 2) == 0) || (sp[i, j, k] == int.MinValue))
                            { max = sp[i, j, k]; ri = i; rj = j; rk = k; }
                        }
                    }
            choosecompleted(ri, rj, rk);
            //该事件为传回数据指用电脑的第ri个数加玩家的第rj个数之和，累加到电脑的第ri个数
        }


        #endregion



    }


}
