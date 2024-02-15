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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace task2
{
    /// <summary>
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {

        public ChangePage()
        {
            InitializeComponent();

            XDocument xdoc = XDocument.Load("Students.xml");
            XElement students = xdoc.Element("students");
            foreach (XElement student in students.Elements("student"))
            {
                string item = student.Element("surname").Value + " " + student.Element("name").Value + " " + student.Element("patronymic").Value;
                Combobox.Items.Add(item);
            }
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Content = new Change2Page(Combobox.SelectedItem.ToString());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EstimationsPage());
        }
    }
}
