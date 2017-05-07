using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTServer
{
    public class LocationMsg : RawMsg
    {
        public string protocolHead = "";

        public string DeviceID { get; private set; }
        public string ProtocolVersion { get; private set; }
        public string DeviceType { get; private set; }
        public string DataType { get; private set; }
        public int DataLength { get; private set; }
        public string SDate { get; private set; }
        public DateTime Date { get; private set; }
        public string STime { get; private set; }
        public string SLongtitude { get; private set; }
        public string SLatitude { get; private set; }
        public string LocationIndicator { get; private set; }
        public int Direction { get; private set; }
        public string QualityOfGpsSatellite { get; private set; }
        public string VehicleID { get; private set; }
        public string DeviceStatus { get; private set; }
        public string Milage { get; private set; }
        public int BatteryPercentage { get; private set; }
        public string CellIDAndLac { get; private set; }
        public string GsmSignalQuality { get; private set; }
        public string GeoFence { get; private set; }
        public string Reserve { get; private set; }
        public string SerialNumber { get; private set; }
        public int Speed { get; private set; }

        private void parseMsg()
        {
            int currIdx = 0;
            protocolHead = HexMsg.Substring(currIdx, 2); currIdx += 2;
            DeviceID = HexMsg.Substring(currIdx, 10); currIdx += 10;
            ProtocolVersion = HexMsg.Substring(currIdx, 2); currIdx += 2;
            DeviceType = HexMsg.Substring(currIdx, 1); currIdx += 1;
            DataType= HexMsg.Substring(currIdx, 1); currIdx += 1;//if dta type 35 respond with (P35)
            DataLength= Int32.Parse( HexMsg.Substring(currIdx, 4), System.Globalization.NumberStyles.HexNumber); currIdx += 4;
            SDate = HexMsg.Substring(currIdx, 6); currIdx += 6; 
            STime = HexMsg.Substring(currIdx, 6); currIdx += 6; Date = DateTime.ParseExact(SDate+STime, "ddMMyyHHmmss", CultureInfo.InvariantCulture);
            SLatitude = HexMsg.Substring(currIdx, 8); currIdx += 8; SLatitude = string.Format("{0}{1}{2}", SLatitude.Substring(0, 4), ",", SLatitude.Substring(4, 4));
            SLongtitude = HexMsg.Substring(currIdx, 9); currIdx += 9; SLongtitude = string.Format("{0}{1}{2}", SLongtitude.Substring(0, 5), ",", SLongtitude.Substring(5, 4));
            LocationIndicator= HexMsg.Substring(currIdx, 1); currIdx += 1; 
            Speed = Int32.Parse(HexMsg.Substring(currIdx, 2), System.Globalization.NumberStyles.HexNumber); currIdx += 2;
            Direction = Int32.Parse(HexMsg.Substring(currIdx, 2), System.Globalization.NumberStyles.HexNumber); currIdx += 2;
            Milage = HexMsg.Substring(currIdx, 8); currIdx += 8;
            QualityOfGpsSatellite = HexMsg.Substring(currIdx, 2); currIdx += 2;
            VehicleID = HexMsg.Substring(currIdx, 8); currIdx += 8;
            DeviceStatus = HexMsg.Substring(currIdx, 4); currIdx += 4; //todo convert this to inner statuses
            BatteryPercentage = Int32.Parse(HexMsg.Substring(currIdx, 2), System.Globalization.NumberStyles.HexNumber); currIdx += 2;
            CellIDAndLac = HexMsg.Substring(currIdx, 8); currIdx += 8; 
            GsmSignalQuality = HexMsg.Substring(currIdx, 2); currIdx += 2; 
            GeoFence = HexMsg.Substring(currIdx, 2); currIdx += 2; 
            //Reserve = HexMsg.Substring(currIdx, 6); currIdx += 6; 
            //SerialNumber = HexMsg.Substring(currIdx, 2); currIdx += 2; 
        }
        public LocationMsg(byte[] msg) : base(msg)
        {
            parseMsg();
        }
    }
}
