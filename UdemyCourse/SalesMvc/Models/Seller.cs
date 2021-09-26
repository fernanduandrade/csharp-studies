using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public int DepartmentId {get; set;}

        public Seller()
        {
        }


        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;

        }

        public void AddSales(SalesRecord saleRecord) 
        {
            Sales.Add(saleRecord);
        }

        public void RemoveSales(SalesRecord saleRecord) 
        {
            Sales.Remove(saleRecord);
        }

        public double TotalSales(DateTime initial, DateTime final) 
        {
            return Sales.Where(saleRecord => saleRecord.Date >= initial && saleRecord.Date <= final).Sum(saleRecord => saleRecord.Amount);
        }
 
    }
}