using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumGameWeb
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


        public void generate(int[] c, int[] p, int x, out int ri, out int rj)
        //x请用0带入！
        //c为电脑当前数字
        //p为玩家当前数字
        {
            int i, j, tmp;
            int[] tc = new int[3];
            int[] tp = new int[3];
            ri = 0;
            rj = 0;
            if (x > endx) return;

            //初始校正
            if (x == 0)
            {
                if (((c[1] + p[1]) % 10) == target) sp[1, 1] += 8;
                else if (((c[1] + p[2]) % 10) == target) sp[1, 2] += 8;
                else if (((c[2] + p[1]) % 10) == target) sp[2, 1] += 8;
                else if (((c[2] + p[2]) % 10) == target) sp[2, 2] += 8;
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
                        {
                            sp[m, n] = int.MaxValue;
                            //CHOOSE
                            int max;
                            Random ran;
                            ran = new Random();
                            max = int.MinValue;

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
                            //END CHOOSE
                            return;
                        }
                        //电脑双target自动校正
                        generate(tc, tp, x + 1, out ri, out rj);
                    }
                    else
                    {
                        //玩家的局
                        tmp = (p[i] + c[j]) % 10;
                        tp[i] = tmp;
                        if (tp[i] == target) sp[m, n] -= 3;
                        //else if (tp[i] != tp[3 - i]) sp[m, n]--;
                        //玩家双target自动校正
                        if ((x == 1) && (tp[1] == target) && (tp[2] == target) && (sp[m, n] != int.MaxValue))
                        { sp[m, n] = int.MinValue; return; }
                        //玩家双target自动校正                        
                        generate(tc, tp, x + 1, out ri, out rj);
                    }
                }

            if (x == 0)
            {
                //除9特例，防止拆9
                for (i = 1; i <= 2; i++)
                    for (j = 1; j <= 2; j++)
                        if ((c[i] == target) && (sp[i, j] != int.MinValue)) sp[i, j] -= 8;

                int max;
                Random ran;
                ran = new Random();
                max = int.MinValue;

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
            }
        }

    }
}
