using Microsoft.EntityFrameworkCore;
using EmailValidation.Models;
using System.Threading.Tasks;
using System.Threading;

namespace EmailValidation.Data
{
    public interface IDataContext2
    {
         DbSet<EmailV2> EmailsV2 {get; set;}
         Task<int>  SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}