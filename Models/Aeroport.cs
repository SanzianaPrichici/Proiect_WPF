using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WPF.Models
{
    public class Aeroport
    {
        public string ID { get; set; }
        public string Nume { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }
        public ICollection<Zbor> Zboruri { get; set; }
    }
}
