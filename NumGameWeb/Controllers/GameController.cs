using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NumGameWeb.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "不给我参数，你想干吗？";
        }

        [HttpGet("Play")]
        public IEnumerable<int> Play(int c1, int c2, int p1, int p2, int target)
        {
            numgamecomputing num = new numgamecomputing(target);
            int[] c = new int[] { 0, c1, c2 };
            int[] p = new int[] { 0, p1, p2 };
            num.choosecompleted += Num_choosecompleted;
            int[] re = new int[2];
            num.generate(c, p, 0, out re[0], out re[1]);
            return re;
        }

        private void Num_choosecompleted(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
