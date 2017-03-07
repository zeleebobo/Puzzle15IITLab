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
        protected Field field;
        protected Field victoryField;

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

        public bool GameBlockClick(int value)
        {
            var zero = field.GetLocation(0);
            if (!field.GetLocation(value).IsRelatedWith(zero)) return false;
            field.Shift(value);
            if (field.GameBlocksArray.SequenceEqual(victoryField.GameBlocksArray))
                IsOver = true;
            return true;
        }

        protected bool BlocksCountIsValid(int count)
        {
            const double tolerance = 0.000001;
            var size = Math.Sqrt(count);
            return Math.Abs(size - (int) size) > tolerance || size - 1 < tolerance;
        }

        protected int[] CreateVictoryFieldSequenceArray(int[] blocks)
        {
            var victoryFieldList = blocks.Where(x => x != 0).OrderBy(x => x).ToList();
            victoryFieldList.Add(0);
            return victoryFieldList.ToArray();
        }

        public int Size { get; protected set; }

        public bool IsOver { get; protected set; }

        public int this[int x, int y] => field[x, y]; // I don't know why this 
        public void Shift(int value) => field.Shift(value); // and this

        public GameBlock[] Blocks => field.GameBlocksArray;
    }
}
