using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailValidation.Data;
using EmailValidation.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailValidation.Repositories
{
    public class EmailV2Repository : IEmailV2Repository
    {
        private readonly IDataContext2 _context;
        public EmailV2Repository(IDataContext2 context)
        {
            _context = context;
        }

        public async Task Add(EmailV2 emailv2)
        {
            _context.EmailsV2.Add(emailv2);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var emailToDelete = await  _context.EmailsV2.FindAsync(id);
            if(emailToDelete == null)
                throw new NullReferenceException();
            
            _context.EmailsV2.Remove(emailToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailV2> Get(int id)
        {
            return await _context.EmailsV2.FindAsync(id);
        }

        public async Task<IEnumerable<EmailV2>> GetAll()
        {
            return await _context.EmailsV2.ToListAsync();
        }

        public async Task Update(EmailV2 emailV2)
        {
            var emailToUpdate = await _context.EmailsV2.FindAsync(emailV2.Id);
            if(emailToUpdate == null)
                throw new NullReferenceException();

            emailToUpdate.Email_Address = emailV2.Email_Address;
            emailToUpdate.Domain = emailV2.Domain;
            emailToUpdate.Valid_Syntax = emailV2.Valid_Syntax;
            emailToUpdate.Disposable = emailV2.Disposable;
            emailToUpdate.WebMail = emailV2.WebMail;
            emailToUpdate.Deliverable = emailV2.Deliverable;
            emailToUpdate.Catch_All = emailV2.Catch_All;
            emailToUpdate.Gibberish = emailV2.Gibberish;
            emailToUpdate.Spam = emailV2.Spam;

            await _context.SaveChangesAsync();
        }
    }
}