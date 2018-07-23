using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmMonitoring : Form
    {
        public frmMonitoring()
        {
            InitializeComponent();

            SetUserDataSource();
        }

        private void frmMonitoring_Load(object sender, EventArgs e)
        {
            this.dgvUser.CellContentClick += DgvUser_CellContentClick;
            System.Threading.Thread.Sleep(3000);
            timer1.Start();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var username = senderGrid["Username", e.RowIndex].Value;
            var ipaddress = senderGrid["IP_Address", e.RowIndex].Value;
            //var port = senderGrid["Port", e.RowIndex].Value;

            SetDataSourceNOP(username.ToString());
            SetDetailList(username.ToString());
        }

        private void DgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var username = senderGrid["Username", e.RowIndex].Value;
            var ipaddress = senderGrid["IP_Address", e.RowIndex].Value;
            timer1.Stop();
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonColumn btn = senderGrid.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
                switch (btn.Text)
                {
                    case "Request":
                        frmGetDataTransaction form = new frmGetDataTransaction(username.ToString());
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            timer1.Start();
                        }
                        break;
                    default:
                        timer1.Start();
                        break;
                }
            }
            else
            {
                SetDataSourceNOP(username.ToString());
                SetDetailList(username.ToString());
            }

            timer1.Start();
        }

        public void SetUserDataSource()
        {
            List<UserClient> listUser = SettingClientBusiness.RetrieveUserClient(string.Empty);
            List<UserDataGridItem> source = new List<UserDataGridItem>();
            Parallel.ForEach(listUser, (user) =>
            {
                List<UserActivity> activities = UserActivityBusiness.RetrieveUserActivity(user.Username)
                                                                    .OrderByDescending(m => m.Activity_Date).ToList();

                var firstValueStartUpDetail = activities.Where(m => m.Keterangan.Contains("Inisialisasi Aplikasi"));
                string ipAddress = "0.0.0.0";
                if (firstValueStartUpDetail.FirstOrDefault() != null)
                {
                    var todayStartUpAct = firstValueStartUpDetail.FirstOrDefault().Activity_Date.Date == DateTime.Now.Date ?
                                            firstValueStartUpDetail.FirstOrDefault() : null;                   
                    if (todayStartUpAct != null)
                    {
                        //isTodayAppRefresh = true;
                        ipAddress = todayStartUpAct.Ip_Address;
                    }
                }

                bool isAppsActivated = false;
                Dictionary<string, FormHelper.ClientConnectionModel> connectedClient = FormHelper.ConnectedClient;

                FormHelper.ClientConnectionModel valueClient;
                if (connectedClient.TryGetValue(user.Username, out valueClient))
                {
                    isAppsActivated = true;
                }



                source.Add(new UserDataGridItem
                {
                    Username = user.Username,
                    Webusername = user.Web_Username,
                    IP_Address = ipAddress,
                    Port = user.Port_Client,
                    Status_Perangkat = isAppsActivated
                });
            });

            dgvUser.DataSource = source;
            dgvUser.Refresh();
        }

        private void SetDetailList(string username)
        {
            //throw new NotImplementedException();
        }

        private void SetDataSourceNOP(string username)
        {
            List<UserNOP> source = UserNopBusiness.RetrieveNOPByUsername(username);
            dgvNOP.DataSource = source;
            dgvNOP.Refresh();
        }

        private class UserDataGridItem
        {
            public string Username { get; set; }
            public string Webusername { get; set; }
            public string IP_Address { get; set; }
            public int Port { get; set; }
            public bool Status_Perangkat { get; set; }
            public Image StatusImage
            {
                get
                {
                    return this.Status_Perangkat ? (System.Drawing.Image)Properties.Resources.Connected : (System.Drawing.Image)Properties.Resources.Disconnected;
                }
            }

        }

        private class RestartRequest
        {
            public string ApplicationName { get; set; }
        }

        private class RestartResponse
        {
            public string message { get; set; }
        }

        private class RefreshResponse
        {
            public bool IsRunning { get; set; }

            public string message { get; set; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetUserDataSource();
        }
    }
}
