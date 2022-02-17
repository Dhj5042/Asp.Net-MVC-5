using Practical_11.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_11.Data.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("EmployeeDBContext")
        {

        }

        public DbSet<employee> Employees { get; set; }
    }
}
