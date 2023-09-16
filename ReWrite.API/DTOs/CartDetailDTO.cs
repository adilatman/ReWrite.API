using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DTOs
{
    public class CartDetailDTO
    {
        public int CartDetailID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
    }
}
