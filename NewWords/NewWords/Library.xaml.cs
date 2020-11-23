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

namespace NewWords
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Window
    {
        private readonly string[] newSubjects = { "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2", "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2" };
        private readonly string[] newWords = { "FirstNew", "SecondNew", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2", "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2" };

        private void bindListBox()
        {
            subjects.ItemsSource = newSubjects;
        }

        private void bindListBoxForWords()
        {
            words.ItemsSource = newWords;
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(subjects.SelectedItem.ToString(), "Nebulas", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            words.Visibility = Visibility.Visible;

        }

        public Library()
        {
            InitializeComponent();
            bindListBox();
            bindListBoxForWords();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //back button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void backToSubject_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
