using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Game3 : Game2 // History
    {
        private List<int> motions;
        private int lastMotionIndex;
        public Game3(params int[] blocks) : base(blocks)
        {
            motions = new List<int>();
            lastMotionIndex = -1;
        }

        public new bool GameBlockClick(int value)
        {
            if (!base.GameBlockClick(value)) return false;
            lastMotionIndex++;
            motions.Insert(lastMotionIndex, value);
            motions = motions.Take(lastMotionIndex + 1).ToList();
            return true;
        }

        public void Back()
        {
            if (lastMotionIndex != -1)
            {
                Shift(motions.ElementAt(lastMotionIndex));
                lastMotionIndex--;
            }
        }

        public void Forward()
        {
            if (motions.Count() - 1 != lastMotionIndex && lastMotionIndex != -1)
            {
                Shift(motions[++lastMotionIndex]);
            }
        }

        public IEnumerable<int> Motions
        {
            get { return new List<int>(motions); }
        }
    }
}
