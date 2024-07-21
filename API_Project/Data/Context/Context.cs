using API_Project.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Data.Context
{
    public class Context:DbContext
    {

       public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ApiTest;User ID=sa;pwd=Q1w2e3r4;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
