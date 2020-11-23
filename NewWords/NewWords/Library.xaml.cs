﻿using System;
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
        private string[] wordNames = { "word1", "word2", "word3", "word4", "word5", "word6", "word7" };
        private string[] subjectNames;
        private void bindListBox()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                List<Subject> subjectsList = dbRepo.getAllSubjects();
                subjectNames = new string[subjectsList.Count];
                for(int i = 0; i < subjectsList.Count; i++)
                {
                    subjectNames[i] = subjectsList[i].name;
                }
                subjects.ItemsSource = subjectNames;
                // dbRepo.insertTestData(10);

                words.ItemsSource = wordNames;
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(subjects.SelectedItem.ToString(), "Nebulas", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            words.Visibility = Visibility.Visible;
            addWord.Visibility = Visibility.Visible;
            title.Content = "WORDS";
            addSubject.Visibility = Visibility.Collapsed;
            wordTextBox.Visibility = Visibility.Visible;
        }

        public Library()
        {
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

        //
        private void addWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addSubject_Click(object sender, RoutedEventArgs e)
        {
            CreateSubject createSubject = new CreateSubject();
            createSubject.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
