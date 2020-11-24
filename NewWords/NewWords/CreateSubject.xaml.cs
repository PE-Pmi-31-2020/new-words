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

namespace NewWords
{
    /// <summary>
    /// Interaction logic for CreateSubject.xaml
    /// </summary>
    public partial class CreateSubject : Window
    {
        private int sessionId;
        public CreateSubject(int sessionId)
        {
            this.sessionId = sessionId;
            InitializeComponent();
        }

        private void addSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            string subjectName = subjectNameTextBox.Text;
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                dbRepo.addSubject(subjectName, sessionId);
            }
            subjectNameTextBox.Clear();
            this.Close();
        }
    }
}
