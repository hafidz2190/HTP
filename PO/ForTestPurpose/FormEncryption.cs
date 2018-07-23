using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForTestPurpose
{
  public partial class FormEncryption : Form
  {
    public FormEncryption()
    {
      InitializeComponent();
    }

    private void btnEncrypt_Click( object sender, EventArgs e )
    {
      tbResultEncrypted.Text = POAdministrationTools.StringCipher.Encrypt( tbPlainText.Text, tbEncryptedPassword.Text );
      lblStringLength.Text = $"Length : {tbResultEncrypted.Text.Length}";
    }

    private void btnDecrypt_Click( object sender, EventArgs e )
    {
      tbResultDecrypted.Text = POAdministrationTools.StringCipher.Decrypt( tbEncryptedText.Text, tbDecryptPassword.Text );
    }

    private void btnBrowseEnc_Click( object sender, EventArgs e )
    {
      if( openFileDialog1.ShowDialog() == DialogResult.OK )
      {
        tbFileEncSource.Text = openFileDialog1.FileName;
      }
    }

    private void btnBrowseDec_Click( object sender, EventArgs e )
    {
      if( openFileDialog1.ShowDialog() == DialogResult.OK )
      {
        tbFileDecSource.Text = openFileDialog1.FileName;
      }
    }

    private void btnEncryptFile_Click( object sender, EventArgs e )
    {
      string message = string.Empty;
      POAdministrationTools.FileCipher.EncryptFile( tbFileEncSource.Text, "file.pof", out message );
      lblFileEncMessage.Text = message;
    }

    private void btnDecryptFile_Click( object sender, EventArgs e )
    {
      string message = string.Empty;
      POAdministrationTools.FileCipher.DecryptFile( tbFileDecSource.Text, "file.js", out message );
      lblFileDecMessage.Text = message;
    }
  }
}
