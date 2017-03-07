using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Game3 : Game2 // History
    {
        private readonly List<int> motions;
        public Game3(int blocksCount) : base(blocksCount)
        {
            motions = new List<int>();
        }

        public new bool GameBlockClick(int value)
        {
            if (!base.GameBlockClick(value)) return false;
            motions.Add(value);
            return true;
        }

        public IEnumerable<int> Motions => new List<int>(motions);
    }
}
