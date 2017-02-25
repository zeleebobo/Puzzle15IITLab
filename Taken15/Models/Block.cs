using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Block
    {
        public Block(int value)
        {
            Value = value;
        }

        public Block(int value, int x, int y)
        {
            Value = value;
            PositionX = x;
            PositionY = y;
        }

        public int Value { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }
    }
}
