﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AngleSharp;
using System.Net;

namespace Agamotto.Classes
{
    static class ParseMethods
    {

        public static void DownloadRemoteImageFile(string uri, string fileName)//метод для скачивания фотографии по url адресу
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }

        public static async Task<List<AngleSharp.Dom.IDocument>> ParsePages(int pages, string link) //метод который парсит несколько страниц
        {
            List<AngleSharp.Dom.IDocument> Docs = new List<AngleSharp.Dom.IDocument>();
            for (int i = 1; i <= pages; i++)
            {
                if (i != 1) link = link.Replace((i - 1).ToString(), i.ToString());
                AngleSharp.Dom.IDocument document = await ParseDumb(link);
                if (document != null) Docs.Add(document);
            }
            Console.WriteLine(Docs.Count);
            return Docs;
        }


        public static async Task<double> GetPrice(string f)//получает цену на товар по ссылке
        {
            AngleSharp.Dom.IDocument document = await ParseDumb(f);
            var all = document.All;
            var s = all.Where(c => c.TagName == "SPAN" && c.Attributes.Length > 0 && c.Attributes[0].Value == "final-cost").ToArray();
            string str = s[0].TextContent.Replace(" ", "").Replace("\n", "");
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i])) str2 += str[i];
            }
            return double.Parse(str2);
        }


        public static void ParseGoods(List<AngleSharp.Dom.IDocument> Listdocuments, string path, string category) //парсинг товаров ИЗМЕНИИИТЬ!!!!
        {
            int count = 0;
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < Listdocuments.Count; i++)
                {
                    var v = Listdocuments[i].All;
                    var body = v[30].Children;//найти индекс BODY
                    var seq = v.Where(m => m.Attributes.Length > 0 && m.Attributes[0].Value == "catalog_main_table j-products-container").ToArray();//большой див товаров

                    var f = seq[0].Children.ToArray();//внутренние дивы

                    var b = GetInfo(f, category);//массив Good

                    for (int j = 0; j < b.Length; j++)
                    {
                        try
                        {
                            sw.WriteLine($"Категория товара: |{ b[j].type}|");
                            sw.WriteLine($"Цена: |{ b[j].price}|");
                            sw.WriteLine($"Название бренда: |{ b[j].nameBrend.Replace("/", "").Trim()}|");
                            sw.WriteLine($"Название товара: |{ b[j].name}|");
                            sw.WriteLine($"Характеристики: |{ b[j].properties}|");
                            sw.WriteLine($"Ссылка на товар: |{b[j].href}|");
                            sw.WriteLine("================================================================");
                            count++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            Console.WriteLine($"Спарсено {count} товаров");
        }





        public static async Task<AngleSharp.Dom.IDocument> ParseDumb(string link) //парсинг всей html старницы
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(link);
            return document;
        }





        public static Good[] GetInfo(AngleSharp.Dom.IElement[] f, string category)//получение информации с одной страницы
        {
            List<Good> result = new List<Good>();
            for (int i = 0; i < f.Length; i++)
            {
                Good g = new Good();
                g.type = category;
                var e = f[i];
                var e2 = e.Children[0].Children[0].Children[0].Children[0].Children[0];

                var href = e2.Attributes.Where(c => c.Name == "href").ToArray();

                try
                {
                    string p = e2.Children[1].Children[1].Children[0].TextContent;
                    g.price = double.Parse(p.Trim().Split('₽')[0].Replace(" ", ""));
                    var n = e2.Children[1].Children[2].Children[1].TextContent.Split('/');
                    g.name = n[0];
                    if (n.Length > 1 && n[1] != "")
                    {
                        string P = "";
                        for (int j = 1; j < n.Length; j++) P += n[j];
                        g.properties = P;

                    }
                    g.nameBrend = e2.Children[1].Children[2].Children[0].TextContent.Replace("/", "").Trim();
                    g.href = "https://www.wildberries.ru" + href[0].Value;
                    result.Add(g);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GteINfo: {ex.Message}");
                }

            }
            return result.ToArray();
        }


        public static List<Good[]> ParseGoods2(List<AngleSharp.Dom.IDocument> Listdocuments, string category)
        {
            List<Good[]> result = new List<Good[]>();
            int count = 0;
            for (int i = 0; i < Listdocuments.Count; i++)
            {
                var v = Listdocuments[i].All;
                var body = v[30].Children;
                var seq = v.Where(m => m.Attributes.Length > 0 && m.Attributes[0].Value == "catalog_main_table j-products-container").ToArray();//большой див товаров

                var f = seq[0].Children.ToArray();

                var b = GetInfo(f, category);//массив Good
                result.Add(b);
                count++;

            }
            Console.WriteLine($"Спарсено {count} страниц");
            return result;
        }

    }
}
