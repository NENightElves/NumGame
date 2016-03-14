using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace num_game_core
{
    class numgamecomputing
    {

        private int m, n;
        private int[,] sp = new int[3, 3];
        private int endx;
        private int ri, rj;
        private int target;
        Random ran;
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
            endx = 10;
            target = a;
        }


        public void generate(int[] c, int[] p, int x)
        //x请用0带入！
        //c为电脑当前数字
        //p为玩家当前数字
        {
            int i, j, tmp;
            int[] tc = new int[3];
            int[] tp = new int[3];
            if (x > endx) return;

            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                {
                    tc = c;
                    tp = p;
                    if (x == 0) { m = i; n = j; }
                    tmp = (c[i] + p[j]) % 10;
                    if ((x % 2) == 0)
                    {
                        //电脑的局
                        tc[i] = tmp;
                        if (c[i] == target) sp[m, n] += 3;
                        else if (c[i] != c[3 - i]) sp[m, n]++;
                        generate(tc, tp, x + 1);
                    }
                    else
                    {
                        //玩家的局
                        tp[i] = tmp;
                        if (c[i] == target) sp[m, n] -= 3;
                        else if (c[i] != c[3 - i]) sp[m, n]--;
                        generate(tc, tp, x + 1);
                    }
                }
            if (x == 0) choose();
        }


        private void choose()
        {
            int i, j, max;
            max = int.MinValue;
            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    if (max < sp[i, j]) { max = sp[i, j]; ri = i; rj = j; }
                    else if (max == sp[i, j]) { if (ran.Next(0, 1) == 0) { max = sp[i, j]; ri = i; rj = j; } }
            choosecompleted(ri, rj);
            //该事件为传回数据指用电脑的第ri个数加玩家的第rj个数之和，累加到电脑的第ri个数
        }

    }
}
