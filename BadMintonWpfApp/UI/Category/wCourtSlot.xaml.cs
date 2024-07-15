using BadMintonBookingBusiness;
using BadMintonBookingBusiness.Categoryy;
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
    /// Interaction logic for wCourtSlot.xaml
    /// </summary>
    public partial class wCourtSlot : Window
    {
        private readonly CourtSlotBusiness _courtSlotBusiness;
        private readonly CourtBusiness _courtBusiness;
        public wCourtSlot()
        {
            InitializeComponent();
            _courtSlotBusiness = new CourtSlotBusiness();
            _courtBusiness = new CourtBusiness();
            LoadgrdCourtSlotsAsync();
            LoadComboBox();
        }

        private async void LoadComboBox()
        {
            var courts = await _courtBusiness.GetAll();
            var list = courts.Data as List<Court>;
            for (int i = 0; i < list.Count; i++)
            {
                txtCourtId.Items.Add(list[i]);
            }
            txtCourtId.DisplayMemberPath = "CourtName";
            txtCourtId.SelectedValuePath = "CourtId";
        }

        private async void grdCourtSlots_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this slot?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                if (button != null)
                {
                    // Lấy ID từ CommandParameter
                    Guid courtSlotId = (Guid)button.CommandParameter;
                    // Thực hiện thao tác xóa dựa trên ID
                    var results = await _courtSlotBusiness.DeleteById(courtSlotId);
                    LoadgrdCourtSlotsAsync();
                }
            }
        }

        private async void grdCourtSlots_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = grdCourtSlots.SelectedItem;
            if (selectedRow != null)
            {
                var courtSlots = selectedRow as CourtSlot;
                if (courtSlots != null)
                {
                    var slotId = courtSlots.SlotId;
                    var result = await _courtSlotBusiness.GetById(slotId);
                    if (result != null)
                    {
                        CourtSlot courtSlot = (CourtSlot)result.Data;
                        if (courtSlot != null)
                        {
                            txtSlotsId.Text = courtSlot.SlotId.ToString();
                            txtCourtId.Text = courtSlot.CourtId.ToString();
                            txtCourtSlotsStartTime.Text = courtSlot.SlotStartTime.ToString();
                            txtCourtSlotsEndTime.Text = courtSlot.SlotEndTime.ToString();
                            txtCourtsSlotPrice.Text = courtSlot.SlotPrice.ToString();
                            txtCourtSlotsStatus.Text = courtSlot.Status.ToString();
                        }
                    }

                }
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string slotId = txtSlotsId.Text;
            string courtId = txtCourtId.SelectedValue.ToString();
            string startTime = txtCourtSlotsStartTime.Text;
            string endTime = txtCourtSlotsEndTime.Text;
            string status = txtCourtSlotsStatus.Text;
            string slotPrice = txtCourtsSlotPrice.Text;

            var selectedRow = grdCourtSlots.SelectedItem;
            if (selectedRow != null)
            {
                var courtSlots = selectedRow as CourtSlot;
                if (courtSlots != null)
                {
                    slotId = courtSlots.SlotId.ToString();
                }
            }
            if (slotId.Equals(""))
            {
                CourtSlot courtSlot = new CourtSlot()
                {
                    SlotId = Guid.NewGuid(),
                    CourtId = Guid.Parse(courtId),
                    SlotStartTime = DateTime.Parse(startTime),
                    SlotEndTime = DateTime.Parse(endTime),
                    SlotPrice = slotPrice,
                    Status = bool.Parse(status),
                };
                var result = _courtSlotBusiness.Save(courtSlot);
                txtCourtSlotsStartTime.Clear();
                txtCourtSlotsEndTime.Clear();
                txtCourtSlotsStatus.Clear();
                txtCourtsSlotPrice.Clear();
                MessageBox.Show("Slot added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadgrdCourtSlotsAsync();
            }
            else
            {
                var result = await _courtSlotBusiness.GetById(Guid.Parse(slotId));
                if (result != null)
                {
                    CourtSlot courtSlot = (CourtSlot)result.Data;
                    courtSlot.SlotStartTime = DateTime.Parse("startTime");
                    courtSlot.SlotEndTime = DateTime.Parse("endTime");
                    courtSlot.SlotPrice = slotPrice;
                    var Updateresult = _courtSlotBusiness.Update(courtSlot);
                    if (Updateresult != null)
                    {
                        txtCourtSlotsStartTime.Clear();
                        txtCourtSlotsEndTime.Clear();
                        txtCourtSlotsStatus.Clear();
                        txtCourtsSlotPrice.Clear();
                        MessageBox.Show("Slot update successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadgrdCourtSlotsAsync();
                    }
                }
            }
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void LoadgrdCourtSlotsAsync()
        {
            var result = await _courtSlotBusiness.GetAll();
            if (result.Status > 0 && result.Data != null)
            {
                grdCourtSlots.ItemsSource = result.Data as List<CourtSlot>;
            }
            else
            {
                grdCourtSlots.ItemsSource = new List<CourtSlot>();
            }
        }
    }
}
