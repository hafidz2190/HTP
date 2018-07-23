using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
  public partial class frmTestSignalRConnection : Form
  {
    public frmTestSignalRConnection()
    {
      InitializeComponent();
      this.Load += FrmTestSignalRConnection_Load;
    }

    private void FrmTestSignalRConnection_Load( object sender, EventArgs e )
    {
      Dictionary<string, FormHelper.ClientConnectionModel> connectedClient = FormHelper.ConnectedClient;
      StringBuilder sb = new StringBuilder();
      if(connectedClient.Count > 0)
      {
        foreach(KeyValuePair<string, FormHelper.ClientConnectionModel> client in connectedClient)
        {
          sb.AppendLine("---------------------------------------");
          sb.AppendLine(string.Format("Username: {0}", client.Key));
          for(int iValue = 0; iValue < client.Value.ConnectionIds.Count; iValue++)
          {
                        sb.AppendLine(string.Format("    ConnectionId: {0}", client.Value.IsRequesting));
                        sb.AppendLine(string.Format("    ConnectionId: {0}", client.Value.ConnectionIds[iValue]));
          }
          sb.AppendLine("---------------------------------------");
          sb.AppendLine(string.Empty);
        }
      }

      tbText.Text = sb.ToString();
    }

    private void btnSend_Click( object sender, EventArgs e )
    {
      SendMessage msg = new SendMessage()
      {
        clientId = tbClientID.Text,
        message = tbMessage.Text
      };

      FormHelper.proxy.Invoke("ClientCommand", Newtonsoft.Json.JsonConvert.SerializeObject(msg)).Wait();
    }

    class SendMessage
    {
      public string clientId { get; set; }
      public string message { get; set; }
    }
  }
}
