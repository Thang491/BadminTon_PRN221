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
    public class IndexModel : PageModel
    {
        private readonly BadMintonData.Models.NET1702_PRN221_BadMintonContext _context;

        public IndexModel(BadMintonData.Models.NET1702_PRN221_BadMintonContext context)
        {
            _context = context;
        }

        public IList<Court> Court { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courts != null)
            {
                Court = await _context.Courts.ToListAsync();
            }
        }
    }
}
