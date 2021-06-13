using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BACK;
using System.Threading;
using WindowsFormsApp1.MEMBER;

namespace WindowsFormsApp1.MeetRoom
{
    public partial class Meet : UserControl
    {
        string id = "MR001";
        string today;
        DataTable dtlDataTable;
        MeetDtl dtl;
        public Meet()
        {
            today = DateTime.Now.Date.ToString("yyyy-MM-dd");
            InitializeComponent();
        }

        public void setQueryWhenLoad() {
            SQLObject bookListFinder = new SQLObject();
            bookListFinder.setQuery("SELECT ROOM_NM as Name, ROOM_ID as ID " +
                "FROM MEETINGROOM " +
                "" +
                "");
            bookListFinder.Go();
            DataTable dt = bookListFinder.ToDataTable();
            
            this.dgvList.DataSource = dt;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.ColumnHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 30;
            this.dgvList.Columns[1].Visible = false;

            this.dtp.Value = DateTime.Now.Date;
        }

        private void Meet_Load(object sender, EventArgs e) {
            setQueryWhenLoad();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //Console.WriteLine("is Clicked Cell");
            //string id = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            //lbRoomName.Text = this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            //SQLObject roomData = new SQLObject();
            //roomData.setQuery("SEELCT ROOM_ID as ID " +
            //    ", ROOM_NM as Name " +
            //    ", MAX_USE_MEM as MAX " +
            //    ", MIN_USE_MEM as MIN " +
            //    ", ROOM_INFO as INFO " +
            //    "FROM MEETINGROOM " +
            //    "WHERE ROOM_ID = #room_id#");
            //roomData.AddParam("room_id", id);
            //roomData.Go();
            //this.lbstcMAX.Text = "최대수용인원(최소수용인원) 명: ";
            //this.panel1.Visible = true;


            //DataTable dt = roomData.ToDataTable();
            //this.lbMEMs.Text = "" + dt.Columns["MAX"].ToString() + "(" + dt.Columns["MIN"].ToString() + ")";
            //this.lbINFO.Text = dt.Columns["INFO"].ToString();

        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e) {
            try { 
                Console.WriteLine("is Clicked Cell");
                id = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbRoomName.Text = this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                SQLObject roomData = new SQLObject();
                roomData.setQuery("SELECT ROOM_ID as ID " +
                    ", ROOM_NM as Name " +
                    ", MAX_USE_MEM as MAX " +
                    ", MIN_USE_MEM as MIN " +
                    ", ROOM_INFO as INFO " +
                    "FROM MEETINGROOM " +
                    "WHERE ROOM_ID = #room_id#");
                roomData.AddParam("room_id", id);
                roomData.Go();
                this.lbstcMAX.Text = "최대수용인원(최소수용인원) 명: ";
                this.panel1.Visible = true;

                DataTable dt = roomData.ToDataTable();
                this.lbMEMs.Text = "" + dt.Rows[0]["MAX"].ToString() + "(" + dt.Rows[0]["MIN"].ToString()+")";
                this.lbINFO.Text = dt.Rows[0]["INFO"].ToString();
                dtlDataTable = dt;
                Console.WriteLine("dtlDataTable = dt");
                IMGSQLObject iMGSQL = new IMGSQLObject();
                iMGSQL.setQuery("SELECT ROOM_IMG as img" +
                    " " +
                    "FROM MEETINGROOM " +
                    "WHERE ROOM_ID = #room_id#");
                iMGSQL.AddParam("room_id", id);
                iMGSQL.GoImage2(this.pbRoomImg);
                panel2.Visible = true;
                dtp.Value = DateTime.Now;
                LoadDateList();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("오류가 발견되었습니다!", "오류가 발생하였습니다.", MessageBoxButtons.OK);
            }
        }
        public void LoadDateList() {
            SQLObject sqlObj = new SQLObject();
            #region QueryRegion
            sqlObj.setQuery("WITH MYTABLE AS (" +
                            "		SELECT ROOM_ID" +
                            "			  , MASTER_ID" +
                            "			  , USERS" +
                            "			  , RENT_TIME" +
                            "			  , DEAD_TIME" +
                            "			  , RENT_DATE" +
                            "			  , MAGAM_YN" +
                            "			  , EXTEND" +
                            "			  , #room_id# AS DEEP" +
                            "			  , RESERV_ID" +
                            "		FROM MEETING_RESERV" +
                            "		WHERE ROOM_ID = #room_id#" +
                            "       AND RENT_DATE = #rent_dt#" +
                            ")" +
                            "" +
                            "SELECT * " +
                            ", #rent_dt# AS RENTDT " +
                            "FROM (" +
                            "		SELECT \"9:00 ~ 10:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"09:00:00\" AS TBD" +
                            "				, \"10:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"09:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"10:00 ~ 11:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"10:00:00\" AS TBD" +
                            "				, \"11:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"10:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"11:00 ~ 12:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"11:00:00\" AS TBD" +
                            "				, \"12:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"11:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"12:00 ~ 13:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"12:00:00\" AS TBD" +
                            "				, \"13:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"12:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"13:00 ~ 14:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"13:00:00\" AS TBD" +
                            "				, \"14:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"13:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"14:00 ~ 15:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"14:00:00\" AS TBD" +
                            "				, \"15:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"14:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"15:00 ~ 16:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"15:00:00\" AS TBD" +
                            "				, \"16:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"15:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"16:00 ~ 17:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"16:00:00\" AS TBD" +
                            "				, \"17:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"16:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"17:00 ~ 18:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"17:00:00\" AS TBD" +
                            "				, \"18:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"17:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"18:00 ~ 19:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"18:00:00\" AS TBD" +
                            "				, \"19:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"18:00:00\"" +
                            "		" +
                            "		UNION ALL" +
                            "		" +
                            "		SELECT \"19:00 ~ 20:00\" AS TIMECHK" +
                            "				, COUNT(*) AS CHK" +
                            "				, NVL(ROOM_ID,MYTABLE.DEEP) AS ROOM_ID" +
                            "				, MASTER_ID" +
                            "				, USERS" +
                            "				, RENT_DATE" +
                            "				, NVL(MAGAM_YN,0) AS MAGAM_YN" +
                            "				, NVL(EXTEND,0) AS EXTEND" +
                            "				, \"19:00:00\" AS TBD" +
                            "				, \"20:00:00\" AS TBA" +
                            "				, RESERV_ID " +
                            "		FROM MYTABLE" +
                            "		WHERE RENT_TIME = \"19:00:00\"		" +
                            ") AS D");

            #endregion
            sqlObj.AddParam("room_id", id);
            sqlObj.AddParam("rent_dt", today);
            sqlObj.Go();
            DataTable dt = sqlObj.ToDataTable();

            dt.Columns.Add("CHKIMG", typeof(Image));
            dt.Columns.Add("ROOM_NM", typeof(string));
            dt.Columns.Add("MAX", typeof(int));
            dt.Columns.Add("MIN", typeof(int));

            foreach (DataRow dr in dt.Rows) {
                Console.WriteLine("dr: "+dr["CHK"].ToString());
                if (dr["CHK"].ToString().Equals("1")) {
                    dr["CHKIMG"] = Properties.Resources.Check;
                } else {
                    dr["CHKIMG"] = null;
                }
                dr["ROOM_NM"] = lbRoomName.Text;
                if(dtlDataTable != null)
                    dr["MAX"] = dtlDataTable.Rows[0]["MAX"];
                if (dtlDataTable != null)
                    dr["MIN"] = dtlDataTable.Rows[0]["MIN"];
            }

            this.dgvReserv.DataSource = dt;
            this.dgvReserv.Columns["ROOM_ID"].Visible = false;
            this.dgvReserv.Columns["MASTER_ID"].Visible = false;
            this.dgvReserv.Columns["USERS"].Visible = false;
            this.dgvReserv.Columns["RENT_DATE"].Visible = false;
            this.dgvReserv.Columns["MAGAM_YN"].Visible = false;
            this.dgvReserv.Columns["EXTEND"].Visible = false;
            this.dgvReserv.Columns["ROOM_NM"].Visible = false;
            this.dgvReserv.Columns["CHK"].Visible = false;
            this.dgvReserv.Columns["CHKIMG"].DefaultCellStyle.NullValue = null;
            this.dgvReserv.RowTemplate.Height = 30;
            this.dgvReserv.Columns["CHKIMG"].Width = 70;
            this.dgvReserv.Columns["TBD"].Visible = false;
            this.dgvReserv.Columns["TBA"].Visible = false;
            this.dgvReserv.Columns["RENTDT"].Visible = false;
            this.dgvReserv.Columns["RESERV_ID"].Visible = false;

            (this.dgvReserv.Columns["CHKIMG"] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void dtp_ValueChanged(object sender, EventArgs e) {
            Console.WriteLine("버튼이 바뀐다고!");
            today = this.dtp.Value.ToString("yyyy-MM-dd");
            LoadDateList();
        }

        private void dgvReserv_CellClick(object sender, DataGridViewCellEventArgs e) {
            BaseMember member = BaseMember.GetInstance();
            DataRow dr = (this.dgvReserv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            
            if (dr["CHK"].ToString().Equals("1")) {
                //예약중이므로 관리자 or 본인
                if(member.IsMeetingRoomAdmin || dr["MASTER_ID"].ToString().Equals(member.ID)) {
                    MeetDtl meetdtl = new MeetDtl(dr, true);
                    meetdtl.meet = this;
                    meetdtl.ShowDialog();
                } else {
                    MessageBox.Show("관리자 혹은 예약 당사자만이 확인할 수 있습니다.");
                }
            } else {
                //예약 안된 상태
                //팝업으로 예약 뜸
                if (!member.IsLogin) {
                    if(MessageBox.Show("해당 기능은 로그인 유저만 사용할 수 있습니다.", "LOGIN ARERT", MessageBoxButtons.OK)==DialogResult.Yes) {
                        
                    }
                } else {
                    //로그인 & 예약 안함 = 예약 팝업
                    MeetDtl meetdtl = new MeetDtl(dr, false);
                    meetdtl.meet = this;
                    meetdtl.ShowDialog();
                }
            }
        }
    }
}
