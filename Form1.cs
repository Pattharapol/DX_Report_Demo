using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DX_Report_Demo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport();
            report.RequestParameters = false;
            report.DataSource = FillDataSet();

            string datetime = DateTime.Now.ToString().Trim().Replace(" ", "").Replace(":", "_").Replace("/", "_");
            report.ExportToPdf(@"C:\Temp\lateWorker_" + datetime + ".pdf");
            report.ExportToXls(@"C:\Temp\lateWorker_" + datetime + ".xls");
            Process.Start(@"C:\Temp");
        }

        private DataSet FillDataSet()
        {
            MySqlConnection conn = new MySqlConnection("server=192.168.0.2;userid=root;password=boom123;port=3306");
            MySqlDataAdapter da = new MySqlDataAdapter("select * from human_resource.dummy_late_data", conn);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "lateWorker");
            return dataSet;
        }
    }
}