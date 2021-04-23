using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Model
{
    public class Product
    {

        public int Id { get; set; }
        public int? Brend_Id { get; set; }

        [Required]
        public string Category { get; set; } // Категория товара

        [Required]
        public string Name { get; set; } // Наименование 

        [Required]
        public double Price { get; set; } // Цена

        [Required]
        public string Href { get; set; } // Ссылка на товар

        [Required]
        public string Properties { get; set; } // Характеристики

        [Required]
        public int CountOfChanges { get; set; } // Количество изменений

        [Required]
        public DateTime LastChangeDate { get; set; } // Дата последнего изменения
        [Required]
        public string image { get; set; }

        public virtual ICollection<Change> Changes { get; set; }

        [ForeignKey("Brend_Id")]
        public virtual Brend Brend { get; set; }

        public string BrandName => Brend.Name;
        public string Date => LastChangeDate.ToString("dd.MM.yyyy");
        public void RandCount(int n = 15) => CountOfChanges = new Random().Next(0, n + 1);
    }
}
