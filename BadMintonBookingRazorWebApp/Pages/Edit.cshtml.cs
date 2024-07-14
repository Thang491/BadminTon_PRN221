using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadMintonData.Models;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly BadMintonData.Models.NET1702_PRN221_BadMintonContext _context;

        public EditModel(BadMintonData.Models.NET1702_PRN221_BadMintonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Court Court { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Courts == null)
            {
                return NotFound();
            }

            var court =  await _context.Courts.FirstOrDefaultAsync(m => m.CourtId == id);
            if (court == null)
            {
                return NotFound();
            }
            Court = court;
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

            _context.Attach(Court).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourtExists(Court.CourtId))
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

        private bool CourtExists(Guid id)
        {
          return (_context.Courts?.Any(e => e.CourtId == id)).GetValueOrDefault();
        }
    }
}
