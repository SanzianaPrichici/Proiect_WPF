using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Zboruri
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public IndexModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public IList<Zbor> Zbor { get;set; }

        public async Task OnGetAsync()
        {
            Zbor = await _context.Zbor.ToListAsync();
        }
    }
}
