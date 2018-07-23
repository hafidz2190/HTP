using Microsoft.AspNet.SignalR.Client;
using Pemkot.OnlineMonitoringApp.ChildForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void monitoringToolStripMenuItem_Click( object sender, EventArgs e )
    {
      //FormHelper.ShowForm(this, new frmMonitoring());
      FormHelper.ShowForm(this, new frmTestSignalRConnection());
    }

    private void FormMain_Load( object sender, EventArgs e )
    {
      SignalRConnection();
    }

    private void SignalRConnection()
    {
      try
      {
        FormHelper.HubConnect = new HubConnection("http://localhost:8885/signalr");
        FormHelper.proxy = FormHelper.HubConnect.CreateHubProxy("ServerMonitorHub");

        FormHelper.proxy.On("addMessage", message => AddMessage(message));

        FormHelper.HubConnect.Start().Wait();
        lblStatusSignalR.Text = "SignalR Status : Connected";

      }
      catch
      {
        lblStatusSignalR.Text = "SignalR Status : Not Connected";
      }
    }

    private void AddMessage( object message )
    {
      FormHelper.ConnectedClient = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, FormHelper.ClientConnectionModel>>(message.ToString());
    }

    private void refreshSignalRConnectionToolStripMenuItem_Click( object sender, EventArgs e )
    {
      SignalRConnection();
    }
  }
}
