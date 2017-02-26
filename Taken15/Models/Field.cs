using System;
using System.Collections.Generic;
using System.Linq;

namespace Taken15.Models
{
    class Field
    {
        private List<GameBlock> gameField;
        private readonly GameBlock[] locationGameBlocks;

        public Field(int size, int[] blocksInts)
        {
            Size = size;
            gameField = new List<GameBlock>();
            CreateBlocks(blocksInts);
            locationGameBlocks = gameField.OrderBy(x => x.Value).ToArray();
        }

        private void CreateBlocks(int[] blocksInts)
        {
            int rowCount = 0;
            int colCount = 0;
            foreach (var blockInts in blocksInts)
            {
                gameField.Add(new GameBlock(blockInts, colCount, rowCount));
                colCount++;
                if (colCount < Size) continue;
                colCount = 0;
                rowCount++;
            }
        }

        public int Size { get; set; }

        public GameBlock GetLocation(int value)
        {
            return locationGameBlocks[value];
        }

        public void Shift(int value)
        {
            var movingGameBlock = GetLocation(value);
            int prevY = movingGameBlock.PositionY;
            int prevX = movingGameBlock.PositionX;
            var zero = GetLocation(0);
            movingGameBlock.PositionY = zero.PositionY;
            movingGameBlock.PositionX = zero.PositionX;
            zero.PositionY = prevY;
            zero.PositionX = prevX;
            
        }

        public GameBlock[] GameBlocksWithoutZero => locationGameBlocks.Skip(1).ToArray();

        public GameBlock[] GameBlocks => locationGameBlocks;

        public GameBlock this[int x, int y] => new GameBlock(1, x, y);
    }
}
