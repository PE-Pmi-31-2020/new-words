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
        private List<Subject> subjectsList;
        private List<Word> wordsList;
        private int currentSubjectId;

        private void bindListBox()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                subjectsList = dbRepo.getAllSubjectsForUser(this.sessionId);
                subjects.DisplayMemberPath = "name";
                subjects.ItemsSource = subjectsList;
            }
        }

        private void subjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            words.Visibility = Visibility.Visible;
            addWord.Visibility = Visibility.Visible;
            title.Content = "WORDS";
            addSubject.Visibility = Visibility.Collapsed;
            wordTextBox.Visibility = Visibility.Visible;
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                currentSubjectId = ((Subject)subjects.SelectedItem).id;
                wordsList = dbRepo.getAllWordsForSubject(currentSubjectId);
                words.DisplayMemberPath = "word";
                words.ItemsSource = wordsList;
            }
        }
        private void words_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(words.SelectedItem != null)
            {
                MessageBox.Show(((Word)words.SelectedItem).translation);
            }
        }

            public Library(int sessionId)
        {
            this.sessionId = sessionId;
            InitializeComponent();
            bindListBox();
        }

        
        private void backToSubject_Click(object sender, RoutedEventArgs e)
        {
            words.Visibility = Visibility.Collapsed;
            addWord.Visibility = Visibility.Collapsed;
            title.Content = "SUBJECTS";
            addSubject.Visibility = Visibility.Visible;
        }

        private void addWord_Click(object sender, RoutedEventArgs e)
        {
            string[] wordInfo = wordTextBox.Text.Split(',');
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                dbRepo.addWord(wordInfo[0], wordInfo[1], currentSubjectId);
                wordsList = dbRepo.getAllWordsForSubject(currentSubjectId);
                words.DisplayMemberPath = "word";
                words.ItemsSource = wordsList;
            }
            words.UpdateLayout();

        }

        private void addSubject_Click(object sender, RoutedEventArgs e)
        {
            CreateSubject createSubject = new CreateSubject(sessionId);
            createSubject.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
