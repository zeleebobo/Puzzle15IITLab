using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Game2 : Game // Random / vitory
    {
        public Game2(params int[] blocks): base(blocks)
        {
            field.Mix();
        }
    }
}
