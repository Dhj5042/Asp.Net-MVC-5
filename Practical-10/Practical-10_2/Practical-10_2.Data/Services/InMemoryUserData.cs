using Practical_10_2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_10_2.Data.Services
{
    /// <summary>
    /// here inherented interface
    /// all method are override 
    /// </summary>
    public class InMemoryUserData : IUserData
    {
        List<User> Users;
        /// <summary>
        /// InMemoryUserData has Constructor to assign some predefined values values of lists
        /// </summary>
        public InMemoryUserData()
        {
            Users = new List<User>()
            {
                    new User{Id=1,Name="Dhruvin Jariwala",Date_Of_Brith="23/05/2000",Address="9/622, Wadifaliya Surat"},
                    new User{Id=2,Name="Divyesh Jariwala",Date_Of_Brith="26/06/2000",Address="B-23,Vijay Nagar Socity,Surat"},
                    new User{Id=3,Name="Pratik Jariwala",Date_Of_Brith="26/01/1999",Address="A-34,Udhna Darwaja Road,Surat"},
            };
        }
        //add data to list
        public void create(User user)
        {
            Users.Add(user);
            user.Id = Users.Max(r => r.Id) + 1;
        }
        //delete data into a list
        public void Delete(int id)
        {
            //fetch particular user data
            var res = Get(id);
            if (res != null)
            {
                //finally remove
                Users.Remove(res);
            }
        }
        //get particular user data
        public User Get(int id)
        {
            return Users.FirstOrDefault(r => r.Id == id);
        }
        //update particular user data
        public void update(User user)
        {
            var existing = Get(user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Date_Of_Brith = user.Date_Of_Brith;
                existing.Address = user.Address;

            }
        }
        //get list of all data
        public IEnumerable<User> ViewAll()
        {
            return Users.OrderBy(r => r.Id);
        }
    }
}
