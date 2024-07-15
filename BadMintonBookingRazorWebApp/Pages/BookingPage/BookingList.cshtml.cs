using BadMintonBookingRazorWebApp.Pages.Shared;
using BadMintonData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BadMintonBookingRazorWebApp.Pages
{
    [Authorize]
    public class BookingModel : PageModel
    {
        private readonly NET1702_PRN221_BadMintonContext _context;

        public Booking Booking { get; set; } = default;
        public List<Booking> Bookings { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Court> Courts { get; set; }
        public List<CourtSlot> Slots { get; set; }

        public PaginatedList<Booking> bookingPaging { get; set; }
        public BookingModel(NET1702_PRN221_BadMintonContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
            Bookings = _context.Bookings
              .Include(b => b.Customer)
              .Include(b => b.Court)
              .Include(b => b.Slot)
              .ToList();

            ViewData["Customers"] = _context.Customers.ToList();
            ViewData["Courts"] = _context.Courts.ToList();
            ViewData["Slots"] = _context.CourtSlots.ToList();
        }

        public IActionResult OnPostSearch(string searchInput)
        {
            // Xử lý logic tìm kiếm booking dựa vào searchInput ở đây
            // Ví dụ:
            var filteredBookings = _context.Bookings.Include(b => b.Customer)
              .Include(b => b.Court)
              .Include(b => b.Slot)
                .Where(b =>
                b.BookingId.ToString().Contains(searchInput) ||
                b.Customer.FullName.Contains(searchInput) ||
                b.PaymentType.Contains(searchInput) ||
                b.Description.Contains(searchInput) ||
                b.Status.Contains(searchInput) ||
                b.Code.Contains(searchInput) ||
                b.Address.Contains(searchInput) ||
                b.Phone.Contains(searchInput) ||
                b.BookingDate.ToString().Contains(searchInput) ||  // Convert BookingDate sang string để tìm kiếm
                b.TotalPrice.ToString().Contains(searchInput) ||   // Convert TotalPrice sang string để tìm kiếm
                b.PaymentStatus.ToString().Contains(searchInput) || // Convert PaymentStatus sang string để tìm kiếm
                b.CourtId.ToString().Contains(searchInput) || // Convert CourtId sang string để tìm kiếm
                b.SlotId.ToString().Contains(searchInput) // Convert SlotId sang string để tìm kiếm
            )// Ví dụ tìm kiếm theo tên khách hàng
                .ToList();

            // Đưa danh sách filteredBookings vào ViewData hoặc Model để hiển thị lại trang

            Bookings = filteredBookings;

            ViewData["Customers"] = _context.Customers.ToList();
            ViewData["Courts"] = _context.Courts.ToList();
            ViewData["Slots"] = _context.CourtSlots.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            // Xóa các BookingDetail liên quan
            var bookingDetails = await _context.BookingDetails.Where(bd => bd.BookingId == id).ToListAsync();
            _context.BookingDetails.RemoveRange(bookingDetails);

            // Tiếp tục xóa Booking
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("/BookingPage/BookingList"); // Sử dụng đường dẫn tuyệt đối

        }

        public IActionResult OnPostUpdateBooking()
        {
            if (!ModelState.IsValid)
            {
                // Xử lý khi ModelState không hợp lệ
                return Page();
            }

            // Lấy bookingId từ form
            var bookingId = Guid.Parse(Request.Form["BookingId"]);

            // Tìm booking cần cập nhật trong database
            var bookingToUpdate = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (bookingToUpdate == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của booking từ form
            bookingToUpdate.CustomerId = Guid.Parse(Request.Form["CustomerId"]);
            bookingToUpdate.CourtId = Guid.Parse(Request.Form["CourtId"]);
            bookingToUpdate.SlotId = Guid.Parse(Request.Form["SlotId"]);
            bookingToUpdate.PaymentType = Request.Form["PaymentType"];
            bookingToUpdate.BookingDate = DateTime.Parse(Request.Form["BookingDate"]);
            var checkPaymentStatus = Request.Form["PaymentStatus"];
            if (checkPaymentStatus == "true") {
                bookingToUpdate.PaymentStatus = true;
            } else {
                bookingToUpdate.PaymentStatus = false;
            }
            bookingToUpdate.TotalPrice = double.Parse(Request.Form["TotalPrice"]);
            bookingToUpdate.Address = Request.Form["Address"];
            bookingToUpdate.Description = Request.Form["Description"];
            bookingToUpdate.Phone = Request.Form["Phone"];
            bookingToUpdate.Code = Request.Form["Code"];
            bookingToUpdate.Status = Request.Form["Status"];

            // Lưu thay đổi vào database
            _context.SaveChanges();

            var updateBookingDetail = _context.BookingDetails.FirstOrDefault(b => b.BookingId == bookingId);
            updateBookingDetail.CourtId = Request.Form["CourtId"];
            updateBookingDetail.CustomerId = Request.Form["CustomerId"];
            updateBookingDetail.SlotId = Guid.Parse(Request.Form["SlotId"]);
            _context.SaveChanges();

            return RedirectToPage("/BookingPage/BookingList");
        }

        public IActionResult OnPostAddBooking()
        {
            Booking newBooking = new Booking();

            // Cập nhật các thuộc tính của booking từ form
            newBooking.BookingId = Guid.NewGuid();
            newBooking.CustomerId = Guid.Parse(Request.Form["AddCustomerId"]);
            newBooking.CourtId = Guid.Parse(Request.Form["AddCourtId"]);
            newBooking.SlotId = Guid.Parse(Request.Form["AddSlotId"]);
            newBooking.PaymentType = Request.Form["AddPaymentType"];
            newBooking.BookingDate = DateTime.Parse(Request.Form["AddBookingDate"]);
            var checkPaymentStatus = Request.Form["AddPaymentStatus"];
            if (checkPaymentStatus == "true")
            {
                newBooking.PaymentStatus = true;
            }
            else
            {
                newBooking.PaymentStatus = false;
            } // Hoặc sử dụng bool.Parse() tùy vào giá trị của checkbox
            newBooking.TotalPrice = double.Parse(Request.Form["AddTotalPrice"]);
            newBooking.Address = Request.Form["AddAddress"];
            newBooking.Description = Request.Form["AddDescription"];
            newBooking.Phone = Request.Form["AddPhone"];
            newBooking.Code = Request.Form["AddCode"];
            newBooking.Status = Request.Form["AddStatus"];

            // Lưu thay đổi vào database
            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            BookingDetail bookingDetail = new BookingDetail();
            bookingDetail.BookingDetailId = Guid.NewGuid();
            bookingDetail.BookingId = newBooking.BookingId;
            var customerIdConvert = newBooking.CustomerId.ToString();
            bookingDetail.CustomerId = customerIdConvert;
            var courtIdConvert = newBooking.CourtId.ToString();
            bookingDetail.CourtId = courtIdConvert;
            bookingDetail.SlotId = newBooking.SlotId;

            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();

            return RedirectToPage("/BookingPage/BookingList");
        }
    }
}
