using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Model
{
    public class Change
    {
        public int Id { get; set; }
        public int? Product_Id { get; set; } // id продукта

        [Required]
        public DateTime Date { get; set; } // Дата фиксирования изменения

        [Required]
        public bool Increase { get; set; } // Повышение ( true = цена повысилась, false = цена снизилась)

        [Required]
        public double Sum { get; set; } // Сумма изменения

        [Required]
        public double PriceBefore { get; set; } // Цена до этого изменения

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }


        public string date => Date.ToString("dd.MM.yyy");
        public string prodName => Product.Name;
    }
}
