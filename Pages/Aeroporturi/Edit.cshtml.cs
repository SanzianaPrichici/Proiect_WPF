using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Aeroporturi
{
    public class EditModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public EditModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aeroport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportExists(Aeroport.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AeroportExists(string id)
        {
            return _context.Aeroport.Any(e => e.ID == id);
        }
    }
}
