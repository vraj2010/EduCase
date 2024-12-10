using EduCase.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCase.Models
{
    public class tblUser
    {
        [Display(Name = "User Id")]
        public int t_userid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username can't be blank!")]
        public string t_username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email ID is Required")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Your Email ID is not in a valid format")]
        public string t_email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password can't be blank!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
            ErrorMessage = "Your password must be at least 8 characters long and include at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character.")]
        [DataType(DataType.Password)]
        public string t_password { get; set; }
    }
}