using Agamotto.Model;
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
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        private int id;
        public ChangePage(int id)
        {
            InitializeComponent();
            this.id = id;
            using (ParserContext db = new ParserContext()) 
            {
                changeGrid.ItemsSource = db.Products.First(c => c.Id == id).Changes.ToList();
            }

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
