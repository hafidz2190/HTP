using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using System.Threading;
using System.Linq;

namespace SignalRClient
{
  class Program
  {
    private NotifyIcon notifyIcon1;
    private ContextMenu contextMenu1;
    private MenuItem menuItem1;
    private IContainer components;

    private Queue<string> _message = new Queue<string>();

    public static void Main( string[] args )
    {
      Program pg = new Program();
      Application.Run();
      Console.ReadKey();
    }

    Program()
    {
      Application.Idle += Application_Idle;
      Application.ApplicationExit += Application_ApplicationExit;
      CreateNotifyicon();
    }

    private void CreateNotifyicon()
    {
      components = new Container();
      contextMenu1 = new ContextMenu();
      menuItem1 = new MenuItem();

      // Initialize menuItem1
      menuItem1.Index = 0;
      menuItem1.Text = "E&xit";
      menuItem1.Click += new EventHandler(MenuItem1_Click);

      // Initialize contextMenu1
      contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1 });

      // Create the NotifyIcon.
      notifyIcon1 = new NotifyIcon(components);

      // The Icon property sets the icon that will appear
      // in the systray for this application.
      notifyIcon1.Icon = new Icon(MyResource.Favicon, MyResource.Favicon.Size);

      // The ContextMenu property sets the menu that will
      // appear when the systray icon is right clicked.
      notifyIcon1.ContextMenu = contextMenu1;

      // The Text property sets the text that will be displayed,
      // in a tooltip, when the mouse hovers over the systray icon.
      notifyIcon1.Text = "Console App (Console example)";
      notifyIcon1.Visible = true;

      // Handle the DoubleClick event to activate the form.
      notifyIcon1.DoubleClick += new EventHandler(NotifyIcon1_DoubleClick);
      notifyIcon1.Click += new EventHandler(NotifyIcon1_Click);
    }

    private void NotifyIcon1_Click( object Sender, EventArgs e )
    {

      MessageBox.Show("clicked");
    }

    private void NotifyIcon1_DoubleClick( object Sender, EventArgs e )
    {
      MessageBox.Show("Double clicked");
    }

    private void MenuItem1_Click( object Sender, EventArgs e )
    {
      // Close the form, which closes the application.
      Application.Exit();
    }

    private void Application_Idle( object Sender, EventArgs e )
    {
      var querystringData = new Dictionary<string, string>();

      string key = new Random().Next(1, 100).ToString();
      querystringData.Add("Key", key);

      var hubConnection = new HubConnection("http://10.100.3.104:8885", querystringData);
      IHubProxy myHubProxy = hubConnection.CreateHubProxy("MonitorHub");

      hubConnection.StateChanged += HubConnection_StateChanged;

      try
      {
        hubConnection.Start().Wait();
        myHubProxy.On("addMessage", message => addMessage(message));
        while(true)
        {
          Thread.Sleep(2000);

          Console.WriteLine(string.Format("{0} => {1}", hubConnection.ConnectionId, hubConnection.State.ToString()));
          notifyIcon1.Text = string.Format("{0} => {1}", hubConnection.ConnectionId, hubConnection.State.ToString());

          if(_message.Any())
            Console.WriteLine(string.Format("message:{0}", _message.Dequeue()));
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    public void addMessage( object message )
    {
      //var msg = Newtonsoft.Json.JsonConvert.DeserializeObject(message.ToString());
      _message.Enqueue(message.ToString());
    }

    private void HubConnection_StateChanged( StateChange obj )
    {
      Console.WriteLine(string.Format("State Changed => {0}", obj.NewState));
    }

    private void Application_ApplicationExit( object Sender, EventArgs e )
    {
      notifyIcon1.Visible = false;
    }
  }
}
