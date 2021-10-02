using System.Collections.Generic;

namespace SalesMvc.Models.ViewModels
{
    public class SalesRecordViewModel
    {
        public SalesRecord SalesRecord {get; set;}
        public ICollection<Seller> Sellers {get; set;}
    }
}