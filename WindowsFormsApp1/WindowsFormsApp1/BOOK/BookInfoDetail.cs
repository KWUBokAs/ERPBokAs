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

namespace WindowsFormsApp1.BOOK
{
    public partial class BookInfoDetail : Form
    {
        string ISBN;
        BaseMember member = BaseMember.GetInstance();
        public BookInfoDetail(DataGridViewRow bookInfo)
        {
            InitializeComponent();

            ISBN = bookInfo.Cells[0].Value.ToString();

            this.lblISBN.Text += bookInfo.Cells[0].Value.ToString();
            this.lblName.Text += bookInfo.Cells[1].Value.ToString();
            this.lblWriter.Text += bookInfo.Cells[2].Value.ToString();
            this.lblTransrator.Text += bookInfo.Cells[3].Value.ToString();
            this.lblPublisher.Text += bookInfo.Cells[4].Value.ToString();
            this.lblType.Text += bookInfo.Cells[5].Value.ToString();
            this.lblOriginnm.Text += bookInfo.Cells[6].Value.ToString();
            this.lblPublicationDate.Text += bookInfo.Cells[7].Value.ToString();
            this.lblPrice.Text += bookInfo.Cells[8].Value.ToString();

            // DataGridView에 BOOKS 목록 표시
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "SUMMARY, " +
                                    "INDEX_LIST, " +
                                    "IMG_TYPE, " +
                                    "IMG_URL, " +
                                    "BOOK_IMG " +
                              "FROM " +
                                    "BOOKINFO " +
                              "WHERE " +
                                    "ISBN=@ISBN ");
            selectSQL.AddParam("ISBN", ISBN);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            if (jarray.Count == 0) Close();
            this.txtSummary.Text += jarray[0].Value<string>("SUMMARY").ToString();
            this.txtIndexList.Text += jarray[0].Value<string>("INDEX_LIST").ToString();

            //int IMG_TYPE = jarray[0].Value<int>("IMG_TYPE");
            //switch (IMG_TYPE)
            //{
            //    case 0:
            //        // default img
            //        break;
            //    case 1:
            //        // URL 방식
            //        break;
            //    case 2:
            //        // BLOB 방식
            //        break;
            //    default:
            //        // default img
            //        break;
            //}

            RenewDataGridView();

            if (!member.IsLogin || member.IsBadMember)
            {
                this.btnRent.Visible = false;
            }
            else
            {
                this.btnRent.Visible = true;
            }

            if (!member.IsBookAdmin)
            {
                this.btnDelete.Visible = false;
                this.btnReturn.Visible = false;
                this.btnAdd.Visible = false;
                this.btnEdit.Visible = false;
            }
            else
            {
                this.btnDelete.Visible = true;
                this.btnReturn.Visible = true;
                this.btnAdd.Visible = true;
                this.btnEdit.Visible = true;
            }
        }

        private bool CheckRentMore()
        {
            SQLObject selectBadSQL = new BACK.SQLObject();
            selectBadSQL.setQuery("SELECT " +
                                    "COUNT(*) AS CNT " +
                              "FROM " +
                                    "BOOKRENTS " +
                              "WHERE " +
                                    "RENT_YN=@RENT_YN AND " +
                                    "USER_ID=@USER_ID");
            selectBadSQL.AddParam("RENT_YN", "0");
            selectBadSQL.AddParam("USER_ID", member.ID);
            selectBadSQL.Go();
            JArray jarray = selectBadSQL.ToJArray();
            int cnt = jarray[0].Value<int>("CNT");

            SQLObject selectMaxSQL = new BACK.SQLObject();
            selectMaxSQL.setQuery("SELECT " +
                                    "OPT_VAL " +
                              "FROM " +
                                    "OPTIONS " +
                              "WHERE " +
                                    "OPT_CD=@OPT_CD");
            selectMaxSQL.AddParam("OPT_CD", "RM");
            selectMaxSQL.Go();
            jarray = selectMaxSQL.ToJArray();
            int max = jarray[0].Value<int>("OPT_VAL");

            return (max > cnt);
        }

