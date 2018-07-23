using Microsoft.AspNet.SignalR;
using POProject.API.SignalR.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POProject.API.SignalR.Hubs
{
  public class MonitorHub : Hub
  {
    public override Task OnConnected()
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      if(string.IsNullOrEmpty(key))
        return base.OnConnected();

      ConnectionMap.Add(key, connectionId);

      BroadcastConnectionMap();

      return base.OnConnected();
    }

    public override Task OnDisconnected( bool stopCalled )
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      if(string.IsNullOrEmpty(key))
        return base.OnDisconnected(stopCalled);

      ConnectionMap.Remove(key, connectionId);

      BroadcastConnectionMap();

      return base.OnDisconnected(stopCalled);
    }

    public override Task OnReconnected()
    {
      string key = Context.QueryString["Key"];
      string connectionId = Context.ConnectionId;

      if(string.IsNullOrEmpty(key))
        return base.OnReconnected();

      if(!ConnectionMap.GetConnections(key).Contains(connectionId))
      {
        ConnectionMap.Add(key, connectionId);
        BroadcastConnectionMap();
      }

      return base.OnReconnected();
    }

    public void BroadcastConnectionMap()
    {
      var context = GlobalHost.ConnectionManager.GetHubContext<ServerMonitorHub>();
      context.Clients.All.addMessage(ConnectionMap.GetConnectionMap());
    }

    public void SendMessage( string username, string message )
    {
      var connection = ConnectionMap.GetConnectionMap(username);
      List<string> connValue = connection.Value.ConnectionIds.ToList();

      var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
      for(int iClient = 0; iClient < connValue.Count; iClient++)
      {
        string connID = connValue[iClient];
        context.Clients.User(connID).addMessage(message);
      }
    }
  }
}