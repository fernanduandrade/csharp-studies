using EmailValidation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailValidation.Repositories
{
    public interface IEmailV2Repository
    {
        Task<EmailV2> Get(int id);
        Task<IEnumerable<EmailV2>> GetAll();
        Task Add(EmailV2 emailV2);
        Task Delete(int id);
        Task Update(EmailV2 emailV2);
    }
}
