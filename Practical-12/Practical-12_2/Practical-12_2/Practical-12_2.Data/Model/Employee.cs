using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_12_2.Data.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Middle_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }

        [Required]
        [Display(Name = "Data of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(10)]
        public string Mobile_Number { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public Designation Designation { get; set; }
        [Required]
        public int DesignationId { get; set; }

    }
}
