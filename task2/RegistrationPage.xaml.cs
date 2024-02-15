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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextbox.Text != "" & PasswordTextbox.Text != "")
            {
                XDocument xdoc = XDocument.Load("Users.xml");
                XElement users = xdoc.Element("users");
                bool isAvailable = true;
                foreach (XElement user in users.Elements())
                {
                    if (user.Attribute("login").Value == LoginTextbox.Text)
                    {
                        Mess("Этот логин уже занят");
                        isAvailable = false;
                        break;
                    }
                }
                if (isAvailable)
                {
                    users.Add(new XElement("user", new XAttribute("login", LoginTextbox.Text), new XElement("password", PasswordTextbox.Text)));
                    xdoc.Save("Users.xml");
                    Mess("Вы зарегистрированы");
                }
            }
            else
            {
                Mess("Введите логин и пароль");
            }            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Mess(string s)
        {
            ErrorLabel.Content = s;
            ErrorLabel.Visibility = Visibility.Visible;
        }
    }
}
