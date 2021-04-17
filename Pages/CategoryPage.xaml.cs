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

namespace Agamotto.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        private void SmartClick(object sender, RoutedEventArgs e)
        {
            var t = (Button)sender;
            string s = (string)t.Content;
            switch (s)
            {
                case "Смартфоны и телефоны":
                    NavigationService.Navigate(new AllPage(1));
                    break;
                case "Компьютеры и ноутбуки":
                    NavigationService.Navigate(new AllPage(2));
                    break;
                case "Телевизоры":
                    NavigationService.Navigate(new AllPage(3));
                    break;
                case "Техника для дома":
                    NavigationService.Navigate(new AllPage(4));
                    break;
                case "Техника для кухни":
                    NavigationService.Navigate(new AllPage(5));
                    break;
                default:
                    NavigationService.Navigate(new AllPage());
                    break;
            }
            //NavigationService.Navigate(new AllPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void MainClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

    }
}
