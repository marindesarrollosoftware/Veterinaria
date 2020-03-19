using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Web.Data.Entities
{
    public class ServiceType
    {
        private const string V = "The field {0} is mandatory.";

        public int Id { get; set; }

        [Display(Name = "Service Type")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = V)]
        public string Name { get; set; }

        public ICollection<History> Histories { get; set; }

    }
}
