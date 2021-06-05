using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Drawing;
using System.Data;



namespace WindowsFormsApp1.MeetRoom
{  
    class SeatAct
    {
      
     
        
        public SeatAct()
        {
            
        }
        public Point ReadSeatPoint(string RI, string SI)
        {   // 자리 포인트 읽어오기 RI = ROOM_ID / SI = SEAT_ID
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT X(SEAT_LOCATION) as Xpos, " +
                               "Y(SEAT_LOCATION) as Ypos " +
                               "FROM OPENROOM_SEAT " +
                               "WHERE ROOM_ID=@ROOM_ID" +
                               "AND SEAT_ID=@SEAT_ID");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();
            //SELECT ASTEXT(SEAT_LOCATION) as point FROM `OPENROOM_SEAT` WHERE ROOM_ID ='OR001' AND SEAT_ID = '1'
            DataTable DT = selectSQL.ToDataTable();
            
            int x = Int32.Parse(DT.Rows[0]["Xpos"].ToString());
            int y = Int32.Parse(DT.Rows[0]["Ypos"].ToString());

            Point p = new Point(x,y);

            return p;
        }
        public bool ReadSeatUsed(string RI, string SI)
        {   // 자리 이용여부 읽어오기 RI = ROOM_ID / SI = SEAT_ID
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT RENT_YN as Used " +
                               "FROM OPENROOM_SEAT " +
                               "WHERE ROOM_ID= @ROOM_ID " +
                               "AND SEAT_ID=@SEAT_ID");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();
            
            JArray jarray = selectSQL.ToJArray();
            int use = jarray[0].Value<int>("Used");

            if (use == 0 )
                return false;
            else
                return true;
        }

    }
   
    
}
