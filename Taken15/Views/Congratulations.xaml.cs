using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Taken15.Views
{
    /// <summary>
    /// Interaction logic for Congratulations.xaml
    /// </summary>
    public partial class Congratulations : Window
    {
        public Congratulations()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MediaElement_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
