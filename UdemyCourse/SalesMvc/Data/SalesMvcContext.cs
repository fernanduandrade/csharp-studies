using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesMvc.Models
{
    public class SalesMvcContext : DbContext
    {
        public SalesMvcContext (DbContextOptions<SalesMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SalesMvc.Models.Department> Department { get; set; }
    }
}