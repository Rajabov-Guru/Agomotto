
using Agamotto.Classes;
using Agamotto.Model;
using Agamotto.Pages;
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

namespace Agamotto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


            /*List<Prod> products;
            using (ProductContext db = new ProductContext())
            {
                products = db.Products.ToList();
            }
            for (int i = 0; i < products.Count; i++)
            {
                Methods.AddChanges(products[i]);
            }*/



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
            //MainFrame.Content = new StatisticPage();
        }

        
          
    }
}
