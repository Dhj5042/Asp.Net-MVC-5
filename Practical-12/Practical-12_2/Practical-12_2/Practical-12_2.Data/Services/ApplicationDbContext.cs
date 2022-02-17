using Practical_12_2.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12_2.Data.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base("DbEMPDBContext")
        {
            
        }

        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
