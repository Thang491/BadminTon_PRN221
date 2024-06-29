using BadMintonBookingBusiness;
using BadMintonBookingBusiness.Categoryy;
using BadMintonBookingRazorWebApp.Pages.Shared;
using BadMintonData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class CourtSlotModel : PageModel
    {
        private readonly ICourtSlotBusiness _courtSlotBusiness = new CourtSlotBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public CourtSlot CourtSlot { get; set; } = default;
        public Court Court { get; set; }
        public List<CourtSlot> CourtSlots { get; set; } = new List<CourtSlot>();
        [BindProperty]
        public string SearchInput { get; set; }
        public PaginatedList<CourtSlot> courtSlot { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }

        public void OnGet()
        {
            var courtSlots = this.GetCourtSlots();
            int pageSize = 5;
            courtSlot = PaginatedList<CourtSlot>.Create(courtSlots.AsQueryable(), PageIndex, pageSize);
        }
        public async Task<IActionResult> OnPost()
        {
            await this.SaveCourtSlot();
            return RedirectToPage();

        }
        public async Task<IActionResult> OnPostUpdate()
        {

            await this.UpdateCourtSlot(this.CourtSlot);
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            await DeleteCourtSlot(id);
            return RedirectToPage();

        }

        public async Task<IActionResult> UpdateCourtSlot(CourtSlot courtSlot)
        {
            var courtSlotResult = _courtSlotBusiness.Update(courtSlot);
            if (courtSlotResult != null)
            {
                this.Message = courtSlotResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
            return Page();

            //OnGet();
        }
        public IActionResult OnPostSearch()
        {

            if (!string.IsNullOrEmpty(SearchInput))
            {
                var courtSlots = _courtSlotBusiness.SearchCourtSlotByDate(SearchInput);
                CourtSlots = (List<CourtSlot>)courtSlots.Result.Data;
                int pageSize = 5; // Số lượng phần tử trên mỗi trang
                courtSlot = PaginatedList<CourtSlot>.Create(CourtSlots.AsQueryable(), PageIndex, pageSize);

                return Page();
            }
            else
            {
                return RedirectToPage();
            }

        }
        private List<CourtSlot> GetCourtSlots()
        {
            var courtSlotResult = _courtSlotBusiness.GetAll();

            if (courtSlotResult.Status > 0 && courtSlotResult.Result.Data != null)
            {
                var courtSlots = (List<CourtSlot>)courtSlotResult.Result.Data;
                return courtSlots;
            }
            return new List<CourtSlot>();
        }

        private async Task<IActionResult> SaveCourtSlot()
        {
            Guid guid = Guid.NewGuid();
            this.CourtSlot.SlotId = guid;
            this.CourtSlot.CourtId = new Guid("03C1BAC0-111B-4A1D-91F7-F69D0FB530A0");
            var courtSlotResult = _courtSlotBusiness.Save(this.CourtSlot);
            if (courtSlotResult != null)
            {
                this.Message = courtSlotResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
            return Page();

        }
        private async Task<IActionResult> DeleteCourtSlot(Guid id)
        {
            var courtSlotResult = _courtSlotBusiness.DeleteById(id);
            if (courtSlotResult != null)
            {
                this.Message = courtSlotResult.Result.Message;

            }
            else
            {
                this.Message = "Error system";
            }
            return Page();

        }

        public string GetWelcomeMsg()
        {
            return "Welcome Razor Page Web Application";
        }
    }
}
