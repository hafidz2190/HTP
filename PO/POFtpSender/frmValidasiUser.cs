using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POFtpSender
{
  public partial class frmValidasiUser : Form
  {
    public frmValidasiUser()
    {
      InitializeComponent();
    }

    private void btnBatal_Click( object sender, EventArgs e )
    {
      Close();
    }

    private void btnSimpan_Click( object sender, EventArgs e )
    {
      string errMsg = string.Concat( errEmail.GetError( tbEmail ),errTelepon.GetError(tbTelpon));
      if( !string.IsNullOrEmpty( errMsg ) )
        return;

      if( string.IsNullOrEmpty( tbEmail.Text ) || string.IsNullOrEmpty( tbTelpon.Text ) )
      {
        MessageBox.Show( "Email dan telpon tidak boleh kosong.", "Peringatan" );
        return;
      }

      DialogResult = DialogResult.OK;
      ClassHelper.MailUser = tbEmail.Text;
      ClassHelper.PhoneUser = tbTelpon.Text;
      Close();
    }

    private void tbEmail_Validating( object sender, CancelEventArgs e )
    {
      if( string.IsNullOrEmpty( tbEmail.Text ) )
      {
        errEmail.SetError( tbEmail, "Email Tidak Boleh Kosong" );
        return; 
      }

      if( !IsEmailValid( tbEmail.Text ) )
      {
        errEmail.SetError( tbEmail, "Format Email Tidak Valid" );
      }
      else
      {
        errEmail.Clear();
      }
    }

    public bool IsEmailValid( string emailaddress )
    {
      try
      {
        System.Net.Mail.MailAddress m = new MailAddress( emailaddress );

        return true;
      }
      catch
      {
        return false;
      }
    }

    private void tbTelpon_Validating( object sender, CancelEventArgs e )
    {
      if( string.IsNullOrEmpty(tbTelpon.Text) )
      {
        errTelepon.SetError( tbTelpon, "Telepon Tidak Boleh Kosong" );
      }
      else
      {
        errTelepon.Clear();
      }
    }
  }
}
