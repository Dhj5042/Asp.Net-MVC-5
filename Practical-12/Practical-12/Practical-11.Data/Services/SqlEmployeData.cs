using Practical_11.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_11.Data.Services
{
    public class SqlEmployeData : IEmpoyeeData
    {
        private readonly ApplicationDbContext db;
        public SqlEmployeData(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var res = db.Employees.Find(id);
            db.Employees.Remove(res);
            db.SaveChanges();
        }

        public employee Get(int id)
        {
            return db.Employees.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<employee> GetAll()
        {
            return from r in db.Employees
                   orderby r.Name
                   select r;
        }

        public void Update(employee employee)
        {
            var r = db.Entry(employee);
            r.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
