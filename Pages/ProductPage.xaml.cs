using Agamotto.Classes;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private int id;
        public ProductPage()
        {
            InitializeComponent();
        }

        public ProductPage(Product p) 
        {
            InitializeComponent();
            id = p.Id;
            name.Text = p.Name;
            price.Content = (int)p.Price+ " ₽";
            brend.Content = p.BrandName;
            try
            {
                //string str= ParseMethods.GetPicture(p.Href).Result;
                image.Source=new BitmapImage(new Uri(p.image));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
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

        private void StatClick(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new ProdStatPage(id));
        }

        private void tableClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePage(id));
        }

        private async void RefreshClick(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            using (ParserContext db = new ParserContext()) 
            {
                p = db.Products.First(c => c.Id == id);
            }
            bool t = await Methods.Refresh(p).ConfigureAwait(false);
            Console.WriteLine(t);
            if (t == false)
            {
                MessageBox.Show("Изменения не обнаружены", "Результат обновления:", new MessageBoxButton());
            }
            else 
            {
                MessageBox.Show("Было обнаружено изменение в цене", "Результат обновления:", new MessageBoxButton());
            }
        }
    }
}
