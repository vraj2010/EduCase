using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduCase.Models
{
    //public class StudentPagingViewModel
    //{
    //    public List<tblStudent> Students { get; set; }
    //    public int CurrentPage { get; set; }
    //    public int TotalPages { get; set; }
    //}
    public class tblStudent
    {
        [Display(Name = "ID")]
        public int s_id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string s_name { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime s_dob { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender field can't be blank")]
        public string s_gender { get; set; }

        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobile No. field can't be blank.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid")]
        public string s_mob { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID is Required")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", 
            ErrorMessage = "Your Email ID is not in a valid format")]
        public string s_email { get; set; }

        [Display(Name = "Cricket")]
        public bool s_cricket { get; set; }

        [Display(Name = "Volleyball")]
        public bool s_volleyball { get; set; }

        [Display(Name = "Gaming")]
        public bool s_gaming { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        [RegularExpression("^[a-z A-Z 0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string s_address { get; set; }

        [Display(Name = "Standard ID")]
        [Required(ErrorMessage = "Standard ID Field can't be blank")]
        public int s_standardid { get; set; }

    }
}