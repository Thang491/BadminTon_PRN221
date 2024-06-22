using Accessibility;
using BadMintonBookingBusiness;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BadMintonWpfApp.UI.Category
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wCustomer : Window
    {
        private readonly CustomerBusiness _customerBusiness;
        public wCustomer()
        {
            InitializeComponent();
            this._customerBusiness ??= new CustomerBusiness();
            LoadGrdCustomersAsync();
        }

        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this customer?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                if (button != null)
                {
                    // Lấy ID từ CommandParameter
                    Guid customerId = (Guid)button.CommandParameter;
                    // Thực hiện thao tác xóa dựa trên ID
                    var results = await _customerBusiness.DeleteById(customerId);
                    LoadGrdCustomersAsync();
                }
                
            }

           
        }

        private async void grdCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = grdCustomer.SelectedItem;
            if(selectedRow != null)
            {
                var customers = selectedRow as Customer;
                if(customers != null)
                {
                    var customerId = customers.CustomerId;
                    // Thực hiện thao tác xóa dựa trên ID
                    var result = await _customerBusiness.GetById(customerId);
                    if (result != null)
                    {
                        Customer customer = (Customer)result.Data;
                        if (customer != null)
                        {
                            txtCustomerFullName.Text = customer.FullName.ToString();
                            txtCustomerEmail.Text = customer.Email.ToString();
                            txtCustomerPhone.Text = customer.Phone.ToString();
                            txtCustomerAddress.Text = customer.Address1.ToString();
                        }
                    }
                   
                }
            }
          

        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string CusId = txtCustomerId.Text;
            string fullName = txtCustomerFullName.Text;
            string email = txtCustomerEmail.Text;
            string phone = txtCustomerPhone.Text;
            string address = txtCustomerAddress.Text;

            var selectedRow = grdCustomer.SelectedItem;
            if (selectedRow != null)
            {
                var customers = selectedRow as Customer;
                if (customers != null)
                {
                    CusId = customers.CustomerId.ToString();
                }
            }

                    
            if(CusId.Equals(""))
            {
                Customer customer = new Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    FullName = fullName,
                    Email = email,
                    Phone = phone,
                    Address1 = address
                };
                var result = _customerBusiness.Save(customer);
                txtCustomerFullName.Clear();
                txtCustomerEmail.Clear();
                txtCustomerPhone.Clear();
                txtCustomerAddress.Clear();
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadGrdCustomersAsync();
            }
            else
            {
                var result = await _customerBusiness.GetById(Guid.Parse(CusId));
                if (result != null)
                {
                    Customer customer1 = (Customer)result.Data;
                    customer1.FullName = fullName;
                    customer1.Email = email;
                    customer1.Phone = phone;
                    customer1.Address1 = address;
                    var Updateresult = _customerBusiness.Update(customer1);
                    if(Updateresult != null)
                    {
                        txtCustomerFullName.Clear();
                        txtCustomerEmail.Clear();
                        txtCustomerPhone.Clear();
                        txtCustomerAddress.Clear();
                        MessageBox.Show("Customer update successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadGrdCustomersAsync();
                    }
                    
                }
                
                

            }


        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void LoadGrdCustomersAsync()
        {
            var result = await _customerBusiness.GetAll();
            if (result.Status > 0 && result.Data != null)
            {
                grdCustomer.ItemsSource = result.Data as List<Customer>;
            }
            else
            {
                grdCustomer.ItemsSource = new List<Customer>();
            }
        }
    }
}
