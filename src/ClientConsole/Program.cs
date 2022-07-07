using System;
using System.Security;
using System.Threading;
using log4net;
using opc.ua.pubsub.dotnet.client;
using opc.ua.pubsub.dotnet.client.common;
using opc.ua.pubsub.dotnet.client.common.Settings;
using Client = opc.ua.pubsub.dotnet.client.Client;
namespace TestClient
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger( typeof( Program ) );



        static void Main( string[] args )
        {
            Log4Net.Init();

            var setting = new Settings();
            setting.Client = new opc.ua.pubsub.dotnet.client.common.Settings.Client();
            setting.Client.BrokerHostname = "localhost";
            setting.Client.DefaultSubscribeTopicName = "#";
            setting.Client.RawDataMode = false;

            var client = new Client( setting, "MyClient" );

            client.Connect();

            // Wait for connection
            while ( !client.IsConnected )
            {
                Logger.Info( "Waiting for Client to Connect" );
                Thread.Sleep( 1000 );
            }

            client.Subscribe( "#" );

            // Wait for end
            while ( true )
            {
                Thread.Sleep( 1000 );
            }
        }
    }
}