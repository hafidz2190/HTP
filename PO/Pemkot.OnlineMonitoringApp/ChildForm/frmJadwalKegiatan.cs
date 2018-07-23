using POProject.BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Pemkot.OnlineMonitoringApp.ControlDisplay;
using DevExpress.XtraEditors.Repository;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
    public partial class frmJadwalKegiatan : Form
    {
        public frmJadwalKegiatan()
        {
            InitializeComponent();
           
            read();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Arial", 11);
            
        }

        public void read()
        {

            DataTable dtJadwal = new DataTable();
            DataTable dt = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal();
            //dtJadwal.Columns.Add("IMAGE_STATUS", typeof(Image));

            //if (dtJadwal != null && dtJadwal.Rows.Count > 0)
            //{
            //    foreach (DataRow dRow in dtJadwal.Rows)
            //    {
            //        switch (dRow["STATUS"].ToString())
            //        {
            //            case "BELUM ADA FEEDBACK":
            //                Image img = Image.FromFile("../../Resources/kode-hitam.png");
            //                dRow["IMAGE_STATUS"] = img;
            //                break;
            //            case "SUDAH TERPASANG":
            //                Image img1 = Image.FromFile("../../Resources/kode-hijau.png");
            //                dRow["IMAGE_STATUS"] = img1;
            //                break;
            //            case "MENUNGGU KOORDINASI LEBIH LANJUT":
            //                Image img2 = Image.FromFile(".../.../Resources/kode-merah.png");
            //                dRow["IMAGE_STATUS"] = img2;
            //                break;
            //            case "AKAN SEGERA DIPASANG":
            //                Image img3 = Image.FromFile(".../.../Resources/kode-kuning.png");
            //                dRow["IMAGE_STATUS"] = img3;
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            gcJadwal.DataSource = dtJadwal;
            gcJadwal.Update();
            gcJadwal.Refresh();

        }

        public void update()
        {
            //DataTable dtUpdate = new DataTable();
            //if (dtUpdate != null && dtUpdate.Rows.Count > 0) ;
            //DateTime tanggal = ["Tanggal"];
            //string obyekpajak = ["OBYEKPAJAK"].to;
            //string alamat = tbAlamat.Text;
            //string jam = mtbJam.Text;
            //string kegiatan = tbKeg.Text;
            //string vendor = tbVendor.Text;
            //string keterangan = tbKet.Text;
            //string status = cbStatus.Text;

            //dtUpdate = JadwalBusiness.UpdateJadwal(tanggal);
            //gcJadwal.DataSource = dtUpdate;

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView currentView = sender as GridView;

            Rectangle r = e.Bounds;
            //if (e.Column.FieldName == "STATUS") //(1)Akan Segera dipasang
            //{
            //    e.columns
            //}
            //    string code = Convert.ToString(currentView.GetRowCellValue(e.RowHandle, currentView.Columns["STATUS"]));
            //    {
            //        // If the cell value is greater thens 50 the paint color is LightGreen, 
            //        // otherwise LightSkyBlue 
            //        //UCDisplayMonitor uc = new ControlDisplay.UCDisplayMonitor();
            //        //Brush PictureStatus = Brushes.White;

            //        try
            //        {
            //            if (code == "BELUM ADA FEEDBACK")
            //            {
            //                RepositoryItemPictureEdit pict = gcJadwal.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            //                Image img = Image.FromFile("../../Resources/Green-icon.png");
            //                pict.InitialImage = img;
            //                pict.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //                pict.NullText = " ";
            //                //PictureStatus = Brushes.Black;
            //                //Draw an ellipse within the cell                            
            //                e.Column.ColumnEdit = pict;
            //                // e.Graphics.FillEllipse(CircleBrush, r);
            //                //r.Width -= 11;
            //                ////Draw the cell value
            //                //e.Appearance.DrawString(e.Cache, e.DisplayText, r);
            //                ////Set e.Handled to true to prevent default painting
            //                //e.Handled = true;
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}
        }

        private void BtnKetWarna_Click(object sender, EventArgs e)
        {
            read();
        }

        private void BtnHitam_Click(object sender, EventArgs e)
        {
            DataTable dtJadwal = new DataTable();            
            dtJadwal = JadwalBusiness.GetJadwal1();
            dtJadwal.Columns.Add("IMAGE_STATUS", typeof(Image));
                       
            if (dtJadwal != null && dtJadwal.Rows.Count > 0)
            {   
                foreach (DataRow dRow in dtJadwal.Rows)
                {     
                    switch (dRow["STATUS"].ToString())
                    {
                        case "BELUM ADA FEEDBACK":
                           
                            Image img = Image.FromFile("../../Resources/kode-hitam.png");
                            dRow["IMAGE_STATUS"] = img;
                           break;                        
                        default:
                            break;
                    }
                }
            }
            gcJadwal.DataSource = dtJadwal;           
        }
        private void BtnHijau_Click(object sender, EventArgs e)
        {
            DataTable dtJadwal = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal2();
            dtJadwal.Columns.Add("IMAGE_STATUS", typeof(Image));

            if (dtJadwal != null && dtJadwal.Rows.Count > 0)
            {
                foreach (DataRow dRow in dtJadwal.Rows)
                {
                    switch (dRow["STATUS"].ToString())
                    {
                        case "SUDAH TERPASANG":
                            Image img1 = Image.FromFile("../../Resources/kode-hijau.png");
                            dRow["IMAGE_STATUS"] = img1;
                            break;
                        default:
                            break;
                    }
                }
            }
            gcJadwal.DataSource = dtJadwal;
        }

        private void BtnKuning_Click(object sender, EventArgs e)
        {
            DataTable dtJadwal = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal3();
            dtJadwal.Columns.Add("IMAGE_STATUS", typeof(Image));

            if (dtJadwal != null && dtJadwal.Rows.Count > 0)
            {
                foreach (DataRow dRow in dtJadwal.Rows)
                {
                    switch (dRow["STATUS"].ToString())
                    {
                        case "AKAN SEGERA DIPASANG":
                            Image img3 = Image.FromFile(".../.../Resources/kode-kuning.png");
                            dRow["IMAGE_STATUS"] = img3;
                            break;
                        default:
                            break;
                    }
                }
            }
            gcJadwal.DataSource = dtJadwal;            
        }

        private void BtnMerah_Click(object sender, EventArgs e)
        {
            DataTable dtJadwal = new DataTable();
            dtJadwal = JadwalBusiness.GetJadwal4();
            dtJadwal.Columns.Add("IMAGE_STATUS", typeof(Image));

            if (dtJadwal != null && dtJadwal.Rows.Count > 0)
            {
                foreach (DataRow dRow in dtJadwal.Rows)
                {
                    switch (dRow["STATUS"].ToString())
                    {
                        case "MENUNGGU KOORDINASI LEBIH LANJUT":
                            Image img2 = Image.FromFile(".../.../Resources/kode-merah.png");
                            dRow["IMAGE_STATUS"] = img2;
                            break;
                        default:
                            break;
                    }
                }
            }
            gcJadwal.DataSource = dtJadwal;
        }
    }

}

