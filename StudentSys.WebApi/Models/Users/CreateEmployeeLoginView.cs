using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSys.WebApi.Models.Users
{
    public class CreateEmployeeLoginView
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string PassWord { get; set; }

        public string Phone { get; set; }

        public Guid TypeId { get; set; }
    }
}