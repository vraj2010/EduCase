using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduCase.Models
{
    public class tblStandard
    {
        [Display(Name = "Standard ID")]
        public int s_standardid { get; set; }
        [Display(Name = "Standard Name")]
        public string s_standardname { get; set; }
    }
}