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
    /// Логика взаимодействия для StudentsAddPage.xaml
    /// </summary>
    public partial class StudentsAddPage : Page
    {
        public StudentsAddPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsPage());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string[] tb = {NameTextbox.Text, SurnameTextbox.Text, PatronymicTextbox.Text, AddressTextbox.Text, PhoneTextbox.Text};
            if(tb.Any(x => x == ""))
            {
                Mess("Заполните все поля!");
            }
            else
            {
                XDocument sdoc = XDocument.Load("Students.xml");
                XDocument edoc = XDocument.Load("Estimations.xml");
                XElement students = sdoc.Element("students");
                XElement estimations = edoc.Element("estimations");
                int id = students.Descendants("student").Count();
                students.Add(new XElement("student", new XAttribute("id", id), new XElement("name", tb[0]), new XElement("surname", tb[1]), new XElement("patronymic", tb[2]), new XElement("address", tb[3]), new XElement("phone", tb[4])));
                sdoc.Save("Students.xml");
                estimations.Add(new XElement("estimation", new XAttribute("idSt", id)));
                edoc.Save("Estimations.xml");
                Mess("Студент добавлен");
            }
        }

        private void Mess(string s)
        {
            ErrorLabel.Content = s;
            ErrorLabel.Visibility = Visibility.Visible;
        }
    }
}
