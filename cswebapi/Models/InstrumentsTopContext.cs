using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cswebapi.Models
{
    public class InstrumentsTopContext : DbContext
    {
        public InstrumentsTopContext(DbContextOptions<InstrumentsTopContext> options)
            : base(options)
        {
                
        }

        public DbSet<InstrumentsTop> InstrumentsTop { get; set; }

    }
}
