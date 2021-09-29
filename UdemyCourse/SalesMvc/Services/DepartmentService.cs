using SalesMvc.Data;
using SalesMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesMvcContext _context;

        public DepartmentService(SalesMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() => await _context.Department
            .OrderBy(record => record.Name)
            .ToListAsync();
    }
}