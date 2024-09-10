using Data_Access_Layer.Data.Configrutions;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Without using the Dependency Injection 
        //public ApplicationDbContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server = .; Database = MVCApplication; Trusted_Connection = True; MultipleActiveResultSets = True");

        // using the Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options):base(Options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrutions());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Department> Departments { get; set; }
    }
}
