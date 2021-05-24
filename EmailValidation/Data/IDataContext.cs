using Microsoft.EntityFrameworkCore;
using EmailValidation.Models;
using System.Threading.Tasks;
using System.Threading;

namespace EmailValidation.Data
{
    public interface IDataContext
    {
         DbSet<EmailV1> EmailsV1 {get;set;}
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}