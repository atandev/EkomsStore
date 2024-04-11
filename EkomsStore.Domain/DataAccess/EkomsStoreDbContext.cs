using EkomsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Domain.DataAccess
{
    public class EkomsStoreDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public EkomsStoreDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString(""));
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSecurity> UserSecurity { get; set; }
    }
}
