using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "tamanho do nome deve ser entre 5 e 120 caracteres")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Base Salary")]
        [Range(100.0, 50000.0)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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