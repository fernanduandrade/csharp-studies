using Microsoft.EntityFrameworkCore;
using EmailValidation.Models;

namespace EmailValidation.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EmailV1> EmailsV1 {get;set;}
    }
}