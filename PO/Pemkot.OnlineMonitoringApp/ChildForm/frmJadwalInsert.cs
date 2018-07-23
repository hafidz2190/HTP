using POProject.BusinessLogic;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmJadwalInsert : Form
    {
        public frmJadwalInsert()
        {
            InitializeComponent();

            DataSource();
            ClearAll();
            // pbLoading.Hide();
            if (!bgwRefresh.IsBusy)
            {
                // pbLoading.Show();
                bgwRefresh.RunWorkerAsync();
            }
           
        }
        public int SelectedRow = 0;
        private void ClearAll()
        {
            tbNamaPjk.Text = string.Empty;
            tbAlamat.Text = string.Empty;
            mtbJam.Text = string.Empty;
            tbKeg.Text = string.Empty;
            tbVendor.Text = string.Empty;
            //tbKet.Text = string.Empty;
            cbStatus.Text = string.Empty;
            tbpetugas.Text = string.Empty;

        }

        private void Simpan_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Anda ingin menyimpan data tersebut?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                if (dt != null && dt.Rows.Count > 0) ;
                DateTime tanggal = dtpJadwal.DateTime;
                string obyekpajak = tbNamaPjk.Text;
                string alamat = tbAlamat.Text;
                string jam = mtbJam.Text;
                string kegiatan = tbKeg.Text;
                string vendor = tbVendor.Text;
                DateTime modidate = DateTime.Now;
                string status = cbStatus.Text;
                string petugas = tbpetugas.Text;

                JadwalBusiness.InsertJadwal(tanggal, obyekpajak, alamat, vendor, jam, kegiatan, modidate, status, petugas);

            }
            if (MessageBox.Show("Data Telah Tersimpan", "Informasi", MessageBoxButtons.OK) == DialogResult.Yes) ;
            ClearAll();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DataSource()
        {
            DataTable dtJadwal = new DataTable();
            DataTable dt = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal();
            dgvedit.DataSource = dtJadwal;
        }

        private void dgvedit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvedit.Rows[e.RowIndex];
                dtpJadwal.Text = row.Cells["TANGGAL"].EditedFormattedValue.ToString();
                tbNamaPjk.Text = row.Cells["OBYEK_PAJAK"].Value.ToString();
                tbAlamat.Text = row.Cells["ALAMAT"].Value.ToString();
                tbVendor.Text = row.Cells["NAMA_VENDOR"].Value.ToString();
                mtbJam.Text = row.Cells["JAM"].Value.ToString();
                tbKeg.Text = row.Cells["KEGIATAN"].Value.ToString();
                cbStatus.Text = row.Cells["STATUS"].Value.ToString();
                tbpetugas.Text = row.Cells["PETUGAS"].Value.ToString();                               
            }
        }

        private void dgvedit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvedit.Rows[e.RowIndex];
                dtpJadwal.Text = row.Cells["TANGGAL"].EditedFormattedValue.ToString();
                tbNamaPjk.Text = row.Cells["OBYEK_PAJAK"].Value.ToString();
                tbAlamat.Text = row.Cells["ALAMAT"].Value.ToString();
                tbVendor.Text = row.Cells["NAMA_VENDOR"].Value.ToString();
                mtbJam.Text = row.Cells["JAM"].Value.ToString();
                tbKeg.Text = row.Cells["KEGIATAN"].Value.ToString();
                cbStatus.Text = row.Cells["STATUS"].Value.ToString();
                tbpetugas.Text = row.Cells["PETUGAS"].Value.ToString();

            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvedit.DataSource as DataTable).DefaultView.RowFilter = string.Format("OBYEK_PAJAK LIKE '%{0}%'", tbSearch.Text);
        }
        
        DataTable dtJadwal;
        private void bgwRefresh_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            dtJadwal = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!bgwRefresh.IsBusy)
            {
                bgwRefresh.RunWorkerAsync();
            }
        }

        private void bgwRefresh_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dgvedit.DataSource = dtJadwal;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            //if (MessageBox.Show("Anda ingin update data tersebut?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    DataTable dt = new DataTable();
            //    if (dt != null && dt.Rows.Count > 0) ;                
            //    DateTime tanggal = dtpJadwal.DateTime;
            //    string obyekpajak = tbNamaPjk.Text;
            //    string alamat = tbAlamat.Text;
            //    string jam = mtbJam.Text;
            //    string kegiatan = tbKeg.Text;
            //    string vendor = tbVendor.Text;
            //    DateTime modidate = DateTime.Now;
            //    string status = cbStatus.Text;
            //    string petugas = tbpetugas.Text;

            //    JadwalBusiness.UpdateJadwal(tanggal, obyekpajak, alamat, vendor, jam, kegiatan, modidate, status, petugas);

            //}
            //if (MessageBox.Show("Update Telah Tersimpan", "Informasi", MessageBoxButtons.OK) == DialogResult.Yes) ;
            //ClearAll();
        }

     
            //if (MessageBox.Show("Anda ingin menghapus data tersebut?", "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)

            //    foreach (DataGridViewRow Rows in dgvedit.SelectedRows)
            //    {
            //        //    DataTable dt = new DataTable();
            //        //    if (dt != null && dt.Rows.Count > 0);
            //       string id = Rows.Cells["IDOP"].Value.ToString();

            //        JadwalBusiness.DeleteJadwal(id); ;
            //    }

            //if (MessageBox.Show("Data Telah Terhapus", "Informasi", MessageBoxButtons.OK) == DialogResult.Yes)
            //    ClearAll();

        }
}
