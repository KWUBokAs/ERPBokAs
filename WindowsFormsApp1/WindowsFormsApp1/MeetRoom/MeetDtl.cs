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
using System.IO;

namespace WindowsFormsApp1.MeetRoom {
    public partial class MeetDtl : Form {
        DataRow dr;
        bool isViewMode = false;
        public Meet meet;
        bool isUpdate = false;
        DataTable dt;
        public MeetDtl(DataRow mdr, bool isviewmode) {
            InitializeComponent();
            this.dr = mdr;
            isViewMode = isviewmode;
            loadScene();
            
        }

        private void loadScene() {
            lbLoc.Text = dr["ROOM_NM"].ToString();
            tbID.ReadOnly = isViewMode;
            dgvIDs.ReadOnly = isViewMode;
            btnAdd.Enabled = !isViewMode;
            BtnDel.Enabled = !isViewMode;
            if (isViewMode) {
                btnReservNCan.Text = "취소";
            } else {
                btnReservNCan.Text = "예약";
            }
            btnExtend.Visible = isViewMode;
            btnEditNDel.Visible = isViewMode;
            lbWarn.Visible = false;
            this.dgvIDs.RowHeadersVisible = false;
            //this.dgvIDs.ColumnHeadersVisible = false;

            string val = "";
            if(isViewMode)
                val = dr["USERS"].ToString();

            dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("VERIFY");

            dgvIDs.DataSource = dt;
            if (isViewMode) {
                tbID.Text = (string)dr["MASTER_ID"];
            } else {
                tbID.Text = MEMBER.BaseMember.GetInstance().ID;
            }
            this.dgvIDs.Columns["VERIFY"].Visible = false;
            using(StringReader reader = new StringReader(val)) {
                string line;
                while((line = reader.ReadLine())!= null) {
                    dt.Rows.Add(line,"0");
                }

            }

        }

        

        private void btnEditNDel_Click(object sender, EventArgs e) {
            if (dr["MAGAM_YN"].ToString().Equals("1")) {
                MessageBox.Show("마감되어 변경하실 수 없습니다.");
                return;
            }
            isUpdate = true;
            tbID.ReadOnly = false;
            dgvIDs.ReadOnly = false;
            btnAdd.Enabled = true;
            BtnDel.Enabled = true;
            btnReservNCan.Text = "예약";
            btnExtend.Visible = true;
            btnEditNDel.Visible = true;
            lbWarn.Visible = false;
        }

