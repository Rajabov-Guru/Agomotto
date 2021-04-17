using AngleSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Classes
{
    static class ParseMethods2
    {

        public static void Print(List<Good[]> B)
        {
            using (StreamWriter sw = new StreamWriter("test.txt", true, Encoding.UTF8))
            {
                for (int j = 0; j < B.Count; j++)
                {
                    for (int i = 0; i < B[j].Length; i++)
                    {
                        Console.WriteLine(B[j][i].ToFormat());
                    }
                }
            }
        }
        public static string GetUrl(string key)
        {

            string[] links = new string[]
            {
                "https://www.wildberries.ru/catalog/elektronika/smartfony-i-telefony?page=1",
                "https://www.wildberries.ru/catalog/elektronika/noutbuki-periferiya?page=1",
                "https://www.wildberries.ru/catalog/elektronika/tv-audio-foto-video-tehnika?page=1",
                "https://www.wildberries.ru/catalog/elektronika/tehnika-dlya-doma?page=1",
                "https://www.wildberries.ru/catalog/elektronika/tehnika-dlya-kuhni?page=1"
            };


            if (key.Contains("smartphones")) return links[0];
            else if (key.Contains("notebooks")) return links[1];
            else if (key.Contains("television")) return links[2];
            else if (key.Contains("forhome")) return links[3];
            else if (key.Contains("forkitchen")) return links[4];
            else return "";


        }

        public static List<Good[]> ParseGoods(List<AngleSharp.Dom.IDocument> Listdocuments, string category)
        {
            List<Good[]> result = new List<Good[]>();
            int count = 0;
            for (int i = 0; i < Listdocuments.Count; i++)
            {

                var v = Listdocuments[i].All;
                var container = v.First(c => c.ClassName == "catalog_main_table ");
                var b = GetInfo(container, category).Result;//массив Good
                result.Add(b);
                count++;

            }
            Console.WriteLine($"Спарсено {count} страниц");
            return result;
        }

        public static async Task<double> GetPrice(string f)//получает цену на товар по ссылке
        {
            AngleSharp.Dom.IDocument document = await ParseDumb(f).ConfigureAwait(false);
            var all = document.All;
            string str = all.First(c => c.ClassName == "final-cost").TextContent.Replace(" ", "").Replace("\n", "");
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i])) str2 += str[i];
            }
            return double.Parse(str2);
        }

        public static async Task<AngleSharp.Dom.IDocument> ParseDumb(string link) //парсинг всей html старницы
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(link).ConfigureAwait(false);
            return document;
        }

        public static async Task<List<AngleSharp.Dom.IDocument>> ParsePages(int pages, string link) //метод который парсит несколько страниц
        {
            List<AngleSharp.Dom.IDocument> Docs = new List<AngleSharp.Dom.IDocument>();
            for (int i = 1; i <= pages; i++)
            {
                if (i != 1) link = link.Replace((i - 1).ToString(), i.ToString());
                AngleSharp.Dom.IDocument document = await ParseDumb(link).ConfigureAwait(false);
                if (document != null) Docs.Add(document);
            }
            Console.WriteLine(Docs.Count);
            return Docs;
        }

        public static async Task<Good[]> GetInfo(AngleSharp.Dom.IElement f, string category)//получение информации с одной страницы
        {
            int count = 0;
            int t = f.Children.Length;
            List<Good> result = new List<Good>();
            for (int i = 0; i < t; i++)
            {
                Good g = new Good();
                g.type = category;
                var first = f.Children[i];
                g.href = "https://www.wildberries.ru" + first.GetElementsByClassName("ref_goods_n_p j-open-full-product-card")[0].Attributes[1].Value;
                try
                {
                    string k = "https:" + first.GetElementsByClassName("thumbnail")[1].Attributes[1].Value;
                    if (k.Contains("//static") == false) g.image = "https:" + first.GetElementsByClassName("thumbnail")[1].Attributes[1].Value;
                }
                catch
                {

                }

                g.price = double.Parse(first.GetElementsByClassName("price")[0].TextContent.Trim().Split('₽')[0].Replace(" ", ""));
                var n = first.GetElementsByClassName("brand-name c-text-sm")[0].TextContent.Split('/');
                g.nameBrend = n[0];
                n = first.GetElementsByClassName("goods-name c-text-sm")[0].TextContent.Split('/');
                g.name = n[0];
                if (n.Length > 1 && n[1] != "")
                {
                    string P = "";
                    for (int j = 1; j < n.Length; j++) P += n[j];
                    g.properties = P;

                }
                result.Add(g);
                count++;
            }
            Console.WriteLine($"Parsed: {count}");
            return result.ToArray();
        }


    }
}
