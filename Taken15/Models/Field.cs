using System;
using System.Collections.Generic;
using System.Linq;

namespace Taken15.Models
{
    class Field
    {
        private readonly GameBlock[] locationGameBlocksArray;
        private readonly GameBlock[,] locationGameBlocksMatrix;

        public Field(int size, int[] blocksInts)
        {
            Size = size;
            locationGameBlocksArray = CreateBlocksArray(blocksInts);
            locationGameBlocksMatrix = CreateBlocksMatrix();
        }

        public void Mix()
        {
            var rnd = new Random();
            var countGameBlocks = locationGameBlocksArray.Length;
            for (int i = 0; i < countGameBlocks * countGameBlocks; i++)
            {
                var zeroRelatedGameBlocksArray = locationGameBlocksArray.Where(x => x.IsRelatedWith(GetLocation(0))).ToArray();
                var shiftingGameBlock = zeroRelatedGameBlocksArray[rnd.Next(zeroRelatedGameBlocksArray.Length)];
                Shift(shiftingGameBlock.Value);
            }
        }

        private GameBlock[] CreateBlocksArray(IEnumerable<int> blocksSequence)
        {
            int rowCount = 0;
            int colCount = 0;

            var gameField = new List<GameBlock>();
            foreach (var blockInts in blocksSequence)
            {
                gameField.Add(new GameBlock(blockInts, colCount, rowCount));
                colCount++;
                if (colCount < Size) continue;
                colCount = 0;
                rowCount++;
            }
            return gameField.OrderBy(x => x.Value).ToArray();
        }

        private GameBlock[,] CreateBlocksMatrix()
        {
            var matrix = new GameBlock[Size, Size];
            foreach (var gameBlock in locationGameBlocksArray)
            {
                matrix[gameBlock.PositionX, gameBlock.PositionY] = gameBlock;
            }
            return matrix;
        }

        public void Shift(int value)
        {
            var movingGameBlock = GetLocation(value);
            var zero = GetLocation(0);

            if (!movingGameBlock.IsRelatedWith(zero))
                throw new ArgumentException();

            // Swap in matrix
            locationGameBlocksMatrix[zero.PositionX, zero.PositionY] = movingGameBlock;
            locationGameBlocksMatrix[movingGameBlock.PositionX, movingGameBlock.PositionY] = zero;

            // Swap
            var prevY = movingGameBlock.PositionY;
            var prevX = movingGameBlock.PositionX;
            movingGameBlock.PositionY = zero.PositionY;
            movingGameBlock.PositionX = zero.PositionX;
            zero.PositionY = prevY;
            zero.PositionX = prevX;
        }

        public GameBlock GetLocation(int value) { return locationGameBlocksArray[value]; }

        public GameBlock[] GameBlocksArray { get { return locationGameBlocksArray; } }

        public int this[int x, int y] { get { return locationGameBlocksMatrix[x, y].Value; } }

        public int Size { get; set; }
    }
}
