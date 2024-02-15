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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("Users.xml");
            XElement users = xdoc.Element("users");
            if (users != null)
            {
                foreach (XElement user in users.Elements())
                {
                    if (LoginTextbox.Text == user.Attribute("login").Value & PasswordTextbox.Text == user.Element("password").Value)
                    {
                        NavigationService.Navigate(new MenuPage());
                    }
                }
            }
            ErrorLabel.Visibility = Visibility.Visible;
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
