using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Kolokwium2.DTO
{
    public class Request
    {
        [Required]
        public int IdPlayer { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Numonshirt { get; set; }
        public string Comment { get; set; }
    }
}
