using Pemkot.OnlineMonitoringApp.ControlDisplay;
using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmDisplayInformation : Form
    {
        public frmDisplayInformation()
        {
            InitializeComponent();
            SetDataSource();
            UCDisplayMonitor uc = new UCDisplayMonitor();
        }

        private void frmDisplayInformation_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            timer1.Start();
        }

        private void SetDataSource()
        {         
            List<DisplayMonitor> listUser = SettingClientBusiness.GetDisplayMonitor(string.Empty).ToList();
            List<UCDisplayMonitor> listAktif = new List<UCDisplayMonitor>();           
            GroupBox bg = new GroupBox();
            flowLayoutPanel.Controls.Clear();
            for (int iUser = 0; iUser < listUser.Count; iUser++)
            {
                List<UserActivity>activities = UserActivityBusiness.RetrieveUserActivity(listUser[iUser].Username)
                                                                    .OrderByDescending(m => m.Activity_Date).ToList();                          
                var firstValueStartUpDetail = activities.Where(m => m.Keterangan.Contains("Inisialisasi Aplikasi"));               
                string ipAddress = "0.0.0.0";
                if (firstValueStartUpDetail.FirstOrDefault() != null)
                {
                    var todayStartUpAct = firstValueStartUpDetail.FirstOrDefault().Activity_Date.Date == DateTime.Now.Date ?
                                            firstValueStartUpDetail.FirstOrDefault() : null;
                    if (todayStartUpAct != null)
                    {
                        ipAddress = todayStartUpAct.Ip_Address;
                    }
                                      
                }

                bool isAppsActivated = false;
                Dictionary<string, FormHelper.ClientConnectionModel> connectedClient = FormHelper.ConnectedClient;
                FormHelper.ClientConnectionModel valueClient;
                if (connectedClient.TryGetValue(listUser[iUser].Username, out valueClient))
                {
                    isAppsActivated = true;
                }          
                
                string lastActivity = string.Empty;
                if (activities.Count != 0)
                {
                    lastActivity = activities.FirstOrDefault().Activity_Date.ToString("dd MMMM yyyy", new CultureInfo("id-ID"));
                }
                UCDisplayMonitor uc = new UCDisplayMonitor();
                if (isAppsActivated)
                {
                    uc.LabelStatus = "Aktif";
                    uc.PictureStatus = Image.FromFile("../../Resources/Green-icon.png");
                }
                else
                {
                    uc.LabelStatus = "Tidak Aktif";
                    uc.PictureStatus = Image.FromFile("../../Resources/Red-icon.png");
                }
                             
                uc.LabelLastActivity = lastActivity;
                uc.LabelJenisPajak = listUser[iUser].Jenis_Pajak;
                uc.LabelNopTerdaftar = listUser[iUser].Jml_Nop.ToString();
                uc.LabelUsername = listUser[iUser].strNama;
                listAktif.Add(uc);
                //flowLayoutPanel.Controls.Add(uc);               
            }

            listAktif = listAktif.OrderBy(m => m.LabelStatus).ToList();
            foreach(var item in listAktif)
            {
                flowLayoutPanel.Controls.Add(item);
            }          
        }
            
               
    private class DisplayItem
        {
            public string Username { get; set; }
            public bool Status_Perangkat { get; set; }
            public string Status
            {
                get
                {
                    if (Status_Perangkat)
                    {
                        return "Active";
                    }
                    else
                    {
                        return "Not Active";
                    }
                }
            }
            public Image StatusImage
            {
                get
                {
                    return this.Status_Perangkat ? (System.Drawing.Image)Properties.Resources.Connected : (System.Drawing.Image)Properties.Resources.Disconnected;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetDataSource();
        }
    }
}
