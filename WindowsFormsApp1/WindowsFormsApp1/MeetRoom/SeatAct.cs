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
        public void UpdateSeat(string RI, string SI, bool u)
        {
            int use;
            if (u) use = 1;
            else use = 0;
            SQLObject updateSQL = new BACK.SQLObject();
            updateSQL.setQuery("UPDATE OPENROOM_SEAT " +
                                "SET RENT_YN=@RENT_YN " +
                                "WHERE ROOM_ID=@ROOM_ID " +
                                "AND SEAT_ID=@SEAT_ID");
            updateSQL.AddParam("RENT_YN", use.ToString());
            updateSQL.AddParam("ROOM_ID", RI);
            updateSQL.AddParam("SEAT_ID", SI);
            updateSQL.Go();
        }
        public void InsertSeatRsv(string RI, string SI,string UI)
        {   //미결...
            string Deadtime;
            if ((Int32.Parse(DateTime.Now.ToString("HH:mm:ss").Substring(0, 2)) + 2) < 24)
                Deadtime = (Int32.Parse(DateTime.Now.ToString("HH:mm:ss").Substring(0, 2)) + 2).ToString() + DateTime.Now.ToString(":mm:ss");
            else
                Deadtime = (Int32.Parse(DateTime.Now.ToString("HH:mm:ss").Substring(0, 2)) - 22).ToString() + DateTime.Now.ToString(":mm:ss");
            SQLObject insertSQL = new BACK.SQLObject();
            insertSQL.setQuery("INSERT INTO OPENROOM_RESERV " +
                               "(ROOM_ID, SEAT_ID, OPENRENT_ID, USER_ID, RENT_TIME, DEAD_TIME, RENT_DT, MAGAM_YN, EXTEND) " +
                               "VALUES (@ROOM_ID,@SEAT_ID,@OPENRENT_ID ,@USER_ID,@RENT_TIME,@DEAD_TIME,@RENT_DT,'0','0')");
            insertSQL.AddParam("ROOM_ID", RI);
            insertSQL.AddParam("SEAT_ID", SI);
            insertSQL.AddParam("OPENRENT_ID", DateTime.Now.ToString("HH_mm_ss")+UI.Substring(2,2));
            insertSQL.AddParam("USER_ID", UI);
            insertSQL.AddParam("RENT_TIME", DateTime.Now.ToString("HH:mm:ss"));
            insertSQL.AddParam("DEAD_TIME", Deadtime);
            insertSQL.AddParam("RENT_DT", DateTime.Now.ToString("yyyy-MM-dd"));
            insertSQL.Go();
        }

    }
   
    
}
