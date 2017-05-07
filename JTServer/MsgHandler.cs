using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTServer
{
    public class MsgHandler
    {
        static ILog log = LogManager.GetLogger("log");
        public LocationMsg locationMsg;

        public void Handle(byte[] msg)
        {
            //example gps msg: 2475201509261611002313101503464722331560113555309F00000000002D0500CB206800F064109326381A03
            
            if (msg[0] == 0x24)
            {
                locationMsg = new LocationMsg(msg);
                var jsonLocation = JsonConvert.SerializeObject(locationMsg);
                log.InfoFormat("incoming location parse result {0}", jsonLocation);
            }
            else if (msg[0] == '(')
            {
                //bro buraya gelen P45 mesajında cihazın kilit ile ilgili logları geliyor. onları sen parse edersin. 
                log.Info(string.Format("incoming msg in ascii: {0}", Encoding.ASCII.GetString(msg)));
                //ascii mode
            }

        }
    }
}
