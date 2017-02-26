using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Taken15.Models;
using Taken15.Other;

namespace Taken15.ViewModels
{
    class MainWindowWM
    {
        private Game game;

        public MainWindowWM()
        {
            game = new Game(5, 15, 12, 13, 1, 10, 9, 4, 6, 7, 0, 14, 3, 2, 11, 8);
            GameBlockClickCommand = new RelayCommand(x => game.GameBlockClick((int) x));
            //TODO: add game over statement and command binding
        }

        public RelayCommand GameBlockClickCommand { get; set; }

        public GameBlock[] FieldCollection => game.Blocks;

    }
}
