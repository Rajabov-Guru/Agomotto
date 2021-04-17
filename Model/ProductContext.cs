using System;
using System.Data.Entity;
using System.Linq;

namespace Agamotto.Model
{
    public class ProductContext : DbContext
    {
        
        public ProductContext()
            : base("ProductContext")
        {
        }

        public virtual DbSet<Prod> Products { get; set; }
        public virtual DbSet<Change> Changes { get; set; }
        public virtual DbSet<Brend> Brends { get; set; }

    }

    
}