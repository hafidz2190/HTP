using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ChildForm
{
  public partial class frmMonitoring : Form
  {
    public frmMonitoring()
    {
      InitializeComponent();

      SetUserDataSource();
    }

    private void frmMonitoring_Load( object sender, EventArgs e )
    {
      this.dgvUser.CellContentClick += DgvUser_CellContentClick;
      timer1.Start();
    }

    private void ChangeConnectionStatus( object message )
    {
      throw new NotImplementedException();
    }

    private void dgvUser_CellClick( object sender, DataGridViewCellEventArgs e )
    {
      var senderGrid = (DataGridView)sender;
      var username = senderGrid["Username", e.RowIndex].Value;
      var ipaddress = senderGrid["IP_Address", e.RowIndex].Value;
      //var port = senderGrid["Port", e.RowIndex].Value;

      SetDataSourceNOP(username.ToString());
      SetDetailList(username.ToString());
    }

    private void DgvUser_CellContentClick( object sender, DataGridViewCellEventArgs e )
    {
      var senderGrid = (DataGridView)sender;
      var username = senderGrid["Username", e.RowIndex].Value;
      var ipaddress = senderGrid["IP_Address", e.RowIndex].Value;
      //var port = senderGrid["Port", e.RowIndex].Value;

      if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
      {
        DataGridViewButtonColumn btn = senderGrid.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
        switch(btn.Text)
        {
          case "Restart":
            //try
            //{
            //  var httpCP = (HttpWebRequest)WebRequest.Create($"http://{ipaddress}:{port}" + "/client/restartSender");
            //  RestartRequest request = new RestartRequest { ApplicationName = "POFtpSender.exe" };

            //  var jsonCP = Newtonsoft.Json.JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.Indented);
            //  httpCP.ContentType = "application/json";
            //  httpCP.Method = "POST";
            //  using(var streamWriter = new System.IO.StreamWriter(httpCP.GetRequestStream()))
            //  {
            //    streamWriter.Write(jsonCP);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //  }

            //  var httpResCP = (HttpWebResponse)httpCP.GetResponse();
            //  if(httpResCP.StatusCode == HttpStatusCode.OK)
            //  {
            //    using(var streamReader = new StreamReader(httpResCP.GetResponseStream()))
            //    {
            //      var result = streamReader.ReadToEnd();
            //      RestartResponse response = JsonConvert.DeserializeObject<RestartResponse>(result);
            //      if(response.message.Contains("Sukses"))
            //      {
            //        FormHelper.ShowWarningBox("Sukses mengirimkan perintah restart pada aplikasi client");
            //        SetUserDataSource();
            //      }
            //      else
            //      {
            //        FormHelper.ShowWarningBox("Aplikasi client gagal di-restart");
            //      }
            //    }
            //  }
            //  httpResCP.Close();
            //}
            //catch(Exception ex)
            //{
            //  FormHelper.ShowErrorBox($"Aplikasi client gagal di-restart. {ex.Message}");
            //}
            break;
          case "Refresh":
            //try
            //{
            //  var httpRefresh = (HttpWebRequest)WebRequest.Create($"http://{ipaddress}:{port}" + "/client/getPOApplicationStatus");
            //  httpRefresh.ContentType = "application/json";
            //  httpRefresh.Method = "POST";

            //  using(var httpRespRefresh = (HttpWebResponse)httpRefresh.GetResponse())
            //  {
            //    if(httpRespRefresh.StatusCode == HttpStatusCode.OK)
            //    {
            //      SetUserDataSource();
            //    }
            //    else
            //    {
            //      using(var streamReader = new StreamReader(httpRespRefresh.GetResponseStream()))
            //      {
            //        var result = streamReader.ReadToEnd();
            //        RefreshResponse response = JsonConvert.DeserializeObject<RefreshResponse>(result);
            //        if(response.message.Contains("Sukses"))
            //        {
            //          FormHelper.ShowWarningBox("Sukses mengirimkan perintah restart pada aplikasi client");
            //          List<UserDataGridItem> source = dgvUser.DataSource as List<UserDataGridItem>;
            //          foreach(var item in source)
            //          {
            //            if(string.Compare(item.Username, username.ToString()) == 0)
            //            {
            //              item.Status_Perangkat = true;
            //              break;
            //            }
            //          }

            //          dgvUser.DataSource = source;
            //          dgvUser.Refresh();
            //        }
            //        else
            //        {
            //          FormHelper.ShowWarningBox("Aplikasi client gagal di-restart");
            //        }
            //      }
            //    }
            //    httpRespRefresh.Close();
            //  }
            //}
            //catch(Exception ex)
            //{
            //  FormHelper.ShowWarningBox($"Aplikasi client gagal di-restart. { ex.Message}");
            //}
            break;
          default:
            break;
        }
      }
      else
      {
        SetDataSourceNOP(username.ToString());
        SetDetailList(username.ToString());
      }
    }

    public void SetUserDataSource()
    {
      List<UserClient> listUser = SettingClientBusiness.RetrieveUserClient(string.Empty);
      List<UserDataGridItem> source = new List<UserDataGridItem>();
      Parallel.ForEach(listUser, ( user ) =>
      {
        List<UserActivity> activities = UserActivityBusiness.RetrieveUserActivity(user.Username)
                                                                  .OrderByDescending(m => m.Activity_Date).ToList();

        var firstValueStartUpDetail = activities.Where(m => m.Keterangan.Contains("Startup Apps"));

        var todayStartUpAct = firstValueStartUpDetail.FirstOrDefault().Activity_Date.Date == DateTime.Now.Date ?
                                      firstValueStartUpDetail.FirstOrDefault() : null;

        bool isAppsActivated = false;
        Dictionary<string, FormHelper.ClientConnectionModel> connectedClient = FormHelper.ConnectedClient;

          FormHelper.ClientConnectionModel valueClient;
        if(connectedClient.TryGetValue(user.Username, out valueClient))
        { 
          isAppsActivated = true;
        }

        string ipAddress = "0.0.0.0";
        if(todayStartUpAct != null)
        {
          //isTodayAppRefresh = true;
          ipAddress = todayStartUpAct.Ip_Address;
        }

        source.Add(new UserDataGridItem
        {
          Username = user.Username,
          Webusername = user.Web_Username,
          IP_Address = ipAddress,
          Port = user.Port_Client,
          Status_Perangkat = isAppsActivated
        });
      });

      dgvUser.DataSource = source;
      dgvUser.Refresh();
    }

    private void SetDetailList( string username )
    {
      //throw new NotImplementedException();
    }

    private void SetDataSourceNOP( string username )
    {
      List<UserNOP> source = UserNopBusiness.RetrieveNOPByUsername(username);
      dgvNOP.DataSource = source;
      dgvNOP.Refresh();
    }

    private class UserDataGridItem
    {
      public string Username { get; set; }
      public string Webusername { get; set; }
      public string IP_Address { get; set; }
      public int Port { get; set; }
      public bool Status_Perangkat { get; set; }
      public Image StatusImage
      {
        get
        {
          return this.Status_Perangkat ? (System.Drawing.Image)Properties.Resources.Connected : (System.Drawing.Image)Properties.Resources.Disconnected;
        }
      }

    }

    private class RestartRequest
    {
      public string ApplicationName { get; set; }
    }

    private class RestartResponse
    {
      public string message { get; set; }
    }

    private class RefreshResponse
    {
      public bool IsRunning { get; set; }

      public string message { get; set; }
    }

    private void timer1_Tick( object sender, EventArgs e )
    {
      SetUserDataSource();
    }
  }
}
