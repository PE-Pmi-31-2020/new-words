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
        public Library()
        {
            List<User> items = new List<User>();
            items.Add(new User() { Word = "John Doe"});
            items.Add(new User() { Word = "Jane Doe" });
            items.Add(new User() { Word = "Sammy Doe" });
            lvUsers.ItemsSource = items;
        }
    }

    public class User
    {
        public string Word { get; set; }

    }
}
