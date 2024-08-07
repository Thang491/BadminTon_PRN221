﻿using BadMintonWpfApp.UI.Category;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadMintonWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Customer_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCustomer();
            p.Owner = this;
            p.Show();
        }
        private void Open_CourtSlots_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCourtSlot();
            p.Owner = this;
            p.Show();
        }

    }
}
