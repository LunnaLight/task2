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
    /// Логика взаимодействия для SubjectPage.xaml
    /// </summary>
    public partial class SubjectPage : Page
    {
        XDocument xdoc = XDocument.Load("Subjects.xml");
        public SubjectPage()
        {
            InitializeComponent();

            var table = xdoc.Descendants("subject").Select(x => new
            {
                id = x.Attribute("id").Value,
                Предмет = x.Element("name").Value,
                Лекции = x.Element("vLec").Value + " ч.",
                Практики = x.Element("vPr").Value + " ч.",
                Лабораторные = x.Element("vLab").Value + " ч."
            });
            DataGrid.ItemsSource = table;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
