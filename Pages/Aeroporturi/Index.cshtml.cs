using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Aeroporturi
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public IndexModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public IList<Aeroport> Aeroport { get;set; }

        public async Task OnGetAsync()
        {
            Aeroport = await _context.Aeroport.ToListAsync();
        }
    }
}
