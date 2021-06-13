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
using System.Windows.Forms;

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
                            "SEAT_ID=@SEAT_ID AND " +
                            "MAGAM_YN=@MAGAM_YN");
            findID.AddParam("ROOM_ID", RI);
            findID.AddParam("SEAT_ID", SI);
            findID.AddParam("MAGAM_YN","0");
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
                            "SEAT_ID=@SEAT_ID AND " +
                            "MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.AddParam("MAGAM_YN", "0");
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
                            "SEAT_ID=@SEAT_ID AND " +
                            "MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.AddParam("MAGAM_YN", "0");
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
                            "SEAT_ID=@SEAT_ID AND " +
                            "MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.AddParam("MAGAM_YN", "0");
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            string UID = jarray[0].Value<string>("USER_ID");

            return UID;
        }
        public void UpExtend(string RI, string SI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT EXTEND, DEAD_TIME " +
                            "FROM OPENROOM_RESERV " +
                            "WHERE ROOM_ID=@ROOM_ID AND " +
                            "SEAT_ID=@SEAT_ID AND " +
                            "MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("ROOM_ID", RI);
            selectSQL.AddParam("SEAT_ID", SI);
            selectSQL.AddParam("MAGAM_YN", "0");
            selectSQL.Go();
            //DateTime.Now.AddHours(1);
            //JArray jarray = selectSQL.ToJArray();
            //int extend = jarray[0].Value<int>("EXTEND");

            DataTable DT = selectSQL.ToDataTable();

            int extend = Int32.Parse(DT.Rows[0]["EXTEND"].ToString());
            string Deadtime = DT.Rows[0]["DEAD_TIME"].ToString();

            if (extend <= 3)
            {
                SQLObject updateSQL = new BACK.SQLObject();
                updateSQL.setQuery("UPDATE OPENROOM_RESERV " +
                                    "SET EXTEND=@EXTEND, " +
                                    "DEAD_TIME=@DEAD_TIME " +
                                    "WHERE ROOM_ID=@ROOM_ID " +
                                    "AND SEAT_ID=@SEAT_ID " +
                                    "AND MAGAM_YN=@MAGAM_YN");
                updateSQL.AddParam("EXTEND", (extend + 1).ToString());
                updateSQL.AddParam("DEAD_TIME",DateTime.Parse(Deadtime).AddHours(1).ToString("HH:mm:ss"));
                updateSQL.AddParam("ROOM_ID", RI);
                updateSQL.AddParam("SEAT_ID", SI);
                updateSQL.AddParam("MAGAM_YN","0");
                updateSQL.Go();
            }
            else
                MessageBox.Show("연장은 최대 4회까지만 가능합니다.");
        }
        public bool ReadSeatReserveUsed(string UI)
        {   // 자리 이용여부 읽어오기 RI = ROOM_ID / SI = SEAT_ID
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT COUNT(SEAT_ID) AS Used " +
                               "FROM OPENROOM_RESERV " +
                               "WHERE USER_ID= @USER_ID "+
                               "AND MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("USER_ID", UI);
            selectSQL.AddParam("MAGAM_YN", "0");
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
