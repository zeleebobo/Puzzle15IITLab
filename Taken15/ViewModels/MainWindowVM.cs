using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Taken15.Models;
using Taken15.Other;
using Taken15.Views;


namespace Taken15.ViewModels
{
    class MainWindowVM
    {
        private readonly Game3 game;

        public MainWindowVM()
        {
            game = new Game3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
            //game = Game.FromCsv("C:/Users/Админ/Desktop/Puzzle15IITLab/Taken15/FieldFile.csv");
            GameBlockClickCommand = new RelayCommand(x =>
            {
                game.GameBlockClick((int) x);
                if (!game.IsOver) return;

                var congratulations = new Congratulations();
                congratulations.Show();
            });
            GameBackCommand = new RelayCommand(x => game.Back());
            GameForwardCommand = new RelayCommand(x => game.Forward());
        }

        public RelayCommand GameBlockClickCommand { get; set; }

        public RelayCommand GameBackCommand { get; set; }

        public RelayCommand GameForwardCommand { get; set; }

        public IEnumerable<GameBlock> FieldCollection { get { return game.Blocks.Skip(1); } }

    }
}