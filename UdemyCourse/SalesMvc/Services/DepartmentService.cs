using SalesMvc.Data;
using SalesMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesMvcContext _context;

        public DepartmentService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll() => _context.Department.OrderBy(record => record.Name).ToList();
    }
}