using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmChatMessage : Form
    {
        public frmChatMessage()
        {
            InitializeComponent();
        }

        private void btnKirim_Click(object sender, System.EventArgs e)
        {
            lblChatClient(tbChat.Text);
            tbChat.Clear();
        }

        private void lblChatClient(string teks)
        {
            Label lblTeks = new Label();
            lblTeks.Text = tbChat.Text;
            lblTeks.AutoSize = true;

            tlpPesan.Controls.Add(lblTeks);
        }

        private void lblChatServer(string teks)
        {
            Label lblTeks = new Label();
            lblTeks.Text = tbChat.Text;
            lblTeks.AutoSize = true;

            tlpPesan.Controls.Add(lblTeks);
        }

        private void tbChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
            {

            }
            else if (e.KeyCode == Keys.Enter)
                btnKirim_Click(null, null);
        }
    }
}
