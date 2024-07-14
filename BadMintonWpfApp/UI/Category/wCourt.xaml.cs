using BadMintonBookingBusiness;
using BadMintonData.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadMintonWpfApp.UI.Category
{
    /// <summary>
    /// Interaction logic for wCourt.xaml
    /// </summary>
    public partial class wCourt : Window
    {
        private readonly CourtBusiness _courtBusiness;

        public wCourt()
        {
            InitializeComponent();
            _courtBusiness = new CourtBusiness();
            LoadGrdCourtsAsync();
        }

        private async void grdCourt_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this court?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button button = sender as Button;
                if (button != null)
                {
                    // Get ID from CommandParameter
                    Guid courtId = (Guid)button.CommandParameter;
                    // Perform delete operation based on ID
                    var results = await _courtBusiness.DeleteById(courtId);
                    LoadGrdCourtsAsync();
                }
            }
        }

        private async void grdCourt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = grdCourt.SelectedItem;
            if (selectedRow != null)
            {
                var court = selectedRow as Court;
                if (court != null)
                {
                    var courtId = court.CourtId;
                    // Perform update operation based on ID
                    var result = await _courtBusiness.GetById(courtId);
                    if (result != null)
                    {
                        Court selectedCourt = (Court)result.Data;
                        if (selectedCourt != null)
                        {
                            txtCourtName.Text = selectedCourt.CourtName;
                            txtCourtLocation.Text = selectedCourt.Location;
                            chkIsActive.IsChecked = selectedCourt.IsActive;
                            txtCourtStatus.Text = selectedCourt.Status;
                            txtCourtDescrip.Text = selectedCourt.Descrip;
                            txtCourtOwnerName.Text = selectedCourt.OwnerName;
                            txtCourtSeats.Text = selectedCourt.Seats;
                            txtCourtBadmintonNet.Text = selectedCourt.BadmintonNet;
                            txtCourtArea.Text = selectedCourt.Area;
                        }
                    }
                }
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string courtId = txtCourtId.Text;
            string courtName = txtCourtName.Text;
            string location = txtCourtLocation.Text;
            bool isActive = chkIsActive.IsChecked ?? false;
            string status = txtCourtStatus.Text;
            string descrip = txtCourtDescrip.Text;
            string ownerName = txtCourtOwnerName.Text;
            string seats = txtCourtSeats.Text;
            string badmintonNet = txtCourtBadmintonNet.Text;
            string area = txtCourtArea.Text;

            // Check if new or existing court
            var selectedRow = grdCourt.SelectedItem;
            if (selectedRow != null)
            {
                var court = selectedRow as Court;
                if (court != null)
                {
                    courtId = court.CourtId.ToString();
                }
            }

            if (courtId.Equals(""))
            {
                Court newCourt = new Court()
                {
                    CourtId = Guid.NewGuid(),
                    CourtName = courtName,
                    Location = location,
                    IsActive = isActive,
                    Status = status,
                    Descrip = descrip,
                    OwnerName = ownerName,
                    Seats = seats,
                    BadmintonNet = badmintonNet,
                    Area = area
                };
                var result = _courtBusiness.Save(newCourt);
                ClearFields();
                MessageBox.Show("Court added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadGrdCourtsAsync();
            }
            else
            {
                var result = await _courtBusiness.GetById(Guid.Parse(courtId));
                if (result != null)
                {
                    Court updatedCourt = (Court)result.Data;
                    updatedCourt.CourtName = courtName;
                    updatedCourt.Location = location;
                    updatedCourt.IsActive = isActive;
                    updatedCourt.Status = status;
                    updatedCourt.Descrip = descrip;
                    updatedCourt.OwnerName = ownerName;
                    updatedCourt.Seats = seats;
                    updatedCourt.BadmintonNet = badmintonNet;
                    updatedCourt.Area = area;
                    var updateResult = _courtBusiness.Update(updatedCourt);
                    if (updateResult != null)
                    {
                        ClearFields();
                        MessageBox.Show("Court updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadGrdCourtsAsync();
                    }
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void LoadGrdCourtsAsync()
        {
            var result = await _courtBusiness.GetAll();
            if (result.Status > 0 && result.Data != null)
            {
                grdCourt.ItemsSource = result.Data as List<Court>;
            }
            else
            {
                grdCourt.ItemsSource = new List<Court>();
            }
        }

        private void ClearFields()
        {
            txtCourtName.Clear();
            txtCourtLocation.Clear();
            chkIsActive.IsChecked = false;
            txtCourtStatus.Clear();
            txtCourtDescrip.Clear();
            txtCourtOwnerName.Clear();
            txtCourtSeats.Clear();
            txtCourtBadmintonNet.Clear();
            txtCourtArea.Clear();
        }
    }
}