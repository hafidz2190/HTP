using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp
{
  internal class FormHelper
  {
    public static HubConnection HubConnect;

    public static IHubProxy proxy;

    public static Dictionary<string, ClientConnectionModel> ConnectedClient = new Dictionary<string, ClientConnectionModel>();
    
    public static void ShowForm( Form parentForm, Form childForm )
    {
      var isOpen = false;
      foreach(Form frm in parentForm.MdiChildren)
      {
        if(frm.Name == childForm.Name)
        {
          frm.WindowState = FormWindowState.Maximized;
          frm.Focus();
          isOpen = true;
        }
      }

      if(!isOpen)
      {
        childForm.MdiParent = parentForm;
        childForm.ShowIcon = false;
        childForm.WindowState = FormWindowState.Maximized;
        childForm.Show();
      }
    }

    internal static DialogResult ShowWarningBox( string message, string title = "Peringatan" )
    {
      return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    internal static DialogResult ShowErrorBox( string message, string title = "Error" )
    {
      return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    internal static DialogResult ShowInformationBox( string message, string title = "Informasi" )
    {
      return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    internal static DialogResult ShowYesNoConfirmationBox( string message, string title = "Konfirmasi" )
    {
      return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    internal static DialogResult ShowOkCancelConfirmationBox( string message, string title = "Konfirmasi" )
    {
      return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    }

    public class ClientConnectionModel
    {
        public bool IsRequesting { get; set; }
        public List<string> ConnectionIds { get; set; }
    }

    }
}
