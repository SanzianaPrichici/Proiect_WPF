using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_WPF.Models
{
    public class AssignedZborData
    {
        public int ZborID { get; set; }
        public string Plecare { get; set; }
        public DateTime Data { get; set; }
        public decimal pret { get; set; }
        public bool Assigned { get; set; }
    }
}
