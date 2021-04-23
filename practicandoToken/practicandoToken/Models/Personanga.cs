using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practicandoToken.Models
{
    public class Personanga
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CortejaCount { get; set; }
    }
}