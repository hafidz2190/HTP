using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZLibNet;

namespace POUpdaterApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read string file = "update.zip";

            progressBar1.Maximum = 100;
            lblStatus.Text = "Persiapan Extract File..";
            string file = "update.zip";
            FileInfo info = new FileInfo(file);
            if (info.Exists)
            {
                lblStatus.Text = "Proses Extract File..";
                // Unzip file 
                    UnZipper uz = new UnZipper();
                uz.Destination = @"unzip\";
                //uz.IfFileExist = enIfFileExist.Exception;
                uz.ItemList.Add("*.*");
                uz.Recurse = false;
                uz.ZipFile = file;
                uz.UnZip();
                Thread.Sleep(3000);
                lblStatus.Text = "Extract File Selesai..";
                // Copy and paste file content
                string sourcePath = uz.Destination;
                string targetPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filecontent = string.Empty;
                string[] contentFiles = Directory.GetFiles(sourcePath);
                lblStatus.Text = "Persiapan proses pemindahan file..";
                foreach (var item in contentFiles)
                {
                    filecontent = Path.GetFileName(item);
                }

                string sourceFile = System.IO.Path.Combine(sourcePath, filecontent);
                string destFile = System.IO.Path.Combine(targetPath, filecontent);

                if (!System.IO.Directory.Exists(targetPath))
                {
                    lblStatus.Text = "Proses pembuatan folder..";
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                System.IO.File.Copy(sourceFile, destFile, true);

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    lblStatus.Text = "Proses pemindahan file..";
                    for (int i = 0; i < files.Length; i++)
                    {
                        filecontent = System.IO.Path.GetFileName(files[i]);
                        destFile = System.IO.Path.Combine(targetPath, filecontent);
                        System.IO.File.Copy(files[i], destFile, true);

                        float completePercent = ((float)(i + 1) / (float)files.Length) * 100;
                        lblStatus.Text = $"Memindahkan file {filecontent}...... ";
                        lblPersentase.Text = Convert.ToInt32(completePercent).ToString() + "%";

                        progressBar1.Value = Convert.ToInt32(completePercent);
                    }

                    File.Delete("update.zip");
                    Directory.Delete(Path.Combine(targetPath, uz.Destination), true);
                    System.Threading.Thread.Sleep(500);
                    btnClose.Enabled = true;
                    lblStatus.Text = "Proses Update Selesai, Mohon restart aplikasi Perekaman pajak";
                }
                else
                {
                    // Console.WriteLine("Source path does not exist!");
                    lblStatus.Text = "Proses update gagal, File update tidak ditemukan!";
                }
            }
            else
            {
                lblStatus.Text = "File Update Tidak Ditemukan";
                MessageBox.Show("File Update Tidak Ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.FileName = "POFtpSender.exe";
            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Close Updater Form
            this.Close();
        }
    }
}
