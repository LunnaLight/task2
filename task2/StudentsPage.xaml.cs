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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        XDocument xdoc = XDocument.Load("Students.xml");
        public StudentsPage()
        {
            InitializeComponent();

            var table = xdoc.Descendants("student").Select(x => new
            {
                id = x.Attribute("id").Value,
                Имя = x.Element("name").Value,
                Фамилия = x.Element("surname").Value,
                Отчество = x.Element("patronymic").Value,
                Адрес = x.Element("address").Value,
                Телефон = x.Element("phone").Value
            });
            DataGrid.ItemsSource = table;
        }
        

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsAddPage());
        }
    }
}
