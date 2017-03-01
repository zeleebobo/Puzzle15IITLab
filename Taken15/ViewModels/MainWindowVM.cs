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
        private readonly Game game;

        public MainWindowVM()
        {
            //game = new Game(/*1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15*/ 16);
            game = Game.FromCsv("C:/Users/Админ/Desktop/Puzzle15IITLab/Taken15/FieldFile.csv");
            GameBlockClickCommand = new RelayCommand(x =>
            {
                game.GameBlockClick((int) x);
                if (!game.IsOver) return;

                var congratulations = new Congratulations();
                congratulations.Show();
            });
        }

        public RelayCommand GameBlockClickCommand { get; set; }

        public IEnumerable<GameBlock> FieldCollection => game.Blocks.Skip(1);

    }
}