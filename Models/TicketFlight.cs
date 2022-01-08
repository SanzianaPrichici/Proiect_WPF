using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WPF.Models
{
    public class TicketFlight
    {
        public int ID { get; set; }
        public int BiletID { get; set; }
        public Bilet Bilet { get; set; }
        public int ZborID { get; set; }
        public Zbor Zbor { get; set; }
    }
}
