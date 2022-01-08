using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_WPF.Models
{
    public class Zbor
    {
        public int ID { get; set; }
        public string PlecareID { get; set; }
        public Aeroport Aeroport { get; set; }
        public DateTime Data { get; set; }
        [Range(1, 10)]
        public int Durata { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(1, 30000)]
        public decimal pret { get; set; }
        public ICollection<TicketFlight> TicketFlights { get; set; }
    }
}
