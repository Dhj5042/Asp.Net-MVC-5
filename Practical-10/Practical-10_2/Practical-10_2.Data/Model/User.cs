using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_10_2.Data.Model
{
    /// <summary>
    /// This is User Model 
    /// this help us to Insert,update ,delete
    /// model,view and controller
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string Date_Of_Brith { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
