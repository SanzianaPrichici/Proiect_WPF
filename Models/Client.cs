using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proiect_WPF.Models;

namespace Proiect_WPF.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string Nume { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string Prenume { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_nasterii { get; set; }
        public string Email { get; set; }
        [Range(1, 30)]
        public int nr_zboruri { get; set; }
        public ICollection<Bilet> Bilet { get; set; }
    }
}
