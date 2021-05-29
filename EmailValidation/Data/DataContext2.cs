using Microsoft.EntityFrameworkCore;
using EmailValidation.Models;

namespace EmailValidation.Data
{
    public class DataContext2 : DbContext, IDataContext2
    {
        public DataContext2(DbContextOptions<DataContext2> options) : base(options)
        {

        }

        public DbSet<EmailV2> EmailsV2 {get;set;}
    }
}