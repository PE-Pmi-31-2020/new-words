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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewWords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int sessionId;
        public MainWindow(int sessionId)
        {
            this.sessionId = sessionId;
            InitializeComponent();
        }

        private void startLearning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            card.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Library library = new Library(sessionId);
            library.Show();
        }
    }
}
