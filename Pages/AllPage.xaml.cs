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
using System.IO;
using Agamotto.Classes;
using Agamotto.Model;

namespace Agamotto.Pages
{
    
    public partial class AllPage : Page
    {
        public AllPage()
        {
            InitializeComponent();
            using (ParserContext db =new ParserContext()) 
            {
                List<Product> source= db.Products.ToList();
                source.ForEach(delegate (Product p)
                {
                    string h = p.Brend.Name;
                });
                prodGrid.ItemsSource = source;
            }
            //prodGrid.ItemsSource=Methods.GetList();
        }
        public AllPage(int category) 
        {
            InitializeComponent();
            List<Product> source;
            using (ParserContext db = new ParserContext())
            {
                source = db.Products.ToList();
                source.ForEach(delegate(Product p) 
                {
                    string h=p.Brend.Name;
                });
            }
            switch (category)
            {
                case 1:
                    prodGrid.ItemsSource = source.Where(p => p.Category == "Смартфоны и телефоны");
                    title.Content = "Смартфоны и телефоны";
                    break;
                case 2:
                    prodGrid.ItemsSource = source.Where(p => p.Category == "Ноутбуки и компьютеры");
                    title.Content = "Ноутбуки и компьютеры";
                    break;
                case 3:
                    prodGrid.ItemsSource = source.Where(p => p.Category == "Телевизоры и другая аудио-видео электроника");
                    title.Content = "Телевизоры и другая электроника";
                    break;
                case 4:
                    prodGrid.ItemsSource = source.Where(p => p.Category == "Техника для дома");
                    title.Content = "Техника для дома";
                    break;
                case 5:
                    prodGrid.ItemsSource = source.Where(p => p.Category == "Техника для кухни");
                    title.Content = "Техника для кухни";
                    break;
                default:
                    prodGrid.ItemsSource = source;
                    break;

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

        private void ViewClick(object sender, RoutedEventArgs e)
        {
            if (prodGrid.SelectedItem != null) 
            {
                var t = (Product)prodGrid.SelectedItem;
                //Console.WriteLine(t.GetForm());
                NavigationService.Navigate(new ProductPage(t));
            }
        }
    }
}
