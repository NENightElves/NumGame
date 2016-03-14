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
        private int x, endx;
        private int ri, ji;
        public delegate void choosecompleted_event(int a, int b);
        public event choosecompleted_event choosecompleted;

        public numgamecomputing()
        {
            int i, j;
            for (i = 1; i <= 2; i++)
                for (j = 1; j <= 2; j++)
                    sp[i, j] = 0;
            m = 0; n = 0;
            x = 0; endx = 10;
        }

        public void generate(int[] c,int []p)
        {
            int i, j, tmp;
            int[] tc = new int[3];
            int[] tp = new int[3];
            if (x > endx) return;
            
            for (i=1;i<=2;i++)
                for (j=1;j<=2;j++)
                {
                    tc = c;
                    tp = p;
                    if (x==0) { m = i; n = j; }

                }
        }

    }
}
