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
using DAL;
using DAL.Models;

namespace NewWords
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Window
    {
        private int sessionId;
        private void bindListBox()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                List<Subject> subjects = dbRepo.getAllSubjectsForUser(this.sessionId);
                words.DisplayMemberPath = "name";
                words.ItemsSource = subjects;
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(((Subject)words.SelectedItem).name, "Subjects", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public Library(int sessionId)
        {
            this.sessionId = sessionId;
            InitializeComponent();
            bindListBox();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
