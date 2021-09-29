using SalesMvc.Data;
using SalesMvc.Models;
using System.Collections.Generic;
using System.Linq;
using SalesMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesMvc.Services
{
    public class SellerService
    {
        private readonly SalesMvcContext _context;

        public SellerService(SalesMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FinByIdAsync(int id) => await _context.Seller
            .Include(record => record.Department)
            .FirstOrDefaultAsync(record => record.Id == id);
        
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = _context.Seller.Find(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException)
            {
                
                throw new IntegrityException("Não é possível deletar pois o vendedor(a) possui vendas");
            }
           
        } 

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(record => record.Id == obj.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try 
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException error)
            {
                throw new DbConcurrencyException(error.Message);
            }
            
        }
    }
}