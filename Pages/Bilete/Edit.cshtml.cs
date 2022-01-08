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
namespace Proiect_WPF.Pages.Bilete
{
    public class EditModel : BileteZborPageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public EditModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bilet = await _context.Bilet
                .Include(c => c.Client)
                .Include(b => b.TicketFlights).ThenInclude(b => b.Zbor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Bilet == null)
            {
                return NotFound();
            }

            PopulateAssignedZborData(_context, Bilet);

            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "Nume");
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedFlights)
        {
            if (id == null)
            {
                return NotFound();
            }
            var biletToUpdate = await _context.Bilet
            .Include(i => i.Client)
            .Include(i => i.TicketFlights)
            .ThenInclude(i => i.Zbor)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (biletToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Bilet>(
            biletToUpdate,
            "Bilet",
            i => i.Client))
            {
                UpdateBiletFlight(_context, selectedFlights, biletToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateBiletFlight(_context, selectedFlights, biletToUpdate);
            PopulateAssignedZborData(_context, biletToUpdate);
            return Page();
        }

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.ID == id);
        }
    }
}
