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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public DetailsModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public Aeroport Aeroport { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aeroport = await _context.Aeroport.FirstOrDefaultAsync(m => m.ID == id);

            if (Aeroport == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
