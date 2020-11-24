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
using DAL.Models;

namespace NewWords
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Window
    {
        private List<Word> words;
        public Card(List<Word> words)
        {
            this.words = words;
            InitializeComponent();
            word.Content = words[words.Count - 1].word;
        }

        private void WordButton_Click(object sender, RoutedEventArgs e)
        {
            word.Content = words[words.Count - 1].translation;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if(words.Count != 0)
            {
                words.RemoveAt(words.Count - 1);
                if (words.Count != 0)
                {
                    word.Content = words[words.Count - 1].word;
                }
                else
                {
                    MessageBox.Show("You won!");
                }
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            words.Insert(0, words[words.Count - 1]);
            words.RemoveAt(words.Count - 1);
            word.Content = words[words.Count - 1].word;

        }
    }
}
