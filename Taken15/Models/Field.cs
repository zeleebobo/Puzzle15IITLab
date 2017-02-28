﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Taken15.Models
{
    class Field
    {
        private readonly GameBlock[] _locationGameBlocksArray;
        private readonly GameBlock[,] _locationGameBlocksMatrix;

        public Field(int size, int[] blocksInts)
        {
            Size = size;
            _locationGameBlocksArray = CreateBlocks(blocksInts);
            _locationGameBlocksMatrix = CreateMatrix();
        }

        public void Mix()
        {
            var rnd = new Random();
            var countGameBlocks = _locationGameBlocksArray.Length;
            for (int i = 0; i <  countGameBlocks * countGameBlocks; i++)
            {
                var zeroRelatedGameBlocksArray = _locationGameBlocksArray.Where(x => x.IsRelatedWith(GetLocation(0))).ToArray();
                var shiftingGameBlock = zeroRelatedGameBlocksArray[rnd.Next(zeroRelatedGameBlocksArray.Length)];
                Shift(shiftingGameBlock.Value);
            }
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

        private GameBlock[,] CreateMatrix()
        {
            var matrix = new GameBlock[Size, Size];
            foreach (var gameBlock in _locationGameBlocksArray)
            {
                matrix[gameBlock.PositionX, gameBlock.PositionY] = gameBlock;
            }
            return matrix;
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

            // Swap in matrix
            _locationGameBlocksMatrix[zero.PositionX, zero.PositionY] = movingGameBlock;
            _locationGameBlocksMatrix[movingGameBlock.PositionX, movingGameBlock.PositionY] = zero;

            // Swap
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
                return _locationGameBlocksMatrix[x, y].Value;
            }
        }
    }
}
