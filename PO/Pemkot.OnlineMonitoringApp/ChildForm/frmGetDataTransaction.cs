using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmGetDataTransaction : Form
    {
        public frmGetDataTransaction(string username)
        {
            InitializeComponent();

            tbUsername.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<settingDBSource> lstSource = SettingClientBusiness.RetrieveSourceDB(tbUsername.Text);

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
                dtpStart.Value = dtpEnd.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value)
                dtpEnd.Value = dtpStart.Value;
        }
    }
}
