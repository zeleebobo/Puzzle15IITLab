using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken15.Models
{
    class Game2 : Game // Random / vitory
    {
        public Game2(int blocksCount) 
        {
            if (BlocksCountIsValid(blocksCount))
                throw new ArgumentException();

            Size = (int)Math.Sqrt(blocksCount);
            var victoryBlocksArray = CreateVictoryFieldSequenceArray(Enumerable.Range(0, Size * Size).ToArray());
            victoryField = new Field(Size, victoryBlocksArray);
            field = new Field(Size, victoryBlocksArray);
            field.Mix();
            IsOver = false;
        }
    }
}
