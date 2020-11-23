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

namespace NewWords
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Window
    {
        private readonly string[] nebulas = { "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2", "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2" };

        private void bindListBox()
        {
            words.ItemsSource = nebulas;
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(words.SelectedItem.ToString(), "Nebulas", MessageBoxButton.OK,
                MessageBoxImage.Information);
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
    }

}
