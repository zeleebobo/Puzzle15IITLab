using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Taken15.Models;
using Taken15.Other;
using Taken15.Views;

namespace Taken15.ViewModels
{
    class MainWindowVM
    {
        private Game game;

        public MainWindowVM()
        {
            game = new Game(/*1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15*/16);
            GameBlockClickCommand = new RelayCommand(x =>
            {
                game.GameBlockClick((int) x);
                if (!game.IsOver) return;
                var congratulations = new Congratulations();
                congratulations.Show();
            });
        }

        public RelayCommand GameBlockClickCommand { get; set; }

        public GameBlock[] FieldCollection => game.Blocks;

    }
}
