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
using WindowsFormsApp1.MEMBER;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class BookInfoDetail : Form
    {
        string ISBN;
        BaseMember member = BaseMember.GetInstance();
        public BookInfoDetail(string _ISBN, DataGridViewRow bookInfo)
        {
            InitializeComponent();

            ISBN = _ISBN;

            this.lblName.Text += bookInfo.Cells[1].Value.ToString();
            this.lblISBN.Text += bookInfo.Cells[0].Value.ToString();
            this.lblWriter.Text += bookInfo.Cells[2].Value.ToString();
            this.lblTransrator.Text += bookInfo.Cells[3].Value.ToString();
            this.lblPublisher.Text += bookInfo.Cells[4].Value.ToString();
            this.lblType.Text += bookInfo.Cells[6].Value.ToString();
            this.lblOriginnm.Text += bookInfo.Cells[7].Value.ToString();
            this.lblPublicationDate.Text += bookInfo.Cells[9].Value.ToString();
            this.lblPrice.Text += bookInfo.Cells[10].Value.ToString();
            this.lblSummary.Text += "\n"+bookInfo.Cells[8].Value.ToString();
            this.lblIndex.Text += "\n"+bookInfo.Cells[11].Value.ToString();

            RenewDataGridView();

            if (!member.IsLogin)
            {
                this.btnRent.Visible = false;
            }

            if (!member.IsBookAdmin)
            {
                this.btnDelete.Visible = false;
                this.btnReturn.Visible = false;
            }
        }

        private void RenewDataGridView()
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "*" +
                              "FROM " +
                                    "BOOKS " +
                              "WHERE " +
                                    "ISBN=@ISBN ");
            selectSQL.AddParam("ISBN", ISBN);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            dgvBooks.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
        }

        bool IsRented(string CALLNUM)
        {
            SQLObject updateSQL = new BACK.SQLObject();

            // 대여중인지 확인
            updateSQL.setQuery("SELECT " +
                                    "RENT_YN " +
                              "FROM " +
                                    "BOOKS " +
                              "WHERE " +
                                    "CALLNUM = @CALLNUM");
            updateSQL.AddParam("CALLNUM", CALLNUM);
            updateSQL.Go();

            JArray jarray = updateSQL.ToJArray();

            return jarray[0].Value<bool>("RENT_YN");
        }

        void UpdateRENTYN(string CALLNUM, string RENTYN)
        {
            string USER_ID = member.ID;

            SQLObject updateSQL = new SQLObject();
            updateSQL.setQuery("UPDATE " +
                                    "BOOKS " +
                                "SET " +
                                    "RENT_YN=@RENT_YN, " +
                                    "RENT_ID=@USER_ID " +
                                "WHERE " +
                                    "CALLNUM=@CALLNUM");
            updateSQL.AddParam("RENT_YN", RENTYN);
            updateSQL.AddParam("CALLNUM", CALLNUM);
            if (RENTYN.Equals("1"))
                updateSQL.AddParam("USER_ID", USER_ID);
            else
                updateSQL.AddParam("USER_ID", null);
            updateSQL.Go();
        }

        void InsertBOOKRENT(string CALLNUM)
        {
            string BOOK_ID = this.dgvBooks.CurrentRow.Cells[1].Value.ToString();

            SQLObject insertSQL = new SQLObject();
            insertSQL.setQuery("INSERT INTO " +
                                    "`BOOKRENTS` " +
                                    "(`BOOK_ID`, `USER_ID`, `RENT_DT`, `RETURN_DT`, `RENT_DIV`, `RENT_YN`, `OVERDUE_YN`, `RENEW_CNT`) " +
                                "VALUES " +
                                    "(@BOOK_ID, @USER_ID, @RENT_DT, @RETURN_DT, @RENT_DIV, @RENT_YN, @OVERDUE_YN, @RENEW_CNT)");
            insertSQL.AddParam("BOOK_ID", BOOK_ID);
            insertSQL.AddParam("USER_ID", member.ID);
            insertSQL.AddParam("RENT_DT", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertSQL.AddParam("RETURN_DT", (DateTime.Now.AddDays((double)GetRD())).ToString("yyyy-MM-dd HH:mm:ss"));
            insertSQL.AddParam("RENT_DIV", "1");
            insertSQL.AddParam("RENT_YN", "0");
            insertSQL.AddParam("OVERDUE_YN", "0");
            insertSQL.AddParam("RENEW_CNT", "0");
            insertSQL.Go();
        }

        void ReturnBOOKRENT()
        {
            string BOOK_ID = this.dgvBooks.CurrentRow.Cells[1].Value.ToString();
            string USER_ID = this.dgvBooks.CurrentRow.Cells[5].Value.ToString();
            SQLObject insertSQL = new SQLObject();
            insertSQL.setQuery("UPDATE " +
                                    "BOOKRENTS " +
                                "SET " +
                                    "RENT_YN=@RENT_YN " +
                                "WHERE " +
                                    "BOOK_ID=@BOOK_ID " +
                                    "AND USER_ID=@USER_ID");
            insertSQL.AddParam("RENT_YN", "1");
            insertSQL.AddParam("BOOK_ID", BOOK_ID);
            insertSQL.AddParam("USER_ID", USER_ID);
            insertSQL.Go();
        }

        int GetRD()
        {
            SQLObject selectSQL = new SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "OPT_VAL " +
                              "FROM " +
                                    "OPTIONS " +
                              "WHERE " +
                                    "OPT_CD = @OPT_CD");
            selectSQL.AddParam("OPT_CD", "RD");
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();

            return jarray[0].Value<int>("OPT_VAL");
        }

        void DeleteBOOKS(string CALLNUM)
        {
            SQLObject deleteSQL = new SQLObject();
            deleteSQL.setQuery("DELETE FROM " +
                                    "BOOKS " +
                                "WHERE " +
                                    "CALLNUM=@CALLNUM");
            deleteSQL.AddParam("CALLNUM", CALLNUM);
            deleteSQL.Go();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (this.dgvBooks.CurrentRow == null) return;

            string CALLNUM = this.dgvBooks.CurrentRow.Cells[0].Value.ToString();

            // 대여 가능하다면 (아직 빌려가지 않은 책이라면)
            if (IsRented(CALLNUM) == false)
            {
                UpdateRENTYN(CALLNUM, "1"); // transaction 생각해서 수정해야할듯
                InsertBOOKRENT(CALLNUM);
            }
            else
                MessageBox.Show("해당책은 대여중입니다.", "대여");

            RenewDataGridView();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.dgvBooks.CurrentRow == null) return;

            string CALLNUM = this.dgvBooks.CurrentRow.Cells[0].Value.ToString();

            // 대여중이라면 (반납 가능하다면)
            if (IsRented(CALLNUM) == true)
            {
                UpdateRENTYN(CALLNUM, "0");
                ReturnBOOKRENT();
            }
            else
                MessageBox.Show("해당책은 대여중이 아닙니다.", "반납");

            RenewDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvBooks.CurrentRow == null) return;

            string CALLNUM = this.dgvBooks.CurrentRow.Cells[0].Value.ToString();

            // 대여중이라면
            if (IsRented(CALLNUM) == true)
            {
                MessageBox.Show("해당책은 대여중입니다!\n반납 이후에 삭제해주세요", "삭제");
                return;
            }

            DeleteBOOKS(CALLNUM);

            RenewDataGridView();
        }
    }
}
