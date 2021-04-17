using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto
{
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public int CountOfChanges{ get; set; }
        public DateTime LastChangeDate { get; set; }
        public string Href { get; set; }
        public string Properties { get; set; }
        public string image { get; set; }

        public string GetForm() 
        {
            return $"{Category}\n{Name}\n{Price}\n{BrandName}\n{CountOfChanges}\n{LastChangeDate}\n==========";
        }

        public void RandCount() 
        {
            var r = new Random();
            CountOfChanges = r.Next(1,30);
        }

    }
}
