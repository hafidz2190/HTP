using POAdministrationTools;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmRegister : Form
    {
        private bool _isCorrectKey = false;

        public frmRegister()
        {
            InitializeComponent();
        }

        bool _isSukses;
        private void btnApply_Click(object sender, EventArgs e)
        {
            _isSukses = false;
            if (string.IsNullOrEmpty(tbSerialNo.Text))
            {
                MessageBox.Show("Serial Key tidak boleh kosong.", "Peringatan");
                _isSukses = false;
                return;
            }

            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendLine("Kode Registrasi Tidak Valid");
            sbMessage.AppendLine("Mohon hubungi Badan Pengelolaan Keuangan Pemerintah Daerah Kota Surabaya untuk kode aktivasi aplikasi Pajak Online");
            try
            {
                if (!SerialKey.ValidateKey(tbUsername.Text, tbIDMachine.Text, tbSerialNo.Text))
                {
                    tbKeterangan.Text = sbMessage.ToString();

                    _isSukses = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                tbKeterangan.Text = sbMessage.ToString();
                _isSukses = false;
                return;
            }

            _isCorrectKey = true;
            if (_isCorrectKey)
            {
                //delete existing serial key file (TRIAL MODE)
                FileInfo info = new FileInfo(ClassHelper.SerialFile);
                if (info.Exists) { info.Delete(); }

                //register serial key(REGISTERED MODE)
                ClassHelper.GenerateSerialFile("REGISTERED", tbSerialNo.Text);

                tbKeterangan.Text = "Aplikasi berhasil terdaftar. Terima kasih";
                ClassHelper.SerialNo = tbSerialNo.Text;
                _isSukses = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            string cpuInfo = string.Empty;
            cpuInfo = SerialKey.RetrieveIDMachine();

            tbIDMachine.Text = cpuInfo;
            tbUsername.Text = ClassHelper.userName;
            ClassHelper.idMachine = cpuInfo;
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isSukses)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
        }

        private void btnReAktivasi_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ClassHelper.urlAPI + "/setting/SerialKeyExist");
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"serialKey\":\"" + tbKodeLama.Text + "\",\"username\":\"" + ClassHelper.userName + "\",\"cpuId\":\"" + ClassHelper.idMachine + "\"}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(sb.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                _isSukses = true;
                ClassHelper.SerialNo = tbKodeLama.Text;
                tbKeteranganAktivasi.Text = "Aplikasi berhasil terdaftar. Terima kasih";

                //delete existing serial key file (TRIAL MODE)
                FileInfo info = new FileInfo(ClassHelper.SerialFile);
                if (info.Exists) { info.Delete(); }

                //register serial key(REGISTERED MODE)
                ClassHelper.GenerateSerialFile("REGISTERED", tbSerialNo.Text);
            }
            catch (Exception ex)
            {
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine("Kode Registrasi Tidak Valid");
                sbMessage.AppendLine("Mohon hubungi Badan Pengelolaan Keuangan dan Pajak Daerah Kota Surabaya untuk kode aktivasi aplikasi Pajak Online");

                _isSukses = false;
                tbKeteranganAktivasi.Text = sbMessage.ToString();
            }
            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //if (httpResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    _isSukses = true;
            //    ClassHelper.SerialNo = tbKodeLama.Text;
            //    tbKeteranganAktivasi.Text = "Aplikasi berhasil terdaftar. Terima kasih";

            //    //delete existing serial key file (TRIAL MODE)
            //    FileInfo info = new FileInfo(ClassHelper.SerialFile);
            //    if (info.Exists) { info.Delete(); }

            //    //register serial key(REGISTERED MODE)
            //    ClassHelper.GenerateSerialFile("REGISTERED", tbSerialNo.Text);
            //}
            //else
            //{
            //    StringBuilder sbMessage = new StringBuilder();
            //    sbMessage.AppendLine("Kode Registrasi Tidak Valid");
            //    sbMessage.AppendLine("Mohon hubungi Badan Pengelolaan Keuangan Pemerintah Daerah Kota Surabaya untuk kode aktivasi aplikasi Pajak Online");

            //    _isSukses = false;
            //    tbKeteranganAktivasi.Text = sb.ToString();
            //}
        }
    }
}
