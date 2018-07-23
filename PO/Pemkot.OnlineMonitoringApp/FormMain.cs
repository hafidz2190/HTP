using Microsoft.AspNet.SignalR.Client;
using Pemkot.OnlineMonitoringApp.ChildForm;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SignalRConnection();
        }

        private void SignalRConnection()
        {
            try
            {
                FormHelper.HubConnect = new HubConnection("http://10.21.31.177:8885/signalr");
                FormHelper.proxy = FormHelper.HubConnect.CreateHubProxy("ServerMonitorHub");

                FormHelper.proxy.On("addMessage", message => AddMessage(message));

                FormHelper.HubConnect.Start().Wait();
                lblStatusSignalR.Text = "SignalR Status : Connected";

            }
            catch
            {
                lblStatusSignalR.Text = "SignalR Status : Not Connected";
            }
        }

        private void AddMessage(object message)
        {
            FormHelper.ConnectedClient = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, FormHelper.ClientConnectionModel>>(message.ToString());
        }

        private void refreshSignalRConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignalRConnection();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(this, new frmDisplayInformation());

            FormCollection fc = Application.OpenForms;
            bool isFormOpen = false;
            foreach (Form frm in fc)
            {
                if (string.Compare(frm.Name, "frmJadwalKegiatan") == 0)
                {
                    isFormOpen = true;
                    break;
                }
            }

            if (!isFormOpen)
            {
                frmJadwalKegiatan frmKeg = new frmJadwalKegiatan();
                frmKeg.StartPosition = FormStartPosition.Manual;
                Screen screen = GetSecondaryScreen();
                if (screen != null)
                    frmKeg.Location = screen.WorkingArea.Location;
                frmKeg.WindowState = FormWindowState.Maximized;
                frmKeg.Show();
            }
        }

        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }

            return null;
        }

        private void jadwalKegiatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(this, new frmJadwalKegiatan());
            frmJadwalKegiatan frm = new frmJadwalKegiatan();
            frm.Refresh();

        }

        private void insertJadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(this, new frmJadwalInsert());
        }

        private void monitoringToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(this, new frmMonitoring());
        }

        private void hasilPerekamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.ShowForm(this, new frmDetailPerekaman());
        }
    }
}
