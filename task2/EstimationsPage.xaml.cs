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
    /// Логика взаимодействия для EstimationsPage.xaml
    /// </summary>
    public partial class EstimationsPage : Page
    {
        XDocument esdoc = XDocument.Load("Estimations.xml");
        XDocument stdoc = XDocument.Load("Students.xml");
        XDocument sbdoc = XDocument.Load("Subjects.xml");
        public EstimationsPage()
        {
            InitializeComponent();

            var table = esdoc.Descendants("estimation").Select(x => new
            {
                Студент = StudentName(x),
                Оценки = SubjectName(x)
            });
            DataGrid.ItemsSource = table;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePage());
        }

        private string StudentName(XElement x)
        {
            XElement students = stdoc.Element("students");
            foreach (XElement student in students.Elements("student"))
            {
                if (student.Attribute("id").Value == x.Attribute("idSt").Value)
                {
                    string r = (student.Element("surname").Value)+" "+(student.Element("name").Value)+" "+(student.Element("patronymic").Value);
                    return r;
                }
            }
            return "данных нет";
        }

        private string SubjectName(XElement x)
        {
            string r = ""; 
            XElement subjects = sbdoc.Element("subjects");

            


            foreach (XElement subject in subjects.Elements("subject"))
            {
                foreach(XElement sub in x.Elements("idSb"))
                {
                    XAttribute est = sub.Attribute("est");
                    if (subject.Attribute("id").Value == sub.Value)
                    {
                        string sbName = subject.Element("name").Value;

                        if (est != null)
                        {

                            r += sbName + " — " + est.Value + "\n";
                        }
                        else
                        {
                            r += sbName + " — оценка не выставлена" + "\n";
                        }
                    }
                }
            }
            return r;
        }
    }
}
