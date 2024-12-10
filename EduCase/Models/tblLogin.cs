using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduCase.Models
{
    public class tblLogin
    {
        [Required(ErrorMessage = "Email ID is Required")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Your Email ID is not in a valid format")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}