using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTServer
{
    public class RawMsg
    {
        [JsonIgnore]
        public byte[] Msg;
        [JsonIgnore]
        public string HexMsg;
        public RawMsg(byte[] msg)
        {
            Msg = msg;
            HexMsg = Utils.ByteArrayToString(Msg);
        }
    }
}
