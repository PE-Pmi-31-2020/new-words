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
        public Library(int sessionId)
        {
            this.sessionId = sessionId;
            InitializeComponent();
            bindListBox();
        }
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
            //MessageBox.Show(((Subject)subjects.SelectedItem).name);
        }
        private void words_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void backToSubject_Click(object sender, RoutedEventArgs e)
        {
            words.Visibility = Visibility.Collapsed;
            addWord.Visibility = Visibility.Collapsed;
            deleteWord.Visibility = Visibility.Collapsed;
            editWord.Visibility = Visibility.Collapsed;
            rule.Visibility = Visibility.Collapsed;
            backToSubject.Content = "subjects";
            title.Content = "SUBJECTS";
            addSubjectButton.Visibility = Visibility.Visible;
            subjectNameTextBox.Visibility = Visibility.Visible;
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
            wordTextBox.Clear();
            words.UpdateLayout();

        }

        private void EditWordButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (subjects.SelectedItem != null)
            {
                using (DataBase db = new DataBase())
                {
                    DatabaseRepository dbRepo = new DatabaseRepository(db);
                    int subjectId = ((Subject)subjects.SelectedItem).id;
                    dbRepo.deleteSubject(subjectId);
                    subjectsList = dbRepo.getAllSubjectsForUser(this.sessionId);
                    subjects.DisplayMemberPath = "name";
                    subjects.ItemsSource = subjectsList;
                }

            }
        }
        private void DeleteWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (subjects.SelectedItem != null)
            {
                using (DataBase db = new DataBase())
                {
                    DatabaseRepository dbRepo = new DatabaseRepository(db);
                    int wordId = ((Word)words.SelectedItem).id;
                    dbRepo.deleteWord(wordId);
                    wordsList = dbRepo.getAllWordsForSubject(currentSubjectId);
                    words.DisplayMemberPath = "word";
                    words.ItemsSource = wordsList;
                }
                words.UpdateLayout();

            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            string subjectName = subjectNameTextBox.Text;
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                dbRepo.addSubject(subjectName, sessionId);
                subjectsList = dbRepo.getAllSubjectsForUser(this.sessionId);
                subjects.DisplayMemberPath = "name";
                subjects.ItemsSource = subjectsList;
            }
            subjectNameTextBox.Clear();

        }

        private void subjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            words.Visibility = Visibility.Visible;
            addWord.Visibility = Visibility.Visible;
            deleteWord.Visibility = Visibility.Visible;
            editWord.Visibility = Visibility.Visible;
            rule.Visibility = Visibility.Visible;
            title.Content = "WORDS";
            backToSubject.Content = "<- subjects/" + ((Subject)subjects.SelectedItem).name;
            addSubjectButton.Visibility = Visibility.Collapsed;
            subjectNameTextBox.Visibility = Visibility.Collapsed;
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

        private void words_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (words.SelectedItem != null)
            {
                MessageBox.Show(((Word)words.SelectedItem).translation);
            }
        }
    }

}
