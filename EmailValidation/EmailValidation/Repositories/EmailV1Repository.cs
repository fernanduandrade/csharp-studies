using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailValidation.Data;
using EmailValidation.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailValidation.Repositories
{
    public class EmailV1Repository : IEmailV1Repository
    {
        private readonly IDataContext _context;
        public EmailV1Repository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(EmailV1 emailV1)
        {
            _context.EmailsV1.Add(emailV1);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var emailToDelete = await _context.EmailsV1.FindAsync(id);
            if(emailToDelete == null)
                throw new NullReferenceException();
            
            _context.EmailsV1.Remove(emailToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailV1> Get(int id)
        {
            return await _context.EmailsV1.FindAsync(id);
        }

        public async Task<IEnumerable<EmailV1>> GetAll()
        {
            return await _context.EmailsV1.ToListAsync();
        }

        public async Task Update(EmailV1 emailV1)
        {
            var emailToUpdate = await _context.EmailsV1.FindAsync(emailV1.Id);
            if(emailToUpdate == null) 
                throw new NullReferenceException();
            emailToUpdate.Email = emailV1.Email;
            emailToUpdate.Domain = emailV1.Domain;
            emailToUpdate.Valid_syntax = emailV1.Valid_syntax;

            await _context.SaveChangesAsync();
            
        }
    }
}