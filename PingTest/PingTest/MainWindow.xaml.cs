﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace PingTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IpListButton_Click(object sender, RoutedEventArgs e)
        {
            new IpListWindow().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PublicClass.ipsDataTable = new DatabaseDataSet.ipsDataTable();
            DatabaseDataSetTableAdapters.ipsTableAdapter ipsTa = new DatabaseDataSetTableAdapters.ipsTableAdapter();
            ipsTa.Fill(PublicClass.ipsDataTable);
            PublicClass.UpdateCountry();
            CountryComboBox.ItemsSource = PublicClass.dtlWof;
        }
    }
}