        private void btnExtend_Click(object sender, EventArgs e) {
            SQLObject sqlObj = new SQLObject();
            sqlObj.setQuery("SELECT COUNT(*) AS CNT " +
                "            FROM MEETING_RESERV " +
                "            WHERE  RENT_TIME = #rent_time# " +
                "                   AND MAGAM_YN = \"0\" " +
                "                   AND RENT_DATE = #rent_date# " +
                "                   AND ROOM_ID = #room_id# ");
            sqlObj.AddParam("rent_time", (string)dr["TBA"]);
            sqlObj.AddParam("rent_date", (string)dr["RENTDT"]);
            sqlObj.AddParam("room_id", (string)dr["ROOM_ID"]);
            sqlObj.Go();
            if (sqlObj.ToDataTable().Rows[0]["CNT"].ToString().Equals("0")) {
                SQLObject sqlObj1 = new SQLObject();
                sqlObj1.setQuery("INSERT INTO MEETING_RESERV " +
                                                "(RESERV_ID, ROOM_ID, MASTER_ID, USERS, RENT_TIME, DEAD_TIME, RENT_DATE, MAGAM_YN, EXTEND) " +
                                                "VALUE (#reserv_id#, #room_id#, #master_id#, #users#, #rent_time#, #dead_time#, #rent_date#, #magam_yn#, #extend#) ");

                SQLObject countsql = new SQLObject();
                countsql.setQuery("SELECT count(*) as CNT " +
                                   "FROM MEETING_RESERV " +
                                   "WHERE ROOM_ID = #room_id2#" +
                                   "AND RENT_DATE = #rent_dt2#");
                countsql.AddParam("room_id2", (string)dr["ROOM_ID"]);
                countsql.AddParam("rent_dt2", (string)dr["RENTDT"]);
                countsql.Go();
                string rservid = (Int32.Parse(countsql.ToDataTable().Rows[0]["CNT"].ToString()) + 1).ToString();
                sqlObj1.AddParam("reserv_id", rservid);
                sqlObj1.AddParam("room_id", (string)dr["ROOM_ID"]);
                sqlObj1.AddParam("master_id", tbID.Text);
                sqlObj1.AddParam("rent_time", (string)dr["TBA"]);
                string time = dr["TBA"].ToString();
                time = time.Substring(0, 2);
                time = (Int32.Parse(time) + 1).ToString() + ":00:00";
                sqlObj1.AddParam("dead_time", time);
                sqlObj1.AddParam("rent_date", (string)dr["RENTDT"]);
                sqlObj1.AddParam("magam_yn", "0");
                sqlObj1.AddParam("extend", "1");
                sqlObj1.AddParam("users", dgvToString());
                sqlObj1.Go();
                MessageBox.Show("연장 완료 되었습니다.");
                this.Close();
            } else {
                MessageBox.Show("연장하실 수 없습니다.");
            }
        }
        private bool isCompleteData() {
            dgvIDs_RowLeave(this.dgvIDs,new DataGridViewCellEventArgs(0, this.dgvIDs.Rows.Count - 1));
            deleteBlank();
            if (lbWarn.Visible) {
                MessageBox.Show("대표 ID 가 맞지 않습니다!");
                return false;
            }
            if (dt.Rows.Count+1 > (int)dr["MAX"] || dt.Rows.Count+1 < (int)dr["MIN"]) {
                MessageBox.Show("인원 수가 맞지 않습니다!");
                return false;
            }
            bool check = true;
            foreach(DataRow ddr in dt.Rows) {
                if (ddr["VERIFY"].ToString().Equals("0")) {
                    check = false;
                }
            }
            if (!check) {
                MessageBox.Show("인증 받지 않은 ID 가 있습니다.");
                return false;
            }
                
            return true;
        }
        private string dgvToString() {
            string strdata = "";
            foreach(DataRow ddr in dt.Rows) {
                strdata += ddr["ID"].ToString();
                strdata += "\n";
            }
            return strdata;
        }
        private void btnReservNCan_Click(object sender, EventArgs e) {
            //예약 or 취소
            if (isViewMode && !isUpdate) {
                try {
                    SQLObject obj = new SQLObject();
                    obj.setQuery("DELETE FROM MEETING_RESERV " +
                        "WHERE RESERV_ID = #reserv_id#");
                    obj.AddParam("reserv_id",dr["RESERV_ID"].ToString());
                    obj.Go();
                    MessageBox.Show("취소 되었습니다!");
                    this.Close();
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message +"\n"+ex.StackTrace);
                    MessageBox.Show("오류가 발생했습니다.");
                }
            } else {
                if (!isCompleteData()) {
                    return;
                } else {
                    try {
                        SQLObject sqlObj = new SQLObject();
                        if (!isUpdate) {
                            try {
                                sqlObj.setQuery("INSERT INTO MEETING_RESERV " +
                                                "(RESERV_ID, ROOM_ID, MASTER_ID, USERS, RENT_TIME, DEAD_TIME, RENT_DATE, MAGAM_YN, EXTEND) " +
                                                "VALUE (#reserv_id#, #room_id#, #master_id#, #users#, #rent_time#, #dead_time#, #rent_date#, #magam_yn#, #extend#) ");

                                SQLObject countsql = new SQLObject(); 
                                countsql.setQuery("SELECT count(*) as CNT " +
                                    "FROM MEETING_RESERV " +
                                    "WHERE ROOM_ID = #room_id2#" +
                                    "AND RENT_DATE = #rent_dt2#");
                                countsql.AddParam("room_id2", (string)dr["ROOM_ID"]);
                                countsql.AddParam("rent_dt2", (string)dr["RENTDT"]);
                                countsql.Go();
                                string rservid = (Int32.Parse(countsql.ToDataTable().Rows[0]["CNT"].ToString()) + 1).ToString();
                                sqlObj.AddParam("reserv_id", rservid);
                                sqlObj.AddParam("room_id", (string)dr["ROOM_ID"]);
                                sqlObj.AddParam("master_id", tbID.Text);
                                sqlObj.AddParam("rent_time", (string)dr["TBD"]);
                                sqlObj.AddParam("dead_time", (string)dr["TBA"]);
                                sqlObj.AddParam("rent_date", (string)dr["RENTDT"]);
                                sqlObj.AddParam("magam_yn", "0");
                                sqlObj.AddParam("extend", "0");
                                sqlObj.AddParam("users", dgvToString());
                                sqlObj.Go();
                                MessageBox.Show("예약 되었습니다!");
                                this.Close();
                            }
                            catch(Exception ex) {
                                MessageBox.Show("오류가 발생했습니다.");
                                Console.WriteLine(ex.Message +"\n"+ex.StackTrace);
                            }
                        } else {
                            try { 
                                sqlObj.setQuery("UPDATE MEETING_RESERV " +
                                    "            SET " +
                                    "            MASTER_ID = #master_id#" +
                                    "            USERS = #users# ");
                                sqlObj.AddParam("master_id", tbID.Text);
                                sqlObj.AddParam("USERS", dgvToString());
                                sqlObj.Go();
                                MessageBox.Show("변경 되었습니다!");
                                this.Close();
                            }
                            catch (Exception ex) {
                                MessageBox.Show("오류가 발생했습니다.");
                                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                            }
                        }

                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message + "\n"+ex.StackTrace);
                        MessageBox.Show("오류가 발생했습니다.");
                    }
                }
                
            }
        }

        private void tbID_Leave(object sender, EventArgs e) {
            SQLObject sqlObj = new SQLObject();
            sqlObj.setQuery("SELECT count(*) as cnt " +
                            "FROM USER " +
                            "WHERE USER_ID = #user_id#");
            sqlObj.AddParam("user_id", tbID.Text);
            sqlObj.Go();
            if (sqlObj.ToDataTable().Rows[0]["cnt"].ToString().Equals("0")) {
                lbWarn.Visible = true;
            } else {
                lbWarn.Visible = false;
            }
        }

        private void MeetDtl_FormClosed(object sender, FormClosedEventArgs e) {

            meet.LoadDateList();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            DataRow dtr= dt.Rows.Add("","0");
            this.dgvIDs.Focus();
            this.dgvIDs.CurrentCell = this.dgvIDs.Rows[this.dgvIDs.RowCount - 1].Cells[0];
        }

        private void BtnDel_Click(object sender, EventArgs e) {
            try {
                dt.Rows.RemoveAt(dgvIDs.CurrentCell.RowIndex);
            }
            catch(Exception ex) {
                
            }
        }

        private void dgvIDs_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void dgvIDs_RowLeave(object sender, DataGridViewCellEventArgs e) {
            string val1 = "";
            try {
                val1 = this.dgvIDs.CurrentCell.Value.ToString();
            }
            catch {
                val1 = "";
            }
            if (!string.IsNullOrWhiteSpace(val1)) {
                string val = this.dgvIDs.CurrentCell.Value.ToString();
                SQLObject sqlObj = new SQLObject();
                sqlObj.setQuery("SELECT COUNT(*) AS CNT " +
                    "            FROM USER " +
                    "            WHERE USER_ID = #user_id# ");
                sqlObj.AddParam("user_id", val);
                sqlObj.Go();
                if (sqlObj.ToDataTable().Rows[0]["CNT"].ToString().Equals("0")) {
                    dt.Rows[this.dgvIDs.CurrentCell.RowIndex]["VERIFY"] = "0";
                    this.dgvIDs.CurrentCell.Style.ForeColor = Color.Red;
                } else {
                    dt.Rows[this.dgvIDs.CurrentCell.RowIndex]["VERIFY"] = "1";
                    this.dgvIDs.CurrentCell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void dgvIDs_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                dt.Rows.Add();
                this.dgvIDs.Focus();
                this.dgvIDs.CurrentCell = this.dgvIDs.Rows[this.dgvIDs.RowCount - 1].Cells[0];
            }
        }
        private void deleteBlank() {
            int cnt = dt.Rows.Count;
            int i = 0;
            while(i < cnt) {
                if(dt.Rows[i]["ID"] == null) {
                    dt.Rows.RemoveAt(i);
                    cnt--;
                    continue;
                } else if(String.IsNullOrWhiteSpace(dt.Rows[i]["ID"].ToString())){
                    dt.Rows.RemoveAt(i);
                    cnt--;
                    continue;
                } else {
                    i++;
                }
            }
        }
    }
}
