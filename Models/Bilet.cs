using Proiect_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WPF.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public ICollection<TicketFlight> TicketFlights { get; set; }
    }
}
