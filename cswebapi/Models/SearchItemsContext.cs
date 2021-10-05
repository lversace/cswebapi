using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cswebapi.Models
{
    public class SearchItemsContext : DbContext
    {
        public SearchItemsContext(DbContextOptions<SearchItemsContext> options)
            : base(options)
        {
          
        }

        public DbSet<SearchItem> SearchItems { get; set; }
    }
}
