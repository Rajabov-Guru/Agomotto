using Agamotto.Classes;
using Agamotto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);
    public partial class MainPage : Page
    {
        BackgroundWorker worker;
        public MainPage()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Ref();
        }
        private void CopyFiles() 
        {
            UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(bar.SetValue);
            double value = 0;
            for (int i = 0; i < 100; i++) 
            {
                Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, ++value });
                Thread.Sleep(500);
            }
        }
        private async void Ref() 
        {
            UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(bar.SetValue);
            double value = 0;
            int count = 0;
            using (ProductContext db = new ProductContext())
            {
                var g = db.Products.ToList();
                for (int i = 0; i < g.Count; i++)
                {
                    bool r = await Methods.Refresh(g[i]).ConfigureAwait(false);
                    count += r ? 1 : 0;
                    Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, ++value });
                    Console.WriteLine(r);
                }
            }
            MessageBox.Show($"Обнаружено {count} изменений", "Результат обновления:", new MessageBoxButton());
        }
        private void AllClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllPage());
        }

        private void CategoryClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CategoryPage());
        }

        private void StatisticClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticPage());
        }

        private async void AddAllClick(object sender, RoutedEventArgs e)
        {
            Methods.DataToDB(2);
        }

        private async void RefreshClick(object sender, RoutedEventArgs e)
        {
            bar.Maximum = 1000;
            bar.Value = 0;
            worker.RunWorkerAsync();
            //int count = 0;
            //using (ProductContext db = new ProductContext())
            //{
            //    var g = db.Products.ToList();
            //    for (int i = 0; i < g.Count; i++)
            //    {
            //        bool r = await Methods.Refresh(g[i]).ConfigureAwait(false);
            //        count += r ? 1 : 0;
            //        Console.WriteLine(r);
            //    }
            //}
            //MessageBox.Show($"Обнаружено {count} изменений", "Результат обновления:", new MessageBoxButton());
        }

        

    }
}
