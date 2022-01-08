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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public DetailsModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public Zbor Zbor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zbor = await _context.Zbor.FirstOrDefaultAsync(m => m.ID == id);

            if (Zbor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
