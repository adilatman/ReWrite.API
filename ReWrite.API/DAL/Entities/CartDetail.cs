using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DAL.Entities
{
    public class CartDetail
    {
        [Key]
        public int CartDetailID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
