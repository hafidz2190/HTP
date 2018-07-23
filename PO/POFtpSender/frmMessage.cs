using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmMessage : Form
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public frmMessage(string header, string pesan)
        {
            InitializeComponent();
            this.Header = header;
            this.Message = pesan;

            this.Load += FrmMessage_Load;
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            lblHeader.Text = this.Header;
            textBox1.Text = this.Message;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
