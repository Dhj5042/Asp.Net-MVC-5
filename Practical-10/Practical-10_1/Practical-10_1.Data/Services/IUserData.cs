using Practical_10_1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_10_1.Data.Services
{
    /// <summary>
    /// Interface has all method defined
    /// </summary>
    public interface IUserData
    {
        IEnumerable<User> ViewAll();
        User Get(int id);

        void create(User user);
        void update(User user);
        void Delete(int id);
    }
}
