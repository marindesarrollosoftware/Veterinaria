using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinaria.Common.Models
{
    public class UnAssignRequest
    {
        [Required]
        public int AgendaId { get; set; }
    }

}
