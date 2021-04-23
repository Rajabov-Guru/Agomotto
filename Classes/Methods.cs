using Agamotto.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Classes
{
    static class Methods
    {
        public static async Task<bool> Refresh(Product p)
        {
            double d = p.Price;
            try
            {
                d = await ParseMethods2.GetPrice(p.Href).ConfigureAwait(false);
            }
            catch
            {
                Console.WriteLine($"ERROR:   {p.Name}  {p.Id}\n");
            }
            if (d != p.Price)
            {
                Change ch = new Change();
                ch.Product_Id = p.Id;
                ch.PriceBefore = p.Price;
                ch.Sum = d - p.Price;
                p.Price += ch.Sum;
                ch.Increase = ch.Sum > 0;
                ch.Date = DateTime.Now;
                p.LastChangeDate = ch.Date;
                using (ParserContext db = new ParserContext())
                {
                    var k = db.Products.First(c => c.Id == p.Id);
                    k.Price = p.Price;
                    k.LastChangeDate = p.LastChangeDate;
                    k.CountOfChanges += 1;
                    db.Changes.Add(ch);
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }
        public static async void DataToDB(int pages)
        {
            var Notebooks = await ParseMethods2.ParsePages(pages, ParseMethods2.GetUrl("notebooks"));
            var Smartphones = await ParseMethods2.ParsePages(pages, ParseMethods2.GetUrl("smartphones"));
            var TVs = await ParseMethods2.ParsePages(pages, ParseMethods2.GetUrl("television"));
            var Forhome = await ParseMethods2.ParsePages(pages, ParseMethods2.GetUrl("forhome"));
            var Forkitchen = await ParseMethods2.ParsePages(pages, ParseMethods2.GetUrl("forkitchen"));

            var list1 = ParseMethods2.ParseGoods(Notebooks, "Ноутбуки и компьютеры");
            var list2 = ParseMethods2.ParseGoods(Smartphones, "Смартфоны и телефоны");
            var list3 = ParseMethods2.ParseGoods(TVs, "Телевизоры и другая аудио-видео электроника");
            var list4 = ParseMethods2.ParseGoods(Forhome, "Техника для дома");
            var list5 = ParseMethods2.ParseGoods(Forkitchen, "Техника для кухни");
            Console.WriteLine("\n\nВсе данные спарсены. Подождите пока они добавятся в БАЗУ ДАННЫХ........\n\n");
            AddAllData(list1);
            AddAllData(list2);
            AddAllData(list3);
            AddAllData(list4);
            AddAllData(list5);
            Console.WriteLine("Операция выполнена: Данные успешно добавлены в базу. ");
        }
        public static void AddAllData(List<Good[]> B)
        {

            for (int j = 0; j < B.Count; j++)
            {
                for (int i = 0; i < B[j].Length; i++)
                {
                    var good = B[j][i];
                    using (ParserContext db = new ParserContext())
                    {
                        Product p = new Product();
                        p.Category = good.type;
                        p.Name = good.name;
                        p.Price = good.price;
                        p.CountOfChanges = 0;
                        p.LastChangeDate = DateTime.Now;
                        p.Href = good.href;
                        p.Properties = good.properties;
                        p.image = good.image;
                        Brend b = new Brend();
                        b.Name = good.nameBrend;

                        if (db.Brends.Where(v => v.Name == b.Name).Count() == 0)
                        {
                            db.Brends.Add(b);
                            db.SaveChanges();
                        }

                        p.Brend_Id = db.Brends.First(c => c.Name == b.Name).Id;
                        db.Products.Add(p);
                        db.SaveChanges();
                        Console.WriteLine($"Товар {p.Name} успешно добавлен {i}  {DateTime.Now.ToString()}");
                    }
                }
            }



        }
        public static PlotModel Model3(string maintitle, string seriesTitle, string subtitle, List<string> list1,List< double> list2)
        {
            var model = new PlotModel { Title = maintitle };

            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis2",
                Angle = -45,
                Title = subtitle,
                TicklineColor = OxyColors.White,
                ItemsSource = list1
            }) ;
            var series = new OxyPlot.Series.ColumnSeries();
            model.Series.Add(series);
            for (int i = 0; i < list2.Count; i++)
            {
                series.Items.Add(new ColumnItem(list2[i]));
            }
            series.FillColor = OxyColors.Red;
            series.Title = seriesTitle;
            model.TitleColor = OxyColors.White;
            model.TextColor = OxyColors.White;
            model.PlotAreaBorderColor = OxyColors.White;
            return model;
        }

        public static PlotModel Model2(string maintitle, string seriesTitle, string subtitle, Dictionary<string, double> source)
        {
            var model = new PlotModel { Title = maintitle };

            List<string> categoreies = source.Keys.ToList();

            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis2",
                Angle = -45,
                Title = subtitle,
                TicklineColor = OxyColors.White,
                ItemsSource = categoreies
            });
            var series = new OxyPlot.Series.ColumnSeries();
            model.Series.Add(series);
            for (int i = 0; i < categoreies.Count; i++)
            {
                series.Items.Add(new ColumnItem(source[categoreies[i]]));
            }
            series.FillColor = OxyColors.Red;
            series.Title = seriesTitle;
            model.TitleColor = OxyColors.White;
            model.TextColor = OxyColors.White;
            model.PlotAreaBorderColor = OxyColors.White;
            return model;
        }

        public static PlotModel Model4(string maintitle, string seriesTitle, string subtitle, List<string> list1, List<double> list2)
        {
            var model = new PlotModel { Title = maintitle };
            var rand = new Random();
            


            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis2",
                Angle = -90,
                TicklineColor = OxyColors.White,
                Title = subtitle,
                ItemsSource = list1
            });

            List<DataPoint> D = new List<DataPoint>();
            for (int i = 0; i < list2.Count; i++)
            {
                D.Add(new DataPoint(i, list2[i]));
            }

            var lineSeries = new OxyPlot.Series.LineSeries
            {
                MarkerSize = 5,
                Color = OxyColors.Green,
                MarkerType = MarkerType.Diamond,
                LineStyle=LineStyle.Solid,
                Title = seriesTitle,
                ItemsSource = D

            };
            model.Series.Add(lineSeries);
            model.TitleColor = OxyColors.White;
            model.TextColor = OxyColors.White;
            model.PlotAreaBorderColor = OxyColors.White;
            return model;
        }


        public static PlotModel Model1(string maintitle, string seriesTitle, string subtitle, Dictionary<string, double> source)
        {
            var model = new PlotModel { Title = maintitle };
            var rand = new Random();
            List<string> categoreies = source.Keys.ToList();


            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis2",
                Angle = -90,
                TicklineColor = OxyColors.White,
                Title = subtitle,
                ItemsSource = categoreies
            });

            List<DataPoint> D = new List<DataPoint>();
            for (int i = 0; i < categoreies.Count; i++)
            {
                D.Add(new DataPoint(i, source[categoreies[i]]));
            }

            var lineSeries = new OxyPlot.Series.LineSeries
            {
                MarkerSize = 1,
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Diamond,
                Title = seriesTitle,
                ItemsSource = D

            };
            model.Series.Add(lineSeries);
            model.TitleColor = OxyColors.White;
            model.TextColor = OxyColors.White;
            model.PlotAreaBorderColor = OxyColors.White;
            return model;
        }


        public static void AddChanges(Product product)
        {
            product.RandCount(10);
            for (int i = 0; i < product.CountOfChanges; i++)
            {
                RandomDateTime rand = new RandomDateTime(2021, 4, 1);
                Change ch = new Change();
                ch.Product_Id = product.Id;
                ch.PriceBefore = product.Price;
                ch.Sum = Math.Round(Methods.GetSum(product.Price), 2);
                product.Price += ch.Sum;
                ch.Increase = ch.Sum > 0;
                ch.Date = rand.Next();
                product.LastChangeDate = ch.Date;
                using (ParserContext db = new ParserContext())
                {
                    db.Changes.Add(ch);
                    db.SaveChanges();
                }
            }
            using (ParserContext db = new ParserContext())
            {
                var c = db.Products.First(v => v.Id == product.Id);
                c.Price = Math.Round(product.Price, 2);
                c.CountOfChanges = product.CountOfChanges;
                c.LastChangeDate = product.LastChangeDate;
                db.SaveChanges();
            }
        }



        public static double GetSum(double s)
        {
            int procent = 0;
            while (procent == 0) procent = new Random().Next(-15, 20);
            Console.WriteLine($"pr: {procent}");
            return (procent * s) / 100;
        }


        /*public static List<Prod> GetList2()
        {
            List<Prod> S = new List<Prod>();
            using (StreamReader sr = new StreamReader("test.txt", Encoding.UTF8))
            {
                for (int i = 1; i <= 50; i++)
                {
                    string q = sr.ReadLine();
                    if (q.Contains("["))
                    {
                        var t = q.Split('[');
                        using (ProductContext db = new ProductContext())
                        {
                            Prod p = new Prod();
                            p.Category = t[0];
                            p.Name = t[1];
                            p.Price = double.Parse(t[2]);
                            //p.BrandName = t[3];
                            p.CountOfChanges = 0;
                            p.LastChangeDate = DateTime.Now;
                            p.Href = t[4];
                            p.Properties = t[6];
                            p.image = t[5];
                            Brend b = new Brend();
                            b.Name = t[3];

                            S.Add(p);
                            if (db.Brends.Where(v => v.Name == b.Name).Count() == 0)
                            {
                                db.Brends.Add(b);
                                db.SaveChanges();
                            }

                            p.Brend_Id = db.Brends.First(c => c.Name == b.Name).Id;
                            db.Products.Add(p);
                            db.SaveChanges();
                            Console.WriteLine("Успешно" + i);
                        }
                    }
                    else Console.WriteLine("Bitch");

                }

            }
            return S;
        }*/


        


        /*public static List<Product> GetList()
        {
            List<Product> S = new List<Product>();
            using (StreamReader sr = new StreamReader("test.txt", Encoding.UTF8))
            {
                for (int i = 1; i <= 500; i++)
                {
                    string q = sr.ReadLine();
                    if (q.Contains("["))
                    {
                        var t = q.Split('[');
                        Product p = new Product();
                        p.Category = t[0];
                        p.Name = t[1];
                        p.Price = double.Parse(t[2]);
                        p.BrandName = t[3];
                        p.CountOfChanges = 0;
                        p.LastChangeDate = DateTime.Now;
                        p.Href = t[4];
                        p.Properties = t[6];
                        p.image = t[5];
                        p.RandCount();
                        S.Add(p);
                        Console.WriteLine("Успешно" + i);
                    }
                    else Console.WriteLine("Bitch");

                }

            }
            return S;
        }*/
    }
}
