using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using WindowsFormsApp1.BACK;
using System.Data;


namespace WindowsFormsApp1.MeetRoom
{
    class ORoomAct
    {
        public int SeatCounts;
       
        public int ReadRoomCount(string RoomID)
        {   // 원하는 열람실의 자리수를 구함
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT COUNT(SEAT_ID) AS CID " +
                               "FROM OPENROOM_SEAT " +
                               "WHERE ROOM_ID=@ROOM_ID");
            selectSQL.AddParam("ROOM_ID", RoomID);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();

            return jarray[0].Value<int>("CID");
        }
    }
}
