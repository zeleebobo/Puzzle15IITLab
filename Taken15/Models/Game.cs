using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Taken15.Models
{
    class Game
    {
        private readonly Field field;
        private readonly Field victoryField;

        public Game(int blocksCount) // Default constructor
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

        public Game(params int[] blocks) // Custom game
        {
            if (BlocksCountIsValid(blocks.Length) || !blocks.Any(x => x == 0))
                throw new ArgumentException();

            Size = (int) Math.Sqrt(blocks.Length);
            field = new Field(Size, blocks);
            victoryField = new Field(Size, CreateVictoryFieldSequenceArray(blocks));
            IsOver = false;
        }

        public static Game FromCsv(string path)
        {
            var arr = (from line in File.ReadAllLines(path)
                       from item in line.Split(';')
                       select Convert.ToInt32(item)).ToArray();

            if (arr.Length != arr.Distinct().Count())
                throw new DataException();

            return new Game(arr);
        }

        public void GameBlockClick(int value)
        {
            var zero = field.GetLocation(0);
            if (!field.GetLocation(value).IsRelatedWith(zero)) return;
            field.Shift(value);
            if (field.GameBlocksArray.SequenceEqual(victoryField.GameBlocksArray))
                IsOver = true;
        }

        private bool BlocksCountIsValid(int count)
        {
            const double tolerance = 0.000001;
            var size = Math.Sqrt(count);
            return Math.Abs(size - (int) size) > tolerance || size - 1 < tolerance;
        }

        private int[] CreateVictoryFieldSequenceArray(int[] blocks)
        {
            var victoryFieldList = blocks.Where(x => x != 0).OrderBy(x => x).ToList();
            victoryFieldList.Add(0);
            return victoryFieldList.ToArray();
        }

        public int Size { get; }

        public bool IsOver { get; private set; }

        public int this[int x, int y] => field[x, y]; // I don't know why this 
        public void Shift(int value) => field.Shift(value); // and this

        public GameBlock[] Blocks => field.GameBlocksArray;
    }
}
