using EmailValidation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailValidation.Repositories
{
    public interface IEmailV1Repository
    {
         Task<EmailV1> Get(int id);
         Task<IEnumerable<EmailV1>> GetAll();
         Task Add(EmailV1 emailV1);
         Task Delete(int id);
         Task Update(EmailV1 emailV1);

    }
}