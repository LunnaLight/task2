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

namespace task2
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsPage());
        }

        private void SubjectsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubjectPage());
        }

        private void EstimationsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EstimationsPage());
        }
    }
}
