using Practical_11.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_11.Data.Services
{
    public interface IEmpoyeeData
    {
        IEnumerable<employee> GetAll();
        employee Get(int id);

        void Add(employee employee);
        void Update(employee employee);
        void Delete(int id);
    }
}
