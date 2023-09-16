using Microsoft.EntityFrameworkCore;
using ReWrite.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DAL.Context
{
    public class CartContext:DbContext
    {
        public CartContext(DbContextOptions<CartContext> opt):base(opt)
        {

        }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetail> CartDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
