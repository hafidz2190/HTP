using System;
using System.Text;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmOpsiFile : Form
    {
        public frmOpsiFile()
        {
            InitializeComponent();
        }

        private void frmOpsiFile_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ClassHelper.jenisFile))
            {
                switch (ClassHelper.jenisFile)
                {
                    case "EXCEL":
                    case "DATABASE":
                        rbExcel.Checked = true;
                        tbSeparator.Text = string.Empty;
                        tbSeparator.ReadOnly = true;
                        break;
                    case "TXT":
                        rbTxtFile.Checked = true;
                        tbSeparator.Text = ClassHelper.separator.ToString();
                        tbSeparator.ReadOnly = false;
                        break;
                    case "CSV":
                        rbCsvFile.Checked = true;
                        tbSeparator.Text = ClassHelper.separator.ToString();
                        tbSeparator.ReadOnly = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                rbExcel.Checked = true;
                tbSeparator.ReadOnly = true;
            }
        }

        private void tbSeparator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                return;

            e.Handled = true;
            string[] array = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", ",", "|" , ";" , "/" , @"\" , "-",
            "+" , "{" , "}" , "[" , "]" , "." , "_" , " ", "<" , ">" , ":" , "'" };
            string s = tbSeparator.Text + e.KeyChar;
            foreach (var item in array)
            {
                if (s == item)
                {
                    e.Handled = false;
                }
            }
        }

        private void rbExcel_CheckedChanged(object sender, EventArgs e)
        {
            tbSeparator.ReadOnly = true;
            lblOpsi.Text = "Excel File";
            tbKeterangan.Text = "     Pilihan Excel File ini tidak memerlukan separator untuk memisahkan nama kolom. Klik OK untuk melanjutkan proses setting.";
        }

        private void rbTxtFile_CheckedChanged(object sender, EventArgs e)
        {
            tbSeparator.ReadOnly = false;
            lblOpsi.Text = "Text File";
            tbKeterangan.Text = "     Pilihan Text File memerlukan separator untuk memisahkan nama kolom, silahkan mengisikan simbol separator yang digunakan. Kemudian klik OK untuk melanjutkan proses setting.";
        }

        private void rbCsvFile_CheckedChanged(object sender, EventArgs e)
        {
            tbSeparator.ReadOnly = false;
            lblOpsi.Text = "CSV File";
            tbKeterangan.Text = "     Pilihan CSV File memerlukan separator untuk memisahkan nama kolom, silahkan mengisikan simbol separator yang digunakan. Kemudian klik OK untuk melanjutkan proses setting.";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbTxtFile.Checked || rbCsvFile.Checked)
            {
                if (string.IsNullOrEmpty(tbSeparator.Text))
                    MessageBox.Show("Isi separator terlebih dahulu.", "Peringatan");
                else
                {
                    string jen = rbTxtFile.Checked ? "TXT" : "CSV";
                    if (MessageBox.Show("File yang dipilih adalah " + jen + ", dengan menggunakan separator '" + tbSeparator.Text + "' ?", "Informasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClassHelper.jenisFile = jen;
                        ClassHelper.separator = tbSeparator.Text[0];
                        Close();
                    }
                }
            }
            else
            {

                if (MessageBox.Show("File yang dipilih adalah file Excel ?", "Informasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClassHelper.jenisFile = "EXCEL";
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Apakah anda ingin setting Database?");
            sb.AppendLine("1. Tekan 'Yes' untuk melakukan setting Database.");
            sb.AppendLine("2. Tekan 'No' untuk tetap di halaman memilih Data File ini.");
            sb.AppendLine("3. Tekan 'Cancel' untuk Keluar setting aplikasi.");
            DialogResult result = MessageBox.Show(sb.ToString(), "Peringatan", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                ClassHelper.jenisFile = "DATABASE";
                Close();
            }
            else if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
