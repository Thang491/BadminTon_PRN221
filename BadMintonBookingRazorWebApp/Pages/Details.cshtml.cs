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
    public class DetailsModel : PageModel
    {
        private readonly BadMintonData.Models.NET1702_PRN221_BadMintonContext _context;

        public DetailsModel(BadMintonData.Models.NET1702_PRN221_BadMintonContext context)
        {
            _context = context;
        }

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
    }
}
