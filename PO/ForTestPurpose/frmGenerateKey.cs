using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POAdministrationTools;

namespace ForTestPurpose
{
  public partial class frmGenerateKey : Form
  {
    public frmGenerateKey()
    {
      InitializeComponent();
    }

    private void frmGenerateKey_Load( object sender, EventArgs e )
    {

    }

    private void btnGenerate_Click( object sender, EventArgs e )
    {
      tbSerialKey.Text = SerialKey.MakeKey( tbUsername.Text, tbKey.Text );
    }

    private void btnValidate_Click( object sender, EventArgs e )
    {
      var result = SerialKey.ValidateKey( tbValUsername.Text, tbValKey.Text, tbValSerialKey.Text );
      lblValResult.Text = $"Result = {result}";
    }
  }
}
