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
using System.Xml;
using System.Text.RegularExpressions;
using System.Data;
using System.Net;

namespace PingTest
{
    /// <summary>
    /// AddIpWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddIpWindow : Window
    {
        public AddIpWindow()
        {
            InitializeComponent();
        }

        private void AddIpButton_Click(object sender, RoutedEventArgs e)
        {
            string AllIp = IpListBox.Text;
            AllIp = AllIp.Replace("\r", "");
            string[] IpList = AllIp.Split('\n');
            DatabaseDataSet.ipsDataTable ipsDt = new DatabaseDataSet.ipsDataTable();
            foreach (string ip in IpList)
            {
                Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
                if (rx.IsMatch(ip))
                {
                    DataRow row = ipsDt.NewRow();
                    row["ip"] = ip;
                    row["country"] = GetstringIpAddress(ip);
                    ipsDt.Rows.Add(row);
                }
            }
            DatabaseDataSetTableAdapters.ipsTableAdapter ipsTa = new DatabaseDataSetTableAdapters.ipsTableAdapter();
            try
            {
                ipsTa.Update(ipsDt);
                ipsTa.Fill(PublicClass.ipsDataTable);
            }
            catch (Exception ex)
            {

            }
            this.Close();
            
        }
        /// <summary>  
        /// 根据IP 获取物理地址  
        /// </summary>  
        /// <param name="strIP"></param>  
        /// <returns></returns>  
        public static string GetstringIpAddress(string strIP)//strIP为IP  
        {

            string m_IpAddress = strIP.Trim();

            //string[] ip = ipAddress.Split('.');
           // ipAddress = ip[0] + "." + ip[1] + ".1.1";

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.GetEncoding("GB2312");
            string html;
            try
            {
                html = client.DownloadString("http://www.ip138.com/ips1388.asp?ip=" + m_IpAddress + "&action=2");
                
            }
            catch (Exception ex)
            {
                html = client.DownloadString("http://www.ip138.com/ips1388.asp?ip=" + m_IpAddress + "&action=2");
            }
            
            string p = @"<li>本站主数据：(?<location>[^<>]+?)</li>";                        

            Match match = Regex.Match(html, p);                                        
            string m_Location = match.Groups["location"].Value.Trim();
            int index = m_Location.IndexOf(" ");
            if (index != -1)
            {
                m_Location = m_Location.Substring(0, index);
            }  
            return m_Location;
        }  
    }
}
