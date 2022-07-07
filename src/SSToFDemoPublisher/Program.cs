using RabbitMQ.Client;
using System;
using System.IO;

namespace SSoTFDemoPublisher
{
    class Program
    {
        static void Main( String[] args )
        {
            string UserName = "a8000User";

            string Password = "SiemensM";

            string HostName = "localhost";



            //Main entry point to the RabbitMQ .NET AMQP client

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()

            {

                UserName = UserName,

                Password = Password,

                HostName = HostName

            };


            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();

            var properties = model.CreateBasicProperties();
            properties.Persistent = false;


            string projectDirectory = Directory.GetParent( Environment.CurrentDirectory ).Parent.FullName;
            string messagedump = $"{projectDirectory}\\messagedump";
            foreach ( FileInfo f in new DirectoryInfo( messagedump ).GetFiles( "*.txt" ) )
            {
                string mycontent = File.ReadAllText( f.FullName );
                byte[] payload = Convert.FromBase64String( mycontent );
                model.BasicPublish( "amq.topic", "directexchange_key", properties, payload );
                Console.WriteLine( "Message Sent" );
            }


        }
    }
}