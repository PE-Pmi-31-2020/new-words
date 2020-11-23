// <copyright file="Library.xaml.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NewWords
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Library.xaml.
    /// </summary>
    public partial class Library : Window
    {
        private readonly string[] nebulas = { "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2", "First", "Second", "Third", "First1", "Second1", "Third1", "First2", "Second2", "Third2" };

        private void BindListBox()
        {
            this.words.ItemsSource = this.nebulas;
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(
                this.words.SelectedItem.ToString(),
                "Nebulas",
                MessageBoxButton.OK,
                icon: MessageBoxImage.Information);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Library"/> class.
        /// </summary>
        public Library()
        {
            this.InitializeComponent();
            this.BindListBox();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
