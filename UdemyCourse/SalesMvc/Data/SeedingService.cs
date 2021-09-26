using SalesMvc.Models;
using SalesMvc.Models.Enums;
using System.Linq;
using System;

namespace SalesMvc.Data
{
    public class SeedingService
    {
        private SalesMvcContext _context;

        public SeedingService(SalesMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || 
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
               return;  // Já tem dados no db 
            }
            else 
            {
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Makeup");

            Seller s1 = new Seller(1, "Fernando", "nando.ju@gmail.com", new DateTime(1998, 02, 19), 1000.0, d1);
            Seller s2 = new Seller(2, "Lara", "lara.abreu@gmail.com", new DateTime(2001, 04, 07), 1000.0, d2);
        
            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021,08,24), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2021,09,07), 19000.0, SaleStatus.Peding, s2);
        
            _context.Department.AddRange(d1,d2);
            _context.Seller.AddRange(s1,s2);
            _context.SalesRecord.AddRange(sr1,sr2);
            }
        
        }
        
    }
}