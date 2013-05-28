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
            foreach (string ip in IpList)
            {
                MessageBox.Show(GetstringIpAddress(ip));
            }
        }
        /// <summary>  
        /// 根据IP 获取物理地址  
        /// </summary>  
        /// <param name="strIP"></param>  
        /// <returns></returns>  
        public static string GetstringIpAddress(string strIP)//strIP为IP  
        {
            string sURL = "http://www.youdao.com/smartresult-xml/search.s?type=ip&q=" + strIP + "";//youdao的URL  
            string stringIpAddress = "";
            using (XmlReader read = XmlReader.Create(sURL))//获取youdao返回的xml格式文件内容  
            {
                while (read.Read())
                {
                    switch (read.NodeType)
                    {
                        case XmlNodeType.Text://取xml格式文件当中的文本内容  
                            if (string.Format("{0}", read.Value).ToString().Trim() != strIP)
                            {
                                stringIpAddress = string.Format("{0}", read.Value).ToString().Trim();//赋值  
                                int index = stringIpAddress.IndexOf(" ");
                                stringIpAddress = stringIpAddress.Substring(0,index);
                            }
                            break;
                        //other  
                    }
                }
            }
            return stringIpAddress;
        }  
    }
}
