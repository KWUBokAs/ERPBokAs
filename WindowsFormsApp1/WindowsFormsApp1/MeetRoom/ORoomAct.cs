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
using System.Drawing;
using System.Windows.Forms;

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
        public string ReadEndTime(string UI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT DEAD_TIME AS DT " +
                               "FROM OPENROOM_RESERV " +
                               "WHERE USER_ID=@USER_ID");
            selectSQL.AddParam("USER_ID", UI);
            selectSQL.Go();
            try { 
            JArray jarray = selectSQL.ToJArray();

            return jarray[0].Value<string>("DT");
            }
            catch
            {
                return "";
            }           
        }
        public string ReadSeatInf(string UI)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT ROOM_ID as RID, SEAT_ID as SID " +
                               "FROM OPENROOM_RESERV " +
                               "WHERE USER_ID=@USER_ID " +
                               "AND MAGAM_YN=@MAGAM_YN");
            selectSQL.AddParam("USER_ID", UI);
            selectSQL.AddParam("MAGAM_YN", "0");
            selectSQL.Go();

            try
            {
                DataTable DT = selectSQL.ToDataTable();

                string RID = DT.Rows[0]["RID"].ToString().Substring(4, 1);
                string SID = DT.Rows[0]["SID"].ToString();

                string Inf = "제 " + RID + " 열람실 " + SID + " 번 자리를 사용중입니다.";

                return Inf;
            }
            catch
            {
                return "";
            }
        }
        public void AddImage(string RI,PictureBox pic)
        {
            IMGSQLObject iMGSQL = new IMGSQLObject();
            iMGSQL.setQuery("SELECT ROOM_IMG as img " + 
                            "FROM OPENROOM " +
                            "WHERE ROOM_ID=@ROOM_ID");
            iMGSQL.AddParam("ROOM_ID",RI);
            iMGSQL.GoImage2(pic);
        }
    }
}
