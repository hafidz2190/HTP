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
        private const string GET_TRANSACTION_DATE = "GET_TRANSACTION_DATE";
        private const string RESTART_APPLICATION = "RESTART_APPLICATION";

        public frmGetDataTransaction(string username)
        {
            InitializeComponent();

            tbUsername.Text = username;
            this.Load += FrmGetDataTransaction_Load;
            this.FormClosing += FrmGetDataTransaction_FormClosing;
        }

        private void FrmGetDataTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbTipeRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO:Change the code for dynamic add control
            Item item = (Item)cbTipeRequest.SelectedItem;
            Padding pad = new Padding(3);
            switch (item.Value)
            {
                case GET_TRANSACTION_DATE:
                    if (string.Compare(tbRepoType.Text, "FILE REPOSITORY") == 0)
                    {
                        Label label = new Label();
                        label.Text = "Pesan";
                        label.Padding = pad;
                        tableLayoutPanel1.Controls.Add(label);

                        TextBox text = new TextBox();
                        text.Name = "tbPesan";
                        text.Dock = DockStyle.Fill;
                        text.Multiline = true;
                        text.Height = 50;
                        tableLayoutPanel1.Controls.Add(text);
                    }
                    else
                    {
                        Label label = new Label();
                        label.Text = "Tanggal Transaksi";
                        label.Padding = pad;
                        tableLayoutPanel1.Controls.Add(label);

                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Name = "dtpTanggalTransaksi";
                        dtp.Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(dtp);
                    }
                    break;
                case RESTART_APPLICATION:
                    break;
                default:
                    break;
            }
        }

        private void FrmGetDataTransaction_Load(object sender, EventArgs e)
        {
            cbTipeRequest.Items.Add(new Item("Ambil Data Transaksi (Tanggal)", GET_TRANSACTION_DATE));
            cbTipeRequest.Items.Add(new Item("Restart Application", RESTART_APPLICATION));

            //Set Jenis Pajak
            SetJenisPajak();

            //Set tipe repository
            SetRepository();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            Item item = (Item)cbTipeRequest.SelectedItem;
            switch (item.Value)
            {
                case GET_TRANSACTION_DATE:
                    foreach (Control ctrl in tableLayoutPanel1.Controls)
                    {
                        if (string.Compare(ctrl.Name, "dtpTanggalTransaksi") == 0)
                        {
                            DateTimePicker dtp = ctrl as DateTimePicker;
                            string dateValue = dtp.Value.ToString("dd/MM/yyyy");
                            parameter.Add("tanggal", dateValue);
                        }
                        else if (string.Compare(ctrl.Name, "tbPesan") == 0)
                        {
                            TextBox tb = ctrl as TextBox;
                            parameter.Add("message", tb.Text);
                        }
                    }
                    break;
                case RESTART_APPLICATION:
                    break;
                default:
                    break;
            }

            RequestParameter msg = new RequestParameter()
            {
                ParamRequest = parameter,
                TipeRequest = ((Item)cbTipeRequest.SelectedItem).Value,
                TipeRepository = tbRepoType.Text,
                JenisRepository = tbJenisRepository.Text,
                ClientID = tbUsername.Text
            };

            string paramMessage = Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            RequestMessage reqMessage = new RequestMessage()
            {
                clientId = tbUsername.Text,
                message = paramMessage
            };

            FormHelper.proxy.Invoke("ClientCommand", Newtonsoft.Json.JsonConvert.SerializeObject(reqMessage)).Wait();
        }

        private void SetJenisPajak()
        {
            UserNOP userNop = UserNopBusiness.RetrieveNOPByUsername(tbUsername.Text).FirstOrDefault();
            if (userNop != null)
            {
                tbJenisPajak.Text = userNop.Jenis_Pajak;
            }
        }

        private void SetRepository()
        {
            if (SettingClientBusiness.IsUserUsingDatabase(tbUsername.Text))
            {
                tbRepoType.Text = "DATABASE REPOSITORY";

                settingDBSource dbSource = SettingClientBusiness.RetrieveSourceDB(tbUsername.Text).FirstOrDefault();
                if (dbSource != null)
                {
                    tbJenisRepository.Text = dbSource.namaDB;
                }
            }
            else
            {
                tbRepoType.Text = "FILE REPOSITORY";
                UserXMLFile file = SettingClientBusiness.RetrieveUserXmlFile(tbUsername.Text).FirstOrDefault();
                tbJenisRepository.Text = file.File_Note;
            }
        }

        class Item
        {
            public string Name;
            public string Value;
            public Item(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        class RequestParameter
        {
            public string ClientID { get; set; }
            public string TipeRequest { get; set; }
            public string TipeRepository { get; set; }
            public string JenisRepository { get; set; }
            public Dictionary<string, string> ParamRequest { get; set; }
        }

        class RequestMessage
        {
            public string clientId { get; set; }
            public string message { get; set; }
        }
    }
}
