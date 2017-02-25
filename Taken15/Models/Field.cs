using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Field
    {
        private Block[,] field;

        public Field(int size, int [] blocks)
        {
            Size = size;
        }

        public int Size { get; set; }

        public int GetLocation(int value) { return 1; }

        public void Shift(int value)
        {
            
        }

        //public Block this[int x, int y] => field[x, y];
    }
}
