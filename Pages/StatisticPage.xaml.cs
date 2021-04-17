using Agamotto.Classes;
using Agamotto.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
        }

        private void SmartClick(object sender, RoutedEventArgs e)
        {
            var t = (Button)sender;
            string s = (string)t.Content;
            List<Prod> list;
            
            using (ProductContext db=new ProductContext()) 
            {
                list = db.Products.ToList();
            }
            
            Dictionary<string, double> D = new Dictionary<string, double>();
            var categories = new List<string>() 
            {
                "Смартфоны и телефоны",
                "Ноутбуки и компьютеры",
                "Телевизоры и другая аудио-видео электроника",
                "Техника для дома",
                "Техника для кухни"
            };
            switch (s)
            {
                case "Общая статистика":
                    try
                    {
                        foreach (var ch in list) if(D.ContainsKey(ch.Name)==false)D.Add(ch.Name, ch.CountOfChanges);
                        var p = Methods.Model1("Общая статистика", "Количество изменений", "Товары", D);
                        NavigationService.Navigate(new StatCategory(p));
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Статистика по категориям":
                    for (int i = 0; i < categories.Count; i++)
                    {
                        if (D.ContainsKey(categories[i]) == false) D.Add(categories[i], list.Where(h=>h.Category==categories[i]).Select(g=>g.CountOfChanges).Sum());
                    }
                    var p1 = Methods.Model2("Статистика по категориям", "Количество изменений", "Категории", D);
                    NavigationService.Navigate(new StatCategory(p1));
                    break;
                case "Статистика по производителю":
                    List<Brend> Brendlist;
                    using (ProductContext db = new ProductContext()) 
                    {
                        Brendlist = db.Brends.ToList();
                        for (int i = 0; i < Brendlist.Count; i++)
                        {
                            if (D.ContainsKey(Brendlist[i].Name) == false) D.Add(Brendlist[i].Name, Brendlist[i].Prods.Select(c => c.CountOfChanges).Sum());
                        }
                    }
                    var p2 = Methods.Model2("Статистика по производителю", "Количество изменений", "Производители", D);
                    NavigationService.Navigate(new StatCategory(p2));
                    break;
                default:
                    //NavigationService.Navigate(new AllPage());
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



    }
}
