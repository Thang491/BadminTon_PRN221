using BadMintonBookingBusiness;
using BadMintonBookingBusiness.Categoryy;
using BadMintonBookingRazorWebApp.Pages.Shared;
using BadMintonData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness = new CustomerBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Customer Customer { get; set; } = default;
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<SelectListItem> GenderOptions { get; set; }
        [BindProperty]
        public string SearchInput { get; set; }
        public PaginatedList<Customer> customer { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }

        public void OnGet()
        {
            GenderOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "true" },
                new SelectListItem { Text = "Female", Value = "false" }
            };
            var customers = this.GetCustomer();
            int pageSize = 5;
            customer = PaginatedList<Customer>.Create(customers.AsQueryable(), PageIndex, pageSize);
        }
        public string GetGenderText(bool gender)
        {
            return gender ? "Male" : "Female";
        }
        public async Task<IActionResult> OnPost()
        {
            await this.SaveCustomer();
            return RedirectToPage();

        }
        public async Task<IActionResult> OnPostUpdate()
        {

            await this.UpdateCustomer(this.Customer);
                                                     
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            await DeleteCustomer(id);
            return RedirectToPage();

        }

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var customerResult = _customerBusiness.Update(customer);
            if (customerResult != null)
            {
                this.Message = customerResult.Result.Message;
                

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
                var customer1 = _customerBusiness.SearchCustomerByName(SearchInput);
                Customers = (List<Customer>)customer1.Result.Data;
                int pageSize = 5; // Số lượng phần tử trên mỗi trang
                customer = PaginatedList<Customer>.Create(Customers.AsQueryable(), PageIndex, pageSize);

                return Page();
            }
            else
            {
                return RedirectToPage();
            }

        }
        private List<Customer> GetCustomer()
        {
            var customerResult = _customerBusiness.GetAll();
            if (customerResult.Status > 0 && customerResult.Result.Data != null)
            {
                var customer = (List<Customer>)customerResult.Result.Data;
                return customer;
            }
            return new List<Customer>();
        }

        private async Task<IActionResult> SaveCustomer()
        {
            Guid guid = Guid.NewGuid();
            this.Customer.CustomerId = guid;
            var customerResult = _customerBusiness.Save(this.Customer);
            if (customerResult != null)
            {
                this.Message = customerResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
            return Page();

        }
        private async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customerResult = _customerBusiness.DeleteById(id);
            if (customerResult != null)
            {
                this.Message = customerResult.Result.Message;

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
