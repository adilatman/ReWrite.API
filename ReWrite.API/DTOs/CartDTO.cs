using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DTOs
{
    public class CartDTO
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
