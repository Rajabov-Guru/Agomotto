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
using System.Text;
using Agamotto.Windows;

namespace Agamotto.Controls
{
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
            List<Product> S = new List<Product>();
            using (StreamReader sr = new StreamReader("test.txt", Encoding.UTF8)) 
            {
                for (int i = 1; i <= 70; i++) 
                {
                    var t = sr.ReadLine().Split("][".ToCharArray());
                    //for (int j = 0; j < t.Length; j++) Console.WriteLine("|"+t[j]+"|");
                    Product p = new Product();
                    p.Category = t[0];
                    p.Name = t[2];
                    p.Price = double.Parse(t[4]);
                    p.BrandName = t[6];
                    p.CountOfChanges = 0;
                    p.LastChangeDate = DateTime.Now;
                    p.Href = t[8];
                    p.Properties = t[10];
                    S.Add(p);
                    Console.WriteLine("Успешно"+i);
                }
               
            }
            prodGrid.ItemsSource = S;
        }

        private void ViewClick(object sender, RoutedEventArgs e)//ты тут
        {
            if (prodGrid.SelectedItem != null) 
            {
                var t=(Product)prodGrid.SelectedItem;
                ProductForm p = new ProductForm();
                p.name.Text = t.Name;
                p.brend.Content = t.BrandName;
                p.price.Content = t.Price.ToString()+"руб.";

            }
        }
    }
}
