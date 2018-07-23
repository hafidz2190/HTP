using System;
using System.IO;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            curDir += @"\Information\";
            string path = Path.Combine(curDir, "Aplikasi PO Sender.htm");
            wbHelper.Url = new Uri(path);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
