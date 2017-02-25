using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Taken15.Annotations;

namespace Taken15.Models
{
    class Game
    {
        private Field field;
        public Game(params int[] blocks)
        {
            
        }

        public ObservableCollection<Block> GetBlocks { get; set; }
    }
}
