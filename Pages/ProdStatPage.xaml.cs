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
    
    public partial class ProdStatPage : Page
    {
        public ProdStatPage(int id)
        {
            InitializeComponent();
            string name = "";
            List<string> list1=new List<string>();

            List<double> list2 = new List<double>();

            using (ProductContext db=new ProductContext())
            {
                name=db.Products.First(c => c.Id == id).Name;
                var l = db.Products.First(c => c.Id == id).Changes.OrderBy(c=>c.Date).ToList();
                l.ForEach(delegate(Change r) 
                {
                    list1.Add(r.date);
                    list2.Add((int)r.Sum);
                });
            }
            gone.Model = Methods.Model4(name,"Сумма","Даты",list1,list2);
            List<string> list11 = new List<string>();
            list11.Add("Start");
            List<double> list22 = new List<double>();

            using (ProductContext db = new ProductContext())
            {
                name = db.Products.First(c => c.Id == id).Name;
                var l = db.Products.First(c => c.Id == id).Changes.OrderBy(c => c.Date).ToList();
                list22.Add(l.First().PricBefore);
                l.ForEach(delegate (Change r)
                {
                    list11.Add(r.date);
                    list22.Add((int)r.Sum+r.PricBefore);
                });
            }
            list11[list11.Count - 1] = "Finish";
            
            gtwo.Model = Methods.Model4(name, "Цена", "Даты", list11, list22);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}