using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadMintonData.Models;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly BadMintonData.Models.NET1702_PRN221_BadMintonContext _context;

        public DeleteModel(BadMintonData.Models.NET1702_PRN221_BadMintonContext context)
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

            var court = await _context.Courts.FirstOrDefaultAsync(m => m.CourtId == id);

            if (court == null)
            {
                return NotFound();
            }
            else 
            {
                Court = court;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Courts == null)
            {
                return NotFound();
            }
            var court = await _context.Courts.FindAsync(id);

            if (court != null)
            {
                Court = court;
                _context.Courts.Remove(Court);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
