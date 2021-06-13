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

namespace WindowsFormsApp1
{
    public partial class Meet : UserControl
    {
        
        public Meet()
        {
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
                string id = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
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

                IMGSQLObject iMGSQL = new IMGSQLObject();
                iMGSQL.setQuery("SELECT ROOM_IMG as img" +
                    " " +
                    "FROM MEETINGROOM " +
                    "WHERE ROOM_ID = #room_id#");
                iMGSQL.AddParam("room_id", id);
                iMGSQL.GoImage2(this.pbRoomImg);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("오류가 발견되었습니다!", "오류가 발생하였습니다.", MessageBoxButtons.OK);
            }
        }
        private void LoadDateList() {
            SQLObject sqlObj = new SQLObject();
            sqlObj.setQuery("SELECT " +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "");
        }
    }
}
