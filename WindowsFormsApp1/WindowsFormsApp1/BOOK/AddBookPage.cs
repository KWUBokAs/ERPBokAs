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
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.BOOK
{
    public partial class AddBookPage : Form
    {
        string ISBN, BOOK_ID, PREV_CALLNUM;
        public AddBookPage(string _ISBN, int mode, string _BOOK_ID, string title)
        {
            InitializeComponent();
            this.ResetText();
            this.Text = title;
            ISBN = _ISBN;
            if (mode == 0) this.btnEdit.Visible = false;
            else if (mode == 1)
            {
                this.btnAdd.Visible = false;
                BOOK_ID = _BOOK_ID;

                SQLObject selectSQL = new SQLObject();
                selectSQL.setQuery("SELECT " +
                                        "CALLNUM, " +
                                        "LOCATION " +
                                   "FROM " +
                                        "BOOKS " +
                                   "WHERE " +
                                        "BOOK_ID=@BOOK_ID");
                selectSQL.AddParam("BOOK_ID", BOOK_ID);
                selectSQL.Go();

                JArray jarray = selectSQL.ToJArray();

                this.txtCallnum.Text = jarray[0].Value<string>("CALLNUM");
                PREV_CALLNUM = jarray[0].Value<string>("CALLNUM");
                this.txtLocation.Text = jarray[0].Value<string>("LOCATION");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string CALLNUM = this.txtCallnum.Text;
            string LOCATION = this.txtLocation.Text;

            // 앞뒤 공백 삭제
            Regex rmFBSpace = new Regex(@"^\s+|\s+$");
            CALLNUM = rmFBSpace.Replace(CALLNUM, "");
            LOCATION = rmFBSpace.Replace(LOCATION, "");

            // 가운데 공백은 단일 공백으로 만듬
            // Ex) "A       B" => "A B"
            Regex multiSpaceToOne = new Regex(@"\s+");
            CALLNUM = multiSpaceToOne.Replace(CALLNUM, " ");
            LOCATION = multiSpaceToOne.Replace(LOCATION, " ");

            if (CALLNUM.Equals(""))
            {
                MessageBox.Show("청구번호를 입력해주세요", "청구번호");
                return;
            }

            // 기존 확인
            SQLObject selectSQL = new SQLObject();
            selectSQL.setQuery("SELECT COUNT(CALLNUM) AS CNT " +
                                  "FROM BOOKS " +
                                  "WHERE CALLNUM=@CALLNUM");
            selectSQL.AddParam("CALLNUM", CALLNUM);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            if(jarray[0].Value<int>("CNT") != 0)
            {
                MessageBox.Show("해당 청구번호를 가진 책은 이미 존재합니다","청구번호");
                return;
            }

            // 추가
            SQLObject insertSQL = new SQLObject();
            insertSQL.setQuery("INSERT INTO " +
                                    "`BOOKS` " +
                                    "(`CALLNUM`, `ISBN`, `RENT_YN`, `RESERV_YN`, `REG_DATE`, `LOCATION`) " +
                                "VALUES " +
                                    "(@CALLNUM, @ISBN, @RENT_YN, @RESERV_YN, @REG_DATE, @LOCATION)");
            insertSQL.AddParam("CALLNUM", CALLNUM);
            insertSQL.AddParam("ISBN", ISBN);
            insertSQL.AddParam("RENT_YN", "0");
            insertSQL.AddParam("RESERV_YN", "0");
            insertSQL.AddParam("REG_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertSQL.AddParam("LOCATION", LOCATION);
            insertSQL.Go();

            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        { 
            string CALLNUM = this.txtCallnum.Text;
            string LOCATION = this.txtLocation.Text;

            // 앞뒤 공백 삭제
            Regex rmFBSpace = new Regex(@"^\s+|\s+$");
            CALLNUM = rmFBSpace.Replace(CALLNUM, "");
            LOCATION = rmFBSpace.Replace(LOCATION, "");

            // 가운데 공백은 단일 공백으로 만듬
            // Ex) "A       B" => "A B"
            Regex multiSpaceToOne = new Regex(@"\s+");
            CALLNUM = multiSpaceToOne.Replace(CALLNUM, " ");
            LOCATION = multiSpaceToOne.Replace(LOCATION, " ");

            if (CALLNUM.Equals(""))
            {
                MessageBox.Show("청구번호를 입력해주세요", "청구번호");
                return;
            }

            // 기존 확인
            SQLObject selectSQL = new SQLObject();
            selectSQL.setQuery("SELECT COUNT(CALLNUM) AS CNT " +
                                  "FROM BOOKS " +
                                  "WHERE CALLNUM=@CALLNUM");
            selectSQL.AddParam("CALLNUM", CALLNUM);
            selectSQL.Go();

            JArray jarray = selectSQL.ToJArray();
            if (!PREV_CALLNUM.Equals(CALLNUM) && jarray[0].Value<int>("CNT") != 0)
            {
                MessageBox.Show("해당 청구번호를 가진 책은 이미 존재합니다", "청구번호");
                return;
            }

            // 업데이트
            SQLObject updateBooksSQL = new BACK.SQLObject();
            updateBooksSQL.setQuery("UPDATE " +
                                    "BOOKS " +
                                "SET " +
                                    "CALLNUM=@CALLNUM, " +
                                    "LOCATION=@LOCATION" +
                                "WHERE " +
                                    "BOOK_ID=@BOOK_ID");

            updateBooksSQL.AddParam("CALLNUM", CALLNUM);
            updateBooksSQL.AddParam("LOCATION", LOCATION);
            updateBooksSQL.AddParam("BOOK_ID", BOOK_ID);

            updateBooksSQL.Go();

            this.Close();
        }
    }
}
