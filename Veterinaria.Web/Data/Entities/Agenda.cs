using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Web.Data.Entities
{
    public class Agenda
    {
        private const string V = "The field {0} is mandatory.";

        public int Id { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = V)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        public string Remarks { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        public Owner Owner { get; set; }
        public Pet Pet { get; set; }

    }
}
