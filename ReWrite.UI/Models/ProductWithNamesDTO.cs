using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.UI.Models
{
    public class ProductWithNamesDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public string CompanyName { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public short? UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
