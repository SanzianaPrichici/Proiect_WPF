using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_WPF.Data;

namespace Proiect_WPF.Models
{
    public class BileteZborPageModel : PageModel
    {
        public List<AssignedZborData> AssignedZborDataList;
        public void PopulateAssignedZborData(Proiect_WPFContext context, Bilet bilet)
        {
            var allFlys = context.Zbor;
            var biletFlys = new HashSet<int>(
            bilet.TicketFlights.Select(c => c.ZborID));
            AssignedZborDataList = new List<AssignedZborData>();
            foreach (var cat in allFlys)
            {
                AssignedZborDataList.Add(new AssignedZborData
                {
                    ZborID = cat.ID,
                    Plecare = cat.PlecareID,
                    Data = cat.Data,
                    pret=cat.pret,
                    Durata=cat.Durata,
                    Assigned = biletFlys.Contains(cat.ID)
                }) ;
            }
        }
        public void UpdateBiletFlight(Proiect_WPFContext context, string[] selectedFlights, Bilet bookToUpdate)
        {
            if (selectedFlights == null)
            {
                bookToUpdate.TicketFlights = new List<TicketFlight>();
                return;
            }
            var selectedFlightsHS = new HashSet<string>(selectedFlights);
            var biletFlights = new HashSet<int>
            (bookToUpdate.TicketFlights.Select(c => c.Zbor.ID));
            foreach (var cat in context.Zbor)
            {
                if (selectedFlightsHS.Contains(cat.ID.ToString()))
                {
                    if (!biletFlights.Contains(cat.ID))
                    {
                        bookToUpdate.TicketFlights.Add(
                        new TicketFlight
                        {
                            BiletID = bookToUpdate.ID,
                            ZborID = cat.ID
                        });
                    }
                }
                else
                {
                    if (biletFlights.Contains(cat.ID))
                    {
                        TicketFlight courseToRemove
                        = bookToUpdate
                        .TicketFlights
                        .SingleOrDefault(i => i.ZborID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
        }
}
