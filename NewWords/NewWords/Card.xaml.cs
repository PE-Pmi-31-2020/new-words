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
        private List<Subject> subjectsList;
        bool isUkrainian;
        bool isDarkTheme;
        public Card(List<Word> words, List<Subject> subjects)
        {
            isDarkTheme = false;
            this.words = words;
            this.subjectsList = subjects;
            InitializeComponent();
            if (subjectsList.Count != 0)
            {
                subjectBtn.Content = subjectsList.Where(x => x.id == words[words.Count - 1].subject_id).FirstOrDefault().name;
                word.Content = words[words.Count - 1].word;
            }
            isUkrainian = false;
        }

        private void WordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isUkrainian)
                {
                    word.Content = words[words.Count - 1].word;
                    isUkrainian = false;
                }
                else
                {
                    word.Content = words[words.Count - 1].translation;
                    isUkrainian = true;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("There is No Word. Go to the Library.");
            }
            catch(Exception)
            {
                MessageBox.Show("Exception!");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (words.Count != 0)
            {
                words.RemoveAt(words.Count - 1);
                if (words.Count != 0)
                {
                    word.Content = words[words.Count - 1].word;
                    subjectBtn.Content = subjectsList.Where(x => x.id == words[words.Count - 1].subject_id).FirstOrDefault().name;
                }
                else
                {
                    MessageBox.Show("You won!");
                }
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                words.Insert(0, words[words.Count - 1]);
                words.RemoveAt(words.Count - 1);
                word.Content = words[words.Count - 1].word;
                subjectBtn.Content = subjectsList.Where(x => x.id == words[words.Count - 1].subject_id).FirstOrDefault().name;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("There are No Words to Save. Go to the Library.");
            }
            catch (Exception)
            {
                MessageBox.Show("Exception!");
            }

        }

        private void subjectBtn_Click(object sender, RoutedEventArgs e)
        {
            subjectBtn.Content = "SUBJECT";
        }

        private void theme_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkTheme)
            {
                grid.Background = Brushes.White;
                isDarkTheme = false;
            }
            else
            {
                grid.Background = Brushes.Black;
                isDarkTheme = true;
            }
        }
    }
}
