using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_WPF.Data;
using Proiect_WPF.Models;

namespace Proiect_WPF.Pages.Bilete
{
    public class CreateModel : BileteZborPageModel
    {
        private readonly Proiect_WPF.Data.Proiect_WPFContext _context;

        public CreateModel(Proiect_WPF.Data.Proiect_WPFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "Nume");

            var bilet = new Bilet();
            bilet.TicketFlights = new List<TicketFlight>();
            PopulateAssignedZborData(_context, bilet);

            return Page();
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Bilet.Add(Bilet);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
        //public async Task<IActionResult> OnPostAsync(string[] selectedFlights)
        //{
        //    var newBook = new Bilet();
        //    if (selectedFlights != null)
        //    {
        //        newBook.TicketFlights = new List<TicketFlight>();
        //        foreach (var cat in selectedFlights)
        //        {
        //            var catToAdd = new TicketFlight
        //            {
        //                ZborID = int.Parse(cat)
        //            };
        //            newBook.TicketFlights.Add(catToAdd);
        //        }
        //    }
        //    if (await TryUpdateModelAsync<Bilet>(newBook,
        //    "Book",
        //    i => i.Title, i => i.Author,
        //    i => i.Price, i => i.PublishingDate, i => i.PublisherID))
        //    {
        //        _context.Book.Add(newBook);
        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }
        //    PopulateAssignedCategoryData(_context, newBook);
        //}
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedFlights)
        {
            var newBilet = new Bilet();
            if (selectedFlights != null)
            {
                newBilet.TicketFlights = new List<TicketFlight>();
                foreach (var cat in selectedFlights)
                {
                    var catToAdd = new TicketFlight
                    {
                        ZborID = int.Parse(cat)
                    };
                    newBilet.TicketFlights.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Bilet>(
            newBilet,
            "Bilet",
            i => i.ClientID))
            {
                _context.Bilet.Add(newBilet);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedZborData(_context, newBilet);
            return Page();
        }
    }
}
