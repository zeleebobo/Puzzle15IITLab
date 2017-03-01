using System;
using System.ComponentModel;

namespace Taken15.Models
{
    class GameBlock : INotifyPropertyChanged
    {
        private int positionX;
        private int positionY;

        public GameBlock(int value, int x, int y)
        {
            Value = value;
            positionX = x;
            positionY = y;
        }

        public bool IsRelatedWith(GameBlock gameBlock)
        {
            return Math.Abs(gameBlock.PositionX - PositionX) + gameBlock.PositionY - PositionY == 1 ||
                   Math.Abs(gameBlock.PositionY - PositionY) + gameBlock.PositionX - PositionX == 1;
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

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
