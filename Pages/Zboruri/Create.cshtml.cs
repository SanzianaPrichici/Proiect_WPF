using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Zboruri
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public CreateModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
