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
            }
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
