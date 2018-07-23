using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POAdministrationTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POFtpSender
{
    public partial class frmWizard : Form
    {
        frmSettingDB _objForm = new frmSettingDB();
        frmSettingDB _objForm2 = new frmSettingDB();
        DataTable _dtPajak = new DataTable();
        DataTable _dtDetail = new DataTable();
        string _dbConnector = string.Empty;
        List<JenisPajak> _lstPajak;
        string _queryPajakFinish = string.Empty;
        string _queryDetailFinish = string.Empty;
        bool _isFromBack;
        public frmWizard()
        {
            InitializeComponent();
            //HideTabPages();
            tabcWizard.SelectedIndex = 0;
            btnBack.Enabled = false;
            btnFinish.Enabled = false;
            rbOracle.Checked = true;
            lblConn.BackColor = System.Drawing.Color.White;
            lblTitle.Text = "Setting Koneksi Database";
            lblInformation.Text = "Halaman ini digunakan untuk setting database, Silahkan ikuti langkah - langkah yang telah disediakan.";
            pbInformation.Image = Properties.Resources.db;
            numWizard.Value = 0;
            lblCountNop.Text = "Jml : 0";
            LoadFrmQuery();
        }

        private void LoadFrmQuery()
        {

            _objForm.TopLevel = false;
            pnlSetQuery.Controls.Add(_objForm);
            _objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _objForm.Show();


            _objForm2.TopLevel = false;
            pnlDetail.Controls.Add(_objForm2);
            _objForm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _objForm2.Show();
        }


        private void LoadComboPajak()
        {
            _lstPajak = new List<JenisPajak>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ClassHelper.urlAPI + "/dev/GetTarifPajak");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
            string info = readStream.ReadToEnd();
            JObject jObj = JObject.Parse(info);
            JToken jUser = jObj["body"];

            _lstPajak = JsonConvert.DeserializeObject<List<JenisPajak>>(jUser.ToString()).ToList();

            response.Close();
            readStream.Close();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            _isFromBack = false;
            numWizard.Value += 1;
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            _isFromBack = true;
            numWizard.Value -= 1;
        }

        private void rbOracle_CheckedChanged(object sender, System.EventArgs e)
        {
            gbxMySql.Hide();
            gbxOracle.Show();
            gbxSQL.Hide();
            gbxAccess.Hide();
            ClearAllDbTeks();
        }

        private void rbMySql_CheckedChanged(object sender, System.EventArgs e)
        {
            gbxMySql.Show();
            gbxOracle.Hide();
            gbxSQL.Hide();
            gbxAccess.Hide();
            ClearAllDbTeks();
        }

        private void ClearAllDbTeks()
        {
            tbOracleDataSource.Text = string.Empty;
            tbOracleUsername.Text = string.Empty;
            tbOraclePassword.Text = string.Empty;

            tbMySqlServer.Text = string.Empty;
            tbMySqlDatabase.Text = string.Empty;
            tbMySqlUsername.Text = string.Empty;
            tbMySqlPassword.Text = string.Empty;

            tbSqlDatabase.Text = string.Empty;
            tbSqlServer.Text = string.Empty;
            tbSqlUsername.Text = string.Empty;
            tbSqlPassword.Text = string.Empty;

            tbAccessPath.Text = string.Empty;
            tbAccessPassword.Text = string.Empty;
        }

        private void numWizard_ValueChanged(object sender, EventArgs e)
        {
            string queryPajak = string.Empty;
            string queryDetail = string.Empty;
            switch (Convert.ToInt32(numWizard.Value))
            {
                case 0:
                    lblTitle.Text = "Setting Koneksi Database";
                    lblInformation.Text = "Halaman ini digunakan untuk setting database, Silahkan ikuti langkah - langkah yang telah disediakan.";
                    pbInformation.Image = Properties.Resources.db;

                    btnBack.Enabled = false;
                    btnNext.Enabled = true;
                    btnFinish.Enabled = false;

                    lblConn.BackColor = System.Drawing.Color.White;
                    lblQuery.BackColor = System.Drawing.Color.Transparent;
                    lblDetail.BackColor = System.Drawing.Color.Transparent;
                    lblColumn.BackColor = System.Drawing.Color.Transparent;
                    lblFinish.BackColor = System.Drawing.Color.Transparent;

                    tabcWizard.SelectedIndex = 0;
                    break;
                case 1:
                    lblTitle.Text = "Generate Query Pajak";
                    lblInformation.Text = "Halaman Generate ini menampilkan Query yang akan digunakan untuk mengambil data pajak.";
                    pbInformation.Image = Properties.Resources.query;

                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    btnFinish.Enabled = false;

                    lblConn.BackColor = System.Drawing.Color.Transparent;
                    lblQuery.BackColor = System.Drawing.Color.White;
                    lblDetail.BackColor = System.Drawing.Color.Transparent;
                    lblColumn.BackColor = System.Drawing.Color.Transparent;
                    lblFinish.BackColor = System.Drawing.Color.Transparent;

                    tabcWizard.SelectedIndex = 1;

                    //set db connector
                    ClassHelper.dbConnector = _dbConnector;
                    ClassHelper.dictDbConnector = new System.Collections.Generic.Dictionary<string, string>();
                    switch (_dbConnector)
                    {
                        case "ORACLE":
                            ClassHelper.dictDbConnector.Add(tbOracleDataSource.Name, tbOracleDataSource.Text);
                            ClassHelper.dictDbConnector.Add(tbOracleUsername.Name, tbOracleUsername.Text);
                            ClassHelper.dictDbConnector.Add(tbOraclePassword.Name, tbOraclePassword.Text);
                            break;
                        case "SQL":
                            ClassHelper.dictDbConnector.Add(tbSqlServer.Name, tbSqlServer.Text);
                            ClassHelper.dictDbConnector.Add(tbSqlDatabase.Name, tbSqlDatabase.Text);
                            ClassHelper.dictDbConnector.Add(tbSqlUsername.Name, tbSqlUsername.Text);
                            ClassHelper.dictDbConnector.Add(tbSqlPassword.Name, tbSqlPassword.Text);
                            break;
                        case "MYSQL":
                            ClassHelper.dictDbConnector.Add(tbMySqlServer.Name, tbMySqlServer.Text);
                            ClassHelper.dictDbConnector.Add(tbMySqlDatabase.Name, tbMySqlDatabase.Text);
                            ClassHelper.dictDbConnector.Add(tbMySqlUsername.Name, tbMySqlUsername.Text);
                            ClassHelper.dictDbConnector.Add(tbMySqlPassword.Name, tbMySqlPassword.Text);
                            break;
                        case "ACCESS":
                            ClassHelper.dictDbConnector.Add(tbAccessPath.Name, tbAccessPath.Text);
                            ClassHelper.dictDbConnector.Add(tbAccessPassword.Name, tbAccessPassword.Text);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    lblTitle.Text = "Generate Query Detail";
                    lblInformation.Text = "Halaman Generate ini menampilkan Query yang akan digunakan untuk mengambil detail transaksi.";
                    pbInformation.Image = Properties.Resources.table_relationships;
                    _dtPajak = new DataTable();

                    queryPajak = _objForm.Controls["tbHasil"].Text;
                    _queryPajakFinish = queryPajak;

                    #region Old Code
                    //switch (_dbConnector)
                    //{
                    //    case "ORACLE":
                    //        try
                    //        {                                
                    //            POProject.CommandAdapter.OracleCmdBuilder cmd = new POProject.CommandAdapter.OracleCmdBuilder(tbOracleDataSource.Text, tbOracleUsername.Text, tbOraclePassword.Text);
                    //            _queryPajakFinish = queryPajak + " WHERE rownum <= 10";
                    //            cmd.Query = _queryPajakFinish;
                    //            _dtPajak = cmd.GetTable();

                    //            DataTable resultTable = new DataTable();
                    //            ValidateNamaKolom(queryPajak, _dtPajak, out resultTable);
                    //            _dtPajak = resultTable.Copy();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Peringatan");
                    //            btnBack_Click(null, null);
                    //            return;
                    //        }
                    //        break;
                    //    case "SQL":
                    //        try
                    //        {
                    //            POProject.CommandAdapter.SqlCmdBuilder cmd = new POProject.CommandAdapter.SqlCmdBuilder(tbSqlServer.Text, tbSqlDatabase.Text,
                    //                tbSqlUsername.Text, tbSqlPassword.Text);
                    //            _queryPajakFinish = "SELECT TOP(10) " + queryPajak.Replace("SELECT", string.Empty).Replace("select", string.Empty);
                    //            cmd.Query = _queryPajakFinish;
                    //            _dtPajak = cmd.GetTable();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Peringatan");
                    //            btnBack_Click(null, null);
                    //            return;
                    //        }
                    //        break;
                    //    case "MYSQL":
                    //        try
                    //        {
                    //            POProject.CommandAdapter.MySqlCmdBuilder cmd = new POProject.CommandAdapter.MySqlCmdBuilder(tbMySqlServer.Text, tbMySqlDatabase.Text,
                    //                tbMySqlUsername.Text, tbMySqlPassword.Text);
                    //            _queryPajakFinish = queryPajak + " LIMIT 10";
                    //            cmd.Query = _queryPajakFinish;
                    //            _dtPajak = cmd.GetTable();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Peringatan");
                    //            btnBack_Click(null, null);
                    //            return;
                    //        }
                    //        break;
                    //    case "ACCESS":
                    //        try
                    //        {
                    //            POProject.CommandAdapter.MsAccessCmdBuilder cmd = new POProject.CommandAdapter.MsAccessCmdBuilder(tbAccessPath.Text, tbAccessPassword.Text);
                    //            _queryPajakFinish = "SELECT TOP 10" + queryPajak.Replace("SELECT", string.Empty).Replace("select", string.Empty);
                    //            cmd.Query = _queryPajakFinish;
                    //            _dtPajak = cmd.GetTable();
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Peringatan");
                    //            btnBack_Click(null, null);
                    //            return;
                    //        }
                    //        break;
                    //    default:
                    //        break;
                    //}
                    #endregion                    

                    try
                    {
                        DataParser.CekValidQuery(_queryPajakFinish, _dbConnector, ClassHelper.dictDbConnector, out _dtDetail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    btnFinish.Enabled = false;

                    lblConn.BackColor = System.Drawing.Color.Transparent;
                    lblQuery.BackColor = System.Drawing.Color.Transparent;
                    lblDetail.BackColor = System.Drawing.Color.White;
                    lblColumn.BackColor = System.Drawing.Color.Transparent;
                    lblFinish.BackColor = System.Drawing.Color.Transparent;

                    tabcWizard.SelectedIndex = 2;
                    break;
                case 3:
                    lblTitle.Text = "Pilihan Nama Kolom";
                    lblInformation.Text = "Halaman ini untuk memilih nama - nama kolom yang akan diambil, Nama kolom yang diambil akan menghasilkan query select kolom tersebut.";
                    pbInformation.Image = Properties.Resources.tablecolumn;

                    if (!_isFromBack)
                    {
                        _dtPajak = new DataTable();
                        _dtDetail = new DataTable();

                        queryPajak = _objForm.Controls["tbHasil"].Text;
                        _queryPajakFinish = queryPajak;

                        queryDetail = _objForm2.Controls["tbHasil"].Text;
                        _queryDetailFinish = queryDetail;

                        try
                        {
                            DataParser.CekValidQuery(_queryPajakFinish, _dbConnector, ClassHelper.dictDbConnector, out _dtPajak);

                            DataTable resultPajak = new DataTable();
                            ValidateNamaKolom(queryPajak, _dtPajak, out resultPajak);
                            _dtPajak = resultPajak.Copy();

                            DataParser.CekValidQuery(_queryDetailFinish, _dbConnector, ClassHelper.dictDbConnector, out _dtDetail);

                            DataTable resultDetail = new DataTable();
                            ValidateNamaKolom(queryDetail, _dtDetail, out resultDetail);
                            _dtDetail = resultDetail.Copy();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        if (_dtPajak != null)
                        {
                            lvPajak.Items.Clear();
                            foreach (DataColumn dCol in _dtPajak.Columns)
                            {
                                lvPajak.Items.Add(dCol.ColumnName.ToUpper());
                            }
                        }

                        if (_dtDetail != null)
                        {
                            lvDetail.Items.Clear();
                            foreach (DataColumn dCol in _dtDetail.Columns)
                            {
                                lvDetail.Items.Add(dCol.ColumnName.ToUpper());
                            }
                        }
                    }


                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    btnFinish.Enabled = false;

                    lblConn.BackColor = System.Drawing.Color.Transparent;
                    lblQuery.BackColor = System.Drawing.Color.Transparent;
                    lblDetail.BackColor = System.Drawing.Color.Transparent;
                    lblColumn.BackColor = System.Drawing.Color.White;
                    lblFinish.BackColor = System.Drawing.Color.Transparent;

                    tabcWizard.SelectedIndex = 3;
                    break;
                case 4:
                    lblTitle.Text = "Selesai dan Simpan";
                    lblInformation.Text = "Selesai dan anda dapat menyimpan setting database yang telah dibuat.";
                    pbInformation.Image = Properties.Resources.savesettings;

                    string nmKolomPajak = string.Empty;
                    string nmKolomDetail = string.Empty;

                    //list nama kolom todo query                    
                    //if (cbxAllPajak.Checked)
                    //{
                    //    int iStart = _queryPajakFinish.IndexOf("SELECT");
                    //    int iEnd = _queryPajakFinish.IndexOf("FROM");
                    //    string newQuery = "SELECT * " + _queryPajakFinish.Remove(iStart, iEnd).Replace("WHERE rownum <= 10", string.Empty).Replace("LIMIT 10", string.Empty);
                    //    tbQueryPajakFix.Text = newQuery;
                    //}
                    //else
                    //{
                    foreach (var col in lvPajak.CheckedItems)
                    {
                        nmKolomPajak += ((System.Windows.Forms.ListViewItem)col).Text + ",";
                    }

                    nmKolomPajak = "SELECT " + nmKolomPajak.Remove(nmKolomPajak.Length - 1);
                    int iStartPajak = _queryPajakFinish.ToUpper().IndexOf("SELECT");
                    int iEndPajak = _queryPajakFinish.ToUpper().IndexOf("FROM");

                    //string newQueryPajak = nmKolomPajak + " " + _queryPajakFinish.Remove(iStartPajak, iEndPajak).Replace("WHERE rownum <= 10", string.Empty).Replace("LIMIT 10", string.Empty);
                    string newQueryPajak = nmKolomPajak + " " + _queryPajakFinish.Remove(iStartPajak, iEndPajak);
                    tbQueryPajakFix.Text = newQueryPajak;
                    //}

                    //if (cbxAllDetail.Checked)
                    //{
                    //    int iStart = _queryDetailFinish.IndexOf("SELECT");
                    //    int iEnd = _queryDetailFinish.IndexOf("FROM");
                    //    string newQuery = "SELECT * " + _queryDetailFinish.Remove(iStart, iEnd).Replace("WHERE rownum <= 10", string.Empty).Replace("LIMIT 10", string.Empty);
                    //    tbQueryDetailFix.Text = newQuery;
                    //}
                    //else
                    //{
                    foreach (var col in lvDetail.CheckedItems)
                    {
                        nmKolomDetail += ((System.Windows.Forms.ListViewItem)col).Text + ",";
                    }

                    nmKolomDetail = "SELECT " + nmKolomDetail.Remove(nmKolomDetail.Length - 1);
                    int iStartDetail = _queryDetailFinish.ToUpper().IndexOf("SELECT");
                    int iEndDetail = _queryDetailFinish.ToUpper().IndexOf("FROM");

                    //string newQueryDetail = nmKolomDetail + " " + _queryDetailFinish.Remove(iStartDetail, iEndDetail).Replace("WHERE rownum <= 10", string.Empty).Replace("LIMIT 10", string.Empty);
                    string newQueryDetail = nmKolomDetail + " " + _queryDetailFinish.Remove(iStartDetail, iEndDetail);
                    tbQueryDetailFix.Text = newQueryDetail;
                    //}

                    btnBack.Enabled = true;
                    btnNext.Enabled = false;
                    btnFinish.Enabled = true;

                    lblConn.BackColor = System.Drawing.Color.Transparent;
                    lblQuery.BackColor = System.Drawing.Color.Transparent;
                    lblDetail.BackColor = System.Drawing.Color.Transparent;
                    lblColumn.BackColor = System.Drawing.Color.Transparent;
                    lblFinish.BackColor = System.Drawing.Color.White;

                    tabcWizard.SelectedIndex = 4;
                    break;
                default:
                    break;
            }
        }

        private void ValidateNamaKolom(string originalQuery, DataTable sourceTable, out DataTable resultTable)
        {
            Dictionary<string, Type> dictKolomName = new Dictionary<string, Type>();
            bool foundDuplicate = false;
            foreach (DataColumn colName in sourceTable.Columns)
            {
                string lastColChar = colName.ColumnName.Substring(colName.ColumnName.Length - 1, 1);
                try
                {
                    //if last col is number
                    int iColChar = Convert.ToInt32(lastColChar);

                    //check posible colname is duplicate with other colname
                    string possibleColName = colName.ColumnName.Substring(0, colName.ColumnName.Length - 1);
                    if (dictKolomName.ContainsKey(possibleColName))
                    {
                        dictKolomName.Remove(possibleColName);

                        //duplicate column name found
                        possibleColName = possibleColName.Insert(0, ClassHelper.AliasTableSettingDB[0] + ".");
                        dictKolomName.Add(possibleColName, colName.DataType);

                        foundDuplicate = true;
                    }
                    else
                    {
                        dictKolomName.Add(colName.ColumnName, colName.DataType);
                    }

                }
                catch
                {
                    dictKolomName.Add(colName.ColumnName, colName.DataType);
                }
            }

            resultTable = new DataTable();
            if (!foundDuplicate)
            {
                resultTable = sourceTable.Clone();
            }
            else
            {
                foreach (KeyValuePair<string, Type> item in dictKolomName)
                {
                    resultTable.Columns.Add(item.Key, item.Value);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNop_Click(object sender, EventArgs e)
        {
            numJmlNop.Value += 1;
        }

        private void btnDelNop_Click(object sender, EventArgs e)
        {
            if (numJmlNop.Value == 0)
            {
                return;
            }

            bool isChecked = false;
            Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), dRow =>
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dRow.Cells[0];
                if (chk.Value != null)
                    isChecked = true;

            });

            if (isChecked)
            {
                for (int i = dgvNop.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)dgvNop.Rows[i].Cells[0].FormattedValue)
                    {
                        dgvNop.Rows.RemoveAt(i);
                        numJmlNop.Value -= 1;
                    }
                }
            }
            else
                numJmlNop.Value -= 1;

            if (numJmlNop.Value == 0)
                cbAll.Checked = false;
        }

        private void numJmlNop_ValueChanged(object sender, EventArgs e)
        {
            while (dgvNop.Rows.Count < numJmlNop.Value)
            {
                dgvNop.Rows.Add();
            }
            while (dgvNop.Rows.Count > numJmlNop.Value)
            {
                dgvNop.Rows.RemoveAt(dgvNop.Rows.Count - 1);
            }

            lblCountNop.Text = "Jml : " + numJmlNop.Value;
        }

        private void cbAll_Click(object sender, EventArgs e)
        {
            Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), dRow =>
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dRow.Cells[0];
                chk.Value = cbAll.Checked;
            });
        }

        private void btnTesOracle_Click(object sender, EventArgs e)
        {
            string pesan = string.Empty;
            bool isConnect = false;

            if (rbOracle.Checked)
            {
                isConnect = DataParser.TesOracleConnection(tbOracleDataSource.Text, tbOracleUsername.Text, tbOraclePassword.Text, out pesan);
                _dbConnector = "ORACLE";
            }
            else if (rbSql.Checked)
            {
                isConnect = DataParser.TesSQLConnection(tbSqlServer.Text, tbSqlDatabase.Text, tbSqlUsername.Text, tbSqlPassword.Text, out pesan);
                _dbConnector = "SQL";
            }
            else if (rbMySql.Checked)
            {
                isConnect = DataParser.TesMySqlConnection(tbMySqlServer.Text, tbMySqlDatabase.Text, tbMySqlUsername.Text, tbMySqlPassword.Text, out pesan);
                _dbConnector = "MYSQL";
            }
            else if (rbAccess.Checked)
            {
                isConnect = DataParser.TesAccessConnection(tbAccessPath.Text, tbAccessPassword.Text, out pesan);
                _dbConnector = "ACCESS";
            }

            if (isConnect)
                btnNext.Enabled = true;

            MessageBox.Show(pesan, "Peringatan");
        }

        private void tbOracleDS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbOracleUsername.Focus();
        }

        private void tbOracleUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbOraclePassword.Focus();
        }

        private void tbMySqlServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbMySqlDatabase.Focus();
        }

        private void tbMySqlDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbMySqlUsername.Focus();
        }

        private void tbMySqlUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbMySqlPassword.Focus();
        }

        private void rbSql_CheckedChanged(object sender, EventArgs e)
        {
            gbxMySql.Hide();
            gbxOracle.Hide();
            gbxAccess.Hide();
            gbxSQL.Show();
            ClearAllDbTeks();
        }

        private void tbSqlServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbSqlDatabase.Focus();
        }

        private void tbSqlDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbSqlUsername.Focus();
        }

        private void tbSqlUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                tbSqlPassword.Focus();
        }

        private void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            gbxMySql.Hide();
            gbxOracle.Hide();
            gbxSQL.Hide();
            gbxAccess.Show();
            ClearAllDbTeks();
        }

        private void btnAccessPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbAccessPath.Text = ofd.FileName;
                tbAccessPassword.Focus();
            }
        }

        private void tbAccessPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnAccessPath_Click(null, null);
        }

        private void frmWizard_Load(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            LoadComboPajak();
            cbxJenPajak.Items.Clear();
            if (_lstPajak != null && _lstPajak.Count > 0)
            {
                var jenPjk = _lstPajak.Select(m => m.JenPajak).Distinct().ToList();
                foreach (var item in jenPjk)
                {
                    cbxJenPajak.Items.Add(item);
                }
            }
            cbxJenPajak.SelectedIndex = 0;

            tabcWizard.Appearance = TabAppearance.Normal;
            tabcWizard.ItemSize = new Size(0, 1);
            tabcWizard.SizeMode = TabSizeMode.Fixed;
        }

        private void cbxAllPajak_CheckedChanged(object sender, EventArgs e)
        {
            _isCheckBoxKlick = true;
        }

        private void cbxAllDetail_CheckedChanged(object sender, EventArgs e)
        {
            _isCheckBoxKlick = true;
        }

        bool _isCheckBoxKlick;
        private void lvPajak_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_isCheckBoxKlick)
            {
                if (lvPajak.CheckedItems.Count == lvPajak.Items.Count)
                    cbxAllPajak.Checked = true;
                else
                    cbxAllPajak.Checked = false;
            }
        }

        private void lvDetail_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_isCheckBoxKlick)
            {
                if (lvDetail.CheckedItems.Count == lvDetail.Items.Count)
                    cbxAllDetail.Checked = true;
                else
                    cbxAllDetail.Checked = false;
            }
        }

        private void cbxAllPajak_Click(object sender, EventArgs e)
        {
            if (_isCheckBoxKlick)
            {
                for (int i = 0; i < lvPajak.Items.Count; i++)
                {
                    bool isChecked = cbxAllPajak.Checked;
                    lvPajak.Items[i].Checked = isChecked;
                }
            }
        }

        private void lvPajak_MouseClick(object sender, MouseEventArgs e)
        {
            _isCheckBoxKlick = false;
        }

        private void lvDetail_MouseClick(object sender, MouseEventArgs e)
        {
            _isCheckBoxKlick = false;
        }

        private void cbxAllDetail_Click(object sender, EventArgs e)
        {
            if (_isCheckBoxKlick)
            {
                for (int i = 0; i < lvDetail.Items.Count; i++)
                {
                    bool isChecked = cbxAllDetail.Checked;
                    lvDetail.Items[i].Checked = isChecked;
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dgvNop.Rows.Count <= 0)
            {
                MessageBox.Show("Data Nop tidak boleh kosong", "Peringatan");
                return;
            }
            else
            {
                foreach (DataGridViewRow item in dgvNop.Rows)
                {
                    if (item.Cells["NOP"].Value == null)
                    {
                        MessageBox.Show("Data Nop tidak boleh kosong.", "Peringatan");
                        return;
                    }


                    if (item.Cells["ALIAS"].Value == null)
                    {
                        MessageBox.Show("Alias harus diisi.", "Peringatan");
                        return;
                    }
                    else
                    {
                        if (item.Cells["ALIAS"].Value.ToString().Split(' ').Count() > 1)
                        {
                            MessageBox.Show("Jangan gunakan spasi pada alias");
                            return;
                        }
                    }

                }
            }


            //Compare Nop dengan jenispajak
            bool isPajakValid = true;
            List<string> lstNopInvalid = new List<string>();
            string nop = string.Empty;
            string codePajak = string.Empty;
            foreach (DataGridViewRow item in dgvNop.Rows)
            {

                switch (cbxJenPajak.Text)
                {
                    case "HOTEL":
                        codePajak = "901";
                        break;
                    case "RESTORAN":
                        codePajak = "902";
                        break;
                    case "HIBURAN":
                        codePajak = "903";
                        break;
                    case "PARKIR":
                        codePajak = "907";
                        break;
                    default:
                        break;
                }

                nop = item.Cells["NOP"].Value.ToString();
                if (string.Compare(nop.Replace(".", string.Empty).Substring(10, 3), codePajak) != 0)
                {
                    isPajakValid = false;
                    lstNopInvalid.Add(nop);
                }
            }

            if (!isPajakValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in lstNopInvalid)
                {
                    sb.Append(item + ",");
                }

                MessageBox.Show("Nop (" + sb.ToString().Remove(sb.Length - 1, 1) + "), bukan atas pajak " + cbxJenPajak.Text, "Peringatan");
                return;
            }

            DBSettings setDB = new DBSettings();
            List<NopPajak> lst = new List<NopPajak>();
            string jenPjk = cbxJenPajak.Text;
            string tarif = cbxTarif.Text;
            Parallel.ForEach(dgvNop.Rows.Cast<DataGridViewRow>(), dRow =>
            {
                NopPajak na = new NopPajak();
                na.JenisPajak = jenPjk;
                na.Nop = dRow.Cells["NOP"].Value.ToString().Replace(".", string.Empty).ToUpper();
                na.Alias = dRow.Cells["ALIAS"].Value.ToString();
                na.TarifPajak = tarif;
                lst.Add(na);
            });

            setDB.LstNop = lst;
            setDB.NamaDB = ClassHelper.dbConnector;
            setDB.QueryPajak = tbQueryPajakFix.Text;
            setDB.QueryDetail = tbQueryDetailFix.Text;
            setDB.lstSourceDB = new List<SourceDB>();

            Parallel.ForEach(ClassHelper.dictDbConnector, iDic =>
            {
                SourceDB sd = new SourceDB();
                sd.Name = iDic.Key;
                sd.Value = iDic.Value;
                setDB.lstSourceDB.Add(sd);
            });

            ClassHelper.lstDBSettings.Add(setDB);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbxJenPajak_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTarif.Items.Clear();
            var tarifPajak = _lstPajak.Where(m => m.JenPajak.Equals(cbxJenPajak.Text)).Select(m => m.Tarif).ToList();
            if (tarifPajak != null)
            {
                foreach (var item in tarifPajak)
                {
                    cbxTarif.Items.Add(item);
                }
            }
            cbxTarif.SelectedIndex = 0;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string queryPajak = tbQueryPajakFix.Text;
            if (string.IsNullOrEmpty(queryPajak))
            {
                MessageBox.Show("Tidak ada query yang ingin di validate.", "Peringatan");
                return;
            }

            string queryMessage = string.Empty;
            if (!ClassHelper.IsQueryContainDate(queryPajak, out queryMessage))
            {
                MessageBox.Show(queryMessage);
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                DataParser.CekValidQuery(queryPajak, ClassHelper.dbConnector, ClassHelper.dictDbConnector, out dt);
                MessageBox.Show("Query berhasil", "Perhatian");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query tidak valid : " + ex.Message, "Peringatan");
                return;
            }
        }

        private void btnValidateDetail_Click(object sender, EventArgs e)
        {
            string queryDetail = tbQueryDetailFix.Text;
            if (string.IsNullOrEmpty(queryDetail))
            {
                MessageBox.Show("Tidak ada query yang ingin di validate.", "Peringatan");
                return;
            }

            string queryMessage = string.Empty;
            if (!ClassHelper.IsQueryContainDate(queryDetail, out queryMessage))
            {
                MessageBox.Show(queryMessage);
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                DataParser.CekValidQuery(queryDetail, ClassHelper.dbConnector, ClassHelper.dictDbConnector, out dt);
                MessageBox.Show("Query berhasil", "Perhatian");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query tidak valid : " + ex.Message, "Peringatan");
                return;
            }

        }
    }

    public class JenisPajak
    {
        public string JenPajak { get; set; }
        public string Tarif { get; set; }
    }
}
