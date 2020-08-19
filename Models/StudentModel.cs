using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearnerMVC.Models
{
    public class StudentModel
    {
        [Display(Name = "Student ID")]
        [EditableAttribute(allowEdit: false)]
        public int Student_IDX { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter First Name!")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter Surname!")]
        public string LastName { get; set; }

        [Range(18, 60, ErrorMessage = "Please Enter a Valid Age!")]
        public int Age { get; set; } = 0;

        public bool IsAlive { get; set; } = true;
    }
}