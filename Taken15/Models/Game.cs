using System;
using System.Collections.Generic;
using System.Linq;

namespace Taken15.Models
{
    class Game
    {
        private readonly Field field;
        private readonly Field victoryField;

        public Game(int blocksCount) // Default constructor
        {
            if (CountIsValid(blocksCount))
                throw new ArgumentException();

            Size = (int)Math.Sqrt(blocksCount);
            var victoryBlocksArray = CreateVictoryFieldBlocksArray(Enumerable.Range(0, Size * Size).ToArray());
            victoryField = new Field(Size, victoryBlocksArray);
            field = new Field(Size, victoryBlocksArray);
            field.Mix();
            IsOver = false;
        }

        public Game(params int[] blocks) // Custom game
        {
            if (CountIsValid(blocks.Length) || !blocks.Any(x => x == 0))
                throw new ArgumentException();

            Size = (int) Math.Sqrt(blocks.Length);
            field = new Field(Size, blocks);
            victoryField = new Field(Size, CreateVictoryFieldBlocksArray(blocks));
            IsOver = false;
        }

        private bool CountIsValid(int count)
        {
            const double tolerance = 0.000001;
            var size = Math.Sqrt(count);
            return Math.Abs(size - (int) size) > tolerance || Math.Abs(size - 1) < tolerance;
        }

        private int[] CreateVictoryFieldBlocksArray(int[] blocks)
        {
            var victoryFieldList = blocks.Where(x => x != 0).OrderBy(x => x).ToList();
            victoryFieldList.Add(0);
            return victoryFieldList.ToArray();
        }

        public void GameBlockClick(int value)
        {
            GameBlock zero = field.GetLocation(0);
            if (field.GetLocation(value).IsRelatedWith(zero))
            {
                field.Shift(value);
                if (field.GameBlocksArray.SequenceEqual(victoryField.GameBlocksArray))
                    IsOver = true;
            }
        }

        public int Size { get; }

        public bool IsOver { get; private set; }

        public GameBlock[] Blocks => field.GameBlocksArrayWithoutZero;
    }
}
