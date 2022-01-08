using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Bilete
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public IndexModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public IList<Bilet> Bilet { get;set; }
        public BiletData BiletD { get; set; }
        public int BiletID { get; set; }
        public int ZborID { get; set; }

        //public async Task OnGetAsync()
        //{
        //    Bilet = await _context.Bilet
        //        .Include(b => b.Client).ToListAsync();
        //}
        public async Task OnGetAsync(int? id, int? zborID)
        {
            BiletD = new BiletData();
            BiletD.Bilete = await _context.Bilet
            .Include(b => b.Client)
            .Include(b => b.TicketFlights)
            .ThenInclude(b => b.Zbor)
            .AsNoTracking()
            .OrderBy(b => b.ID)
            .ToListAsync();
            if (id != null)
            {
                BiletID = id.Value;
                Bilet bilet = BiletD.Bilete
                .Where(i => i.ID == id.Value).Single();
                BiletD.Zboruri = bilet.TicketFlights.Select(s => s.Zbor);
            }
        }
    }
}