        private void RenewDataGridView()
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "CALLNUM AS 청구번호, " +
                                    "BOOK_ID AS 책_ID, " +
                                    "ISBN, " +
                                    "RENT_YN AS 대여가능여부, " +
                                    //"RESERV_YN AS 예약가능여부, " +
                                    "RENT_ID AS 대여자ID, " +
                                    "REG_DATE AS 등록일, " +
                                    "LOCATION AS 위치 " +
                              "FROM " +
                                    "BOOKS " +
                              "WHERE " +
                                    "ISBN=@ISBN ");
            selectSQL.AddParam("ISBN", ISBN);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            foreach(var e in jarray)
            {
                if (e["대여가능여부"].ToString().Equals("True"))
                    e["대여가능여부"] = "대여중";
                else if (e["대여가능여부"].ToString().Equals("False"))
                    e["대여가능여부"] = "대여가능";

                //if (e["예약가능여부"].ToString().Equals("True"))
                //    e["예약가능여부"] = "예약중";
                //else if (e["예약가능여부"].ToString().Equals("False"))
                //    e["예약가능여부"] = "예약가능";
            }

            dgvBooks.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
            if(dgvBooks != null && dgvBooks.Columns.Count > 0)
            {
                dgvBooks.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        bool IsRented(string CALLNUM)
        {
            SQLObject selectSQL = new BACK.SQLObject();

            // 대여중인지 확인
            selectSQL.setQuery("SELECT " +
                                    "RENT_YN " +
                              "FROM " +
                                    "BOOKS " +
                              "WHERE " +
                                    "CALLNUM = @CALLNUM");
            selectSQL.AddParam("CALLNUM", CALLNUM);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();

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
                updateSQL.AddParam("USER_ID", "");
            updateSQL.Go();
        }

        void InsertBOOKRENT(string CALLNUM)
        {
            string BOOK_ID = this.dgvBooks.CurrentRow.Cells[1].Value.ToString();
            Options options = Options.GetInstance();
            SQLObject insertSQL = new SQLObject();
            insertSQL.setQuery("INSERT INTO " +
                                    "`BOOKRENTS` " +
                                    "(`BOOK_ID`, `USER_ID`, `RENT_DT`, `RETURN_DT`, `RENT_DIV`, `RENT_YN`, `OVERDUE_YN`, `RENEW_CNT`) " +
                                "VALUES " +
                                    "(@BOOK_ID, @USER_ID, @RENT_DT, @RETURN_DT, @RENT_DIV, @RENT_YN, @OVERDUE_YN, @RENEW_CNT)");
            insertSQL.AddParam("BOOK_ID", BOOK_ID);
            insertSQL.AddParam("USER_ID", member.ID);
            insertSQL.AddParam("RENT_DT", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertSQL.AddParam("RETURN_DT", (DateTime.Now.AddDays((double)options.RD)).ToString("yyyy-MM-dd 23:59:59"));
            insertSQL.AddParam("RENT_DIV", "1");
            insertSQL.AddParam("RENT_YN", "0");
            insertSQL.AddParam("OVERDUE_YN", "0");
            insertSQL.AddParam("RENEW_CNT", "0");
            insertSQL.Go();
        }

        void ReturnBOOKRENT()
        {
            string BOOK_ID = this.dgvBooks.CurrentRow.Cells[1].Value.ToString();
            string USER_ID = this.dgvBooks.CurrentRow.Cells[4].Value.ToString();
            Console.WriteLine(USER_ID);
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

        bool IsOverdued(string BOOK_ID)
        {
            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "* " +
                              "FROM " +
                                    "BOOKRENTS " +
                              "WHERE " +
                                    "BOOK_ID = @BOOK_ID AND " +
                                    "RENT_YN='0'");
            selectSQL.AddParam("BOOK_ID", BOOK_ID);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            
            if (jarray[0].Value<int>("OVERDUE_YN") == 1)//연체됐다면
                return true;

            return false;
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (this.dgvBooks.CurrentRow == null) return;
            if (!CheckRentMore())
            {
                MessageBox.Show("이 이상 대여할 수 없습니다\n" +
                    "다른 책을 대여하려면 기존에 대여한 책을 반납해주세요", "대여한도");
                return;
            }

            string CALLNUM = this.dgvBooks.CurrentRow.Cells[0].Value.ToString();

            // 대여 가능하다면 (아직 빌려가지 않은 책이라면)
            if (IsRented(CALLNUM) == false)
            {
                UpdateRENTYN(CALLNUM, "1"); // transaction 생각해서 수정해야할듯
                InsertBOOKRENT(CALLNUM);
                MessageBox.Show("대여했습니다", "대여");
            }
            else
                MessageBox.Show("해당책은 대여중입니다", "대여");

            RenewDataGridView();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (this.dgvBooks.CurrentRow == null) return;

            string CALLNUM = this.dgvBooks.CurrentRow.Cells[0].Value.ToString();
            string BOOK_ID = this.dgvBooks.CurrentRow.Cells[1].Value.ToString();

            // 대여중이라면 (반납 가능하다면)
            if (IsRented(CALLNUM) == true)
            {
                if(IsOverdued(BOOK_ID) == true)
                {
                    MessageBox.Show("책 ID : " + BOOK_ID + " 은 연체된 도서입니다.\n사서에게 문의해 주시기 바랍니다..", "반납");
                    return;
                }
                UpdateRENTYN(CALLNUM, "0");
                ReturnBOOKRENT();
                MessageBox.Show("반납했습니다", "반납");
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

            MessageBox.Show("삭제했습니다", "삭제");

            RenewDataGridView();
        }

        public void AddBookPage_Closing(object sender, FormClosedEventArgs e) { RenewDataGridView(); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int addMode = 0;
            AddBookPage abp = new AddBookPage(ISBN, addMode, "", "책 추가");
            abp.FormClosed += AddBookPage_Closing;
            abp.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int editMode = 1;
            if (this.dgvBooks.CurrentRow == null)
                return;

            string BOOK_ID =  this.dgvBooks.CurrentRow.Cells[1].Value.ToString();
            AddBookPage abp = new AddBookPage(ISBN, editMode, BOOK_ID, "책 수정");
            abp.FormClosed += AddBookPage_Closing;
            abp.ShowDialog();
        }
    }
}
