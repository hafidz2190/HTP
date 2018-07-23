using Microsoft.AspNet.SignalR;
using POProject.API.SignalR.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace POProject.API.SignalR.Hubs
{
  public class ServerMonitorHub : Hub
  {
    public override Task OnConnected()
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      BroadcastConnectionMap();

      if(string.IsNullOrEmpty(key))
        return base.OnConnected();

      ServerConnectionMap.Add(key, connectionId);

      return base.OnConnected();
    }

    public override Task OnDisconnected( bool stopCalled )
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      if(string.IsNullOrEmpty(key))
        return base.OnDisconnected(stopCalled);

      ServerConnectionMap.Remove(key, connectionId);

      return base.OnDisconnected(stopCalled);
    }

    public override Task OnReconnected()
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      if(string.IsNullOrEmpty(key))
        return base.OnReconnected();

      if(!ServerConnectionMap.GetConnections(key).Contains(connectionId))
      {
        ServerConnectionMap.Add(key, connectionId);
      }

      return base.OnReconnected();
    }

    public void BroadcastConnectionMap()
    {
      var context = GlobalHost.ConnectionManager.GetHubContext<ServerMonitorHub>();
      context.Clients.All.addMessage(ConnectionMap.GetConnectionMap());
    }

    public void ClientCommand(string message)
    {
      var json = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestMessage>(message);



      var connection = ConnectionMap.GetConnectionMap(json.clientId);

        if(connection.Value.IsRequesting)
        {
                return;
        }

        connection.Value.IsRequesting = true;

      System.Collections.Generic.List<string> connValue = connection.Value.ConnectionIds.ToList();

      var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
      for(int iClient = 0; iClient < connValue.Count; iClient++)
      {
        string connID = connValue[iClient];
        context.Clients.Client(connID).addMessage(json.message);
      }
    }

    class RequestMessage
    {
      public string clientId { get; set; }
      public string message { get; set; }
    }
  }
}