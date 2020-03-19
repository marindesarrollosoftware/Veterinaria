using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Owner")]
        public string FullNamewithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
