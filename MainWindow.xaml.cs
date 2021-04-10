using Agamotto.Controls;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
            //<Grid x:Name="MainGrid" Margin="37,12,21,-108" Grid.Row="1" Grid.ColumnSpan="3" Height="435" VerticalAlignment="Top"/>
        
        private void ProductClick(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Children.Count > 0) MainGrid.Children.RemoveAt(0);
            ProductControl emp = new ProductControl();
            MainGrid.Children.Add(emp);
            Grid.SetRow(emp, 1);
            MainGrid.Height = emp.prodGrid.Height;
            emp.Width = MainGrid.Width;
            SetTitle("Товары");
        }

        public void SetTitle(string s) 
        {
            pr.Visibility = Visibility.Hidden;
            cg.Visibility = Visibility.Hidden;
            gr.Visibility = Visibility.Hidden;
            title.Content = s;
            title.Visibility = Visibility.Visible;
        }

        public void DesetTitle(string s="No") 
        {
            title.Visibility = Visibility.Hidden;
            pr.Visibility = Visibility.Visible;
            cg.Visibility = Visibility.Visible;
            gr.Visibility = Visibility.Visible;
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DesetTitle();
            if (MainGrid.Children.Count > 0) MainGrid.Children.RemoveAt(0);
        }
    }
}
