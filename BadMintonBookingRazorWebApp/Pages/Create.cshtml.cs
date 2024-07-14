using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadMintonData.Models;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BadMintonData.Models.NET1702_PRN221_BadMintonContext _context;

        public CreateModel(BadMintonData.Models.NET1702_PRN221_BadMintonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Court Court { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Courts == null || Court == null)
            {
                return Page();
            }

            _context.Courts.Add(Court);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
