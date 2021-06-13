using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace WindowsFormsApp1.MeetRoom
{
    class SeatRrvAct
    {
        public string GetName(string RI,string SI)
        {
            SQLObject findID = new BACK.SQLObject();
            findID.setQuery("SELECT USER_ID " + 
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID ");
            findID.AddParam("ROOM_ID", RI);
            findID.AddParam("SEAT_ID", SI);
            findID.Go();

            JArray Namearray = findID.ToJArray();
            string UI = Namearray[0].Value<string>("USER_ID");

            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT NAME " +
                               "FROM USER " +
                               "WHERE USER_ID= @USER_ID "
                               );
            selectSQL.AddParam("USER_ID", UI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            string name = jarray[0].Value<string>("NAME");

            
                return name; 
        }
        public string GetTime(string RI,string SI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT DEAD_TIME " +
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID ");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            string time = jarray[0].Value<string>("DEAD_TIME");

            return time;
        }
        public string GetExtend(string RI, string SI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT EXTEND " +
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID ");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            string extend = jarray[0].Value<string>("EXTEND");

            return extend;
        }
        public string GetUserID(string RI, string SI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT USER_ID " +
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID ");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            string UID = jarray[0].Value<string>("USER_ID");

            return UID;
        }
        public void UpExtend(string RI, string SI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT EXTEND " +
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID ");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            int extend = jarray[0].Value<int>("EXTEND");

            SQLObject updateSQL = new BACK.SQLObject();
            updateSQL.setQuery("UPDATE OPENROOM_RESERV " +
                                "SET EXTEND=@EXTEND " +
                                "WHERE ROOM_ID=@ROOM_ID " +
                                "AND SEAT_ID=@SEAT_ID");
            updateSQL.AddParam("EXTEND", (extend + 1).ToString());
            updateSQL.AddParam("ROOM_ID", RI);
            updateSQL.AddParam("SEAT_ID", SI);
            updateSQL.Go();
        }
        public bool ReadSeatReserveUsed(string UI)
        {   // 자리 이용여부 읽어오기 RI = ROOM_ID / SI = SEAT_ID
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT COUNT(SEAT_ID) AS Used " +
                               "FROM OPENROOM_RESERV " +
                               "WHERE USER_ID= @USER_ID");
            selectSQL.AddParam("USER_ID", UI);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            int canuse = jarray[0].Value<int>("Used");

            if (canuse == 0)
                return true;
            else
                return false;
        }
        public void ExitSeat(string UI,int i)
        {
            SQLObject updateSQLS = new BACK.SQLObject();
            updateSQLS.setQuery("UPDATE OPENROOM_RESERV " +
                                "SET MAGAM_YN=@MAGAM_YN " +
                                "WHERE USER_ID=@USER_ID " +
                                "AND MAGAM_YN=@MAGAM");
            updateSQLS.AddParam("MAGAM_YN", "1");
            updateSQLS.AddParam("USER_ID", UI);
            updateSQLS.AddParam("MAGAM",i.ToString());
            updateSQLS.Go();
        }
    }
}
