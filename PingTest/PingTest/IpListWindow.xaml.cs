using System;
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
using System.Windows.Shapes;
using System.Data;

namespace PingTest
{
    /// <summary>
    /// IpListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IpListWindow : Window
    {
        public IpListWindow()
        {
            InitializeComponent();
        }

        private void AddIpButton_Click(object sender, RoutedEventArgs e)
        {
            new AddIpWindow().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IplistView.ItemsSource = PublicClass.ipsDataTable;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            while (IplistView.SelectedItems.Count>0)
            {
                DataRowView rowveiw = (DataRowView)IplistView.SelectedItems[0];
                rowveiw.Delete();
            }
            DatabaseDataSetTableAdapters.ipsTableAdapter ipsTa = new DatabaseDataSetTableAdapters.ipsTableAdapter();
            ipsTa.Update(PublicClass.ipsDataTable);
        }
    }
}
