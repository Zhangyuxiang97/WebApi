using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSys.WebApi.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(40,MinimumLength =5)]
        [EmailAddress]
        public string LoginName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        public string Password { get; set; }
    }
}