using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
