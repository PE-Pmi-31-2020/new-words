// <copyright file="TranslatedCard.xaml.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NewWords
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for TranslatedCard.xaml
    /// </summary>
    public partial class TranslatedCard : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedCard"/> class.
        /// </summary>
        public TranslatedCard()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            card.Show();
        }
    }
}
