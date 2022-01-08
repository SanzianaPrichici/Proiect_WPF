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
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_nasterii { get; set; }
        public string Email { get; set; }
        public int nr_zboruri { get; set; }
        public ICollection<Bilet> Bilet { get; set; }
    }
}
