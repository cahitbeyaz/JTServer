using log4net;
using Newtonsoft.Json;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JTServer
{
    class Program
    {
        static ILog log = LogManager.GetLogger("log");

        static void Main(string[] args)
        {
            short port = 2001;
            var server = new SimpleTcpServer().Start(port);
            server.DataReceived += Server_DataReceived;
            server.StringEncoder = Encoding.ASCII;
            log.Info(string.Format("server started on the port {0}", port));
            Thread.Sleep(24 * 60 * 60 * 1000);
        }



        private static void Server_DataReceived(object sender, Message e)
        {
            MsgHandler handler = new MsgHandler();
            handler.Handle(e.Data);
            if (handler.locationMsg != null && (handler.locationMsg.DataType == "2" || handler.locationMsg.DataType == "3"))
            {
                //respond with (P35)
                e.TcpClient.Client.Send(Encoding.ASCII.GetBytes("(P35)"));
            }


            //log.Info(string.Format("msg received {0}", e.MessageString));
        }

    }
}
