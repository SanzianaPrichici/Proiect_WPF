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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public DetailsModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public Bilet Bilet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bilet = await _context.Bilet
                .Include(b => b.Client).FirstOrDefaultAsync(m => m.ID == id);

            if (Bilet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
