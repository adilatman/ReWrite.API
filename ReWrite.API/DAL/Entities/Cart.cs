using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DAL.Entities
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
