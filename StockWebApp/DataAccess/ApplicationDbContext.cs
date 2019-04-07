using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockWebApp.Models;
using static StockWebApp.Models.EF_Models;

namespace StockWebApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyList> Gainers { get; set; }
        public DbSet<NewsData> News { get; set; }
    }
}
