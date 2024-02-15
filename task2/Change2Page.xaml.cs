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
    /// Логика взаимодействия для Change2Page.xaml
    /// </summary>
    public partial class Change2Page : Page
    {
        XDocument sbdoc = XDocument.Load("Subjects.xml");
        XDocument stdoc = XDocument.Load("Students.xml");
        XDocument edoc = XDocument.Load("Estimations.xml");
        string fullname;
        
        public Change2Page(string fullname)
        {
            InitializeComponent();
            this.fullname = fullname;

            Label.Content = "студент " + fullname;
            ErrorLabel.Visibility = Visibility.Hidden;
            ComboboxE.ItemsSource = new List<string>() {"нет", "1", "2", "3", "4", "5"};

            XElement subjects = sbdoc.Element("subjects");
            foreach (XElement subject in subjects.Elements("subject"))
            {
                ComboboxS.Items.Add(subject.Element("name").Value);
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxE.SelectedItem == null | ComboboxS.SelectedItem == null)
            {
                Mess("Выберите предмет и оценку");
            }
            else
            {
                XElement students = stdoc.Element("students");
                XElement subjects = sbdoc.Element("subjects");
                XElement estimations = edoc.Element("estimations");

                string subSelected = ComboboxS.SelectedItem.ToString();
                string stID = "";
                string estSelected = ComboboxE.SelectedItem.ToString();
                string sbID = (subjects.Elements("subject").FirstOrDefault(n => n.Element("name").Value == subSelected)).Attribute("id").Value;

                foreach (XElement student in students.Elements("student"))
                {
                    string item = student.Element("surname").Value + " " + student.Element("name").Value + " " + student.Element("patronymic").Value;
                    if (item == fullname)
                    {
                        stID = student.Attribute("id").Value;
                    }
                }
                XElement xstudent = estimations.Elements("estimation").FirstOrDefault(n => n.Attribute("idSt").Value == stID);



                if (xstudent.Elements("idSb").Any(n => n.Value == sbID))
                {
                    if (estSelected != "нет")
                    {
                        xstudent.Elements("idSb").FirstOrDefault(n => n.Value == sbID).Attribute("est").Value = estSelected;
                    }
                    else
                    {
                        xstudent.Elements("idSb").FirstOrDefault(n => n.Value == sbID).Remove();
                    }
                    Mess("Оценка выставлена");
                }
                else
                {
                    if (estSelected != "нет")
                    {
                        xstudent.Add(new XElement("idSb", sbID));
                        xstudent.Elements("idSb").FirstOrDefault(n => n.Value == sbID).Add(new XAttribute("est", estSelected));
                        Mess("Оценка выставлена");
                    }
                    else
                    {
                        Mess("Выберите оценку");
                    }
                }
                edoc.Save("Estimations.xml");
            }
        }

        private void Mess(string s)
        {
            ErrorLabel.Content = s;
            ErrorLabel.Visibility = Visibility.Visible;
        }
    }
}
