using System;
using System.ComponentModel;

namespace Taken15.Models
{
    class GameBlock : INotifyPropertyChanged
    {
        private int positionX;
        private int positionY;

        public GameBlock(int value)
        {
            Value = value;
        }

        public GameBlock(int value, int x, int y)
        {
            Value = value;
            positionX = x;
            positionY = y;
        }

        public bool IsRelatedWith(GameBlock zero)
        {
            return Math.Abs(zero.PositionX - PositionX) == 1 && zero.PositionY - PositionY == 0 ||
                   Math.Abs(zero.PositionY - PositionY) == 1 && zero.PositionX - PositionX == 0;
        }

        public int Value { get; }

        public int PositionX
        {
            get { return positionX; }
            set
            {
                positionX = value;
                OnPropertyChanged("PositionX");
            }
        }

        public int PositionY
        {
            get
            {
                return positionY;
            }
            set
            {
                positionY = value;
                OnPropertyChanged("PositionY");
            }
        }

        public override bool Equals(object obj)
        {
            var gameBlock = (GameBlock) obj;
            return gameBlock != null && Value == gameBlock.Value && PositionX == gameBlock.PositionX && PositionY == gameBlock.PositionY;
        }

        public static bool operator ==(GameBlock lhs, GameBlock rhs)
        {
            return object.ReferenceEquals(lhs, null) ? object.ReferenceEquals(rhs, null) : lhs.Equals(rhs);
        }

        public static bool operator !=(GameBlock lhs, GameBlock rhs)
        {
            return !(lhs == rhs);
        }

        void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
