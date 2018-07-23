using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ForTestPurpose
{
    public partial class frmSettingDB : Form
    {
        private int _indexCtrl = 0;
        private int _indexRow = -1;
        private List<string> source;
        public frmSettingDB()
        {
            InitializeComponent();
            source = new List<string>();
            //GenerateEvent();
        }

        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            _indexCtrl++;
            _indexRow++;
            tlpDynamicControl.Controls.Add(new TextBox() { Name = $"tbKeteranganLabel{_indexCtrl}", Anchor = AnchorStyles.Left, AutoSize = true, Width = 175, Multiline=true, Height = 50 }, 6, _indexRow);
            tlpDynamicControl.Controls.Add(new Label() { Name = $"lblOn{_indexCtrl}", Text = "On:", Anchor = AnchorStyles.Left, AutoSize = true }, 5, _indexRow);
            tlpDynamicControl.Controls.Add(new ComboBox() { Name = $"cbxTableRelDesc{_indexCtrl}", Anchor = AnchorStyles.Left, AutoSize = true, Width = 150, DropDownStyle=ComboBoxStyle.DropDownList }, 4, _indexRow);
            tlpDynamicControl.Controls.Add(new TextBox() { Name = $"tbAliasTable{_indexCtrl}", Anchor = AnchorStyles.Left, AutoSize = true, Width = 100 }, 3, _indexRow);
            tlpDynamicControl.Controls.Add(new Label() { Name = $"lblRelTo{_indexCtrl}", Text = "alias:", Anchor = AnchorStyles.Left, AutoSize = true }, 2, _indexRow);
            tlpDynamicControl.Controls.Add(new TextBox() { Name = $"tbRelTable{_indexCtrl}", Anchor = AnchorStyles.Left, AutoSize = true, Width = 100 }, 1, _indexRow);
            tlpDynamicControl.Controls.Add(new Label() { Name = $"lblRel{_indexCtrl}", Text = $"Rel. Table {_indexCtrl}:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, _indexRow);

            Control[] ctrl = tlpDynamicControl.Controls.Find("cbxTableRelDesc" + _indexCtrl, true);
            ComboBox cbxTableRelationDesc = ctrl[0] as ComboBox;
            cbxTableRelationDesc.Items.Add("INNER JOIN");
            cbxTableRelationDesc.Items.Add("LEFT JOIN");
            cbxTableRelationDesc.Items.Add("RIGHT JOIN");
            cbxTableRelationDesc.SelectedIndex = 0;

            //GenerateEvent();
            //tbParentTable_TextChanged(null, null);
        }

        private void btnRemoveRelation_Click(object sender, EventArgs e)
        {
            tlpDynamicControl.Controls.RemoveByKey($"tbKeteranganLabel{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"lblOn{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"cbxTableRelDesc{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"tbAliasTable{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"lblRelTo{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"tbRelTable{_indexCtrl}");
            tlpDynamicControl.Controls.RemoveByKey($"lblRel{_indexCtrl}");

            _indexCtrl--;
        }

        private void GenerateEvent()
        {
            //throw new NotImplementedException();
            for (int iCtrl = 0; iCtrl < tlpDynamicControl.Controls.Count; iCtrl++)
            {
                if(tlpDynamicControl.Controls[iCtrl].GetType() == typeof(TextBox))
                {
                    TextBox tb = tlpDynamicControl.Controls[iCtrl] as TextBox;
                    if (tb.Name.StartsWith("tbRelTable"))
                    {
                        tb.TextChanged += Tb_TextChanged;
                    }
                }
                else if(tlpDynamicControl.Controls.GetType() == typeof(ComboBox))
                {
                    ComboBox cbx = tlpDynamicControl.Controls[iCtrl] as ComboBox;
                }
            }
        }

        private void Tb_TextChanged(object sender, EventArgs e)
        {
            //GenerateSource();
        }
        
        private void tbParentTable_TextChanged(object sender, EventArgs e)
        {
            //GenerateSource();
        }

        private void GenerateSource()
        {
            source = new List<string>();
            if (!string.IsNullOrEmpty(tbParentTable.Text))
                source.Add(tbParentTable.Text);

            for (int iCtrl = 1; iCtrl <= _indexCtrl; iCtrl++)
            {
                TextBox tb = this.Controls.Find($"tbRelTable{iCtrl}", true)[0] as TextBox;
                Control[] ctrl = this.Controls.Find($"cbxTableRel{iCtrl}", true);
                if (ctrl.Length > 0)
                {

                    if (!string.IsNullOrEmpty(tb.Text))
                    {
                        source.Add(tb.Text);
                    }

                    ComboBox cbxTableRelationDesc = ctrl[0] as ComboBox;
                    cbxTableRelationDesc.Items.Clear();
                    foreach (var item in source)
                    {
                        cbxTableRelationDesc.Items.Add(item);
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT * FROM {tbParentTable.Text} {tbParentAlias.Text} ");
            for (int iCtrl = 1; iCtrl <= _indexCtrl; iCtrl++)
            {
                TextBox tb = tlpDynamicControl.Controls.Find($"tbRelTable{iCtrl}", true)[0] as TextBox;
                if (!string.IsNullOrEmpty(tb.Text))
                {
                    TextBox tbKet = this.Controls.Find($"tbKeteranganLabel{iCtrl}", true)[0] as TextBox;
                    TextBox tbAlias = this.Controls.Find($"tbAliasTable{iCtrl}", true)[0] as TextBox;
                    ComboBox cb = tlpDynamicControl.Controls.Find($"cbxTableRelDesc{iCtrl}", true)[0] as ComboBox;
                    sb.AppendLine($"{cb.Text} {tb.Text} {tbAlias.Text} ON {tbKet.Text}");
                }
            }

            tbHasil.Text = sb.ToString();
        }
    }
}
