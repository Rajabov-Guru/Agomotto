using System;
using System.Data.Entity;
using System.Linq;

namespace Agamotto.Model
{
    public class ParserContext : DbContext
    {
        
        public ParserContext()
            : base("ParserContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Change> Changes { get; set; }
        public virtual DbSet<Brend> Brends { get; set; }
    }

    
}