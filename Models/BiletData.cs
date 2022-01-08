using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WPF.Models
{
    public class BiletData
    {
        public IEnumerable<Bilet> Bilete { get; set; }
        public IEnumerable<Zbor> Zboruri { get; set; }
        public IEnumerable<TicketFlight> TicketFlights { get; set; }
    }
}
