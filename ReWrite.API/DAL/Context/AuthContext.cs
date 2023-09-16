using Microsoft.EntityFrameworkCore;
using ReWrite.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.DAL.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> opt) : base(opt)
        {

        }
        public DbSet<User> User {get; set;}
    }
}
