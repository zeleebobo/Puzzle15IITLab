using System;
using System.Collections.Generic;
using System.Linq;

namespace Taken15.Models
{
    class Field
    {
        private readonly GameBlock[] _locationGameBlocksArray;

        public Field(int size, int[] blocksInts)
        {
            Size = size;
            _locationGameBlocksArray = CreateBlocks(blocksInts);
        }

        public void Mix()
        {
            var rnd = new Random();
            var countGameBlocks = _locationGameBlocksArray.Length;
            for (int i = 0; i <  countGameBlocks * countGameBlocks; i++)
            {
                var relatedGameBlocksArray = GetRelatedGameBlocksArray(GetLocation(0));
                var shiftingGameBlock = relatedGameBlocksArray[rnd.Next(relatedGameBlocksArray.Length)];
                Shift(shiftingGameBlock.Value);
            }
        }

        private GameBlock[] GetRelatedGameBlocksArray(GameBlock gameBlock)
        {
            return _locationGameBlocksArray.Where(x => x.IsRelatedWith(gameBlock)).ToArray();
        }

        private GameBlock[] CreateBlocks(int[] blocksInts)
        {
            int rowCount = 0;
            int colCount = 0;

            var gameField = new List<GameBlock>();
            foreach (var blockInts in blocksInts)
            {
                gameField.Add(new GameBlock(blockInts, colCount, rowCount));
                colCount++;
                if (colCount < Size) continue;
                colCount = 0;
                rowCount++;
            }
            return gameField.OrderBy(x => x.Value).ToArray();
        }

        public int Size { get; set; }

        public GameBlock GetLocation(int value)
        {
            return _locationGameBlocksArray[value];
        }

        public void Shift(int value)
        {
            var movingGameBlock = GetLocation(value);
            var zero = GetLocation(0);

            if (!movingGameBlock.IsRelatedWith(zero) || value > _locationGameBlocksArray.Length - 1 || value < 0)
                throw new ArgumentException();

            var prevY = movingGameBlock.PositionY;
            var prevX = movingGameBlock.PositionX;
            movingGameBlock.PositionY = zero.PositionY;
            movingGameBlock.PositionX = zero.PositionX;
            zero.PositionY = prevY;
            zero.PositionX = prevX;
        }

        public GameBlock[] GameBlocksArrayWithoutZero => _locationGameBlocksArray.Skip(1).ToArray();

        public GameBlock[] GameBlocksArray => _locationGameBlocksArray;

        public int this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0 || x >= Size || y >= Size)
                    throw new IndexOutOfRangeException();
                return _locationGameBlocksArray.First(arg => arg.PositionX == x && arg.PositionY == y).Value; // Not const time but I don't use it 
            }
        }
    }
}
