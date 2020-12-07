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
using BLL;


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

        private void LibraryButton_Click_1(object sender, RoutedEventArgs e)
        {
            Library library = new Library(sessionId);
            library.Show();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(sessionId);
            Card card = new Card(game.startGameWords(), game.startGameSubjects());
            card.Show();
        }

        private void ExitExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
