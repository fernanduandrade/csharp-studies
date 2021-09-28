using SalesMvc.Data;
using SalesMvc.Models;
using System.Collections.Generic;
using System.Linq;
using SalesMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SalesMvc.Services
{
    public class SellerService
    {
        private readonly SalesMvcContext _context;

        public SellerService(SalesMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FinById(int id) => _context.Seller
            .Include(record => record.Department)
            .FirstOrDefault(record => record.Id == id);
        
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        } 

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(record => record.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try 
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException error)
            {
                throw new DbConcurrencyException(error.Message);
            }
            
        }
    }
}