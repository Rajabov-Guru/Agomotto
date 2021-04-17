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
        public int? Prod_Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Increase { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public double PricBefore { get; set; }

        [ForeignKey("Prod_Id")]
        public virtual Prod Prod { get; set; }


        public string date => Date.ToString("dd.MM.yyy");
        public string prodName => Prod.Name;
    }
}
