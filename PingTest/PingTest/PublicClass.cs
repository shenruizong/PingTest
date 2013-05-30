using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PingTest
{
    class PublicClass
    {
        public static DatabaseDataSet.ipsDataTable ipsDataTable;
        public static DatabaseDataSet.ipsDataTable dtlWof;
        public static void UpdateCountry()
        {
            DatabaseDataSetTableAdapters.ipsTableAdapter ipsTa = new DatabaseDataSetTableAdapters.ipsTableAdapter();
            ipsTa.FillBy(dtlWof);
        }
    }
}
