using System;
using System.Linq;

namespace Taken15.Models
{
    class Game
    {
        private Field field;
        private readonly Field victoryField;

        public Game()
        {
            Size = 4;
            field = new Field(Size, GenerateBlocks());
            victoryField = new Field(Size, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0});
        }

        public Game(params int[] blocks)
        {
            if (ParametersIsInvalid(blocks))
                throw new ArgumentException();

            Size = (int) Math.Sqrt(blocks.Length);
            field = new Field(Size, blocks);
            // TODO: add vitory field creating
        }

        private bool ParametersIsInvalid(int[] blocks)
        {
            var size = Math.Sqrt(blocks.Length);
            return Math.Abs(size - (int) size) > 0.000001 || !blocks.Any(x => x == 0);
        }

        private int[] GenerateBlocks()
        {
            int[] blocks = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            var rand = new Random();
            return blocks.OrderBy(x => rand.Next()).ToArray();

        }

        public void GameBlockClick(int value)
        {
            GameBlock zero = field.GetLocation(0);
            if (field.GetLocation(value).IsNearZero(zero))
                field.Shift(value);
        }

        public int Size { get; }

        public bool IsEnd => field.GameBlocks.SequenceEqual(victoryField.GameBlocks);

        public GameBlock[] Blocks => field.GameBlocksWithoutZero;
    }
}
