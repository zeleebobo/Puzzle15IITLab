using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Taken15.Models;
using Block = Taken15.Models.Block;

namespace Taken15.ViewModels
{
    class MainWindowWM
    {
        public ObservableCollection<Block> FieldCollection { get; set; }

        // TODO: animation, etc

        public ICommand BlockClickCommand { get; set; }

        public MainWindowWM()
        {
            var game = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            FieldCollection = new ObservableCollection<Block>
            {
                new Block(1, 0, 0),
                new Block(2, 1, 0),
                new Block(3, 2, 0),
                new Block(4, 3, 0),
                new Block(5, 0, 1),
                new Block(6, 1, 1),
                new Block(7, 2, 1),
                new Block(8, 3, 1),
                new Block(9, 0, 2),
                new Block(10, 1, 2),
                new Block(11, 2, 2),
                new Block(12, 3, 2),
                new Block(13, 0, 3),
                new Block(14, 1, 3),
                new Block(15, 2, 3)
            };
            ItemsCount = 3;
        }

        public int ItemsCount { get; set; }
        
        private void ClickOnBlock() {}

    }
}
