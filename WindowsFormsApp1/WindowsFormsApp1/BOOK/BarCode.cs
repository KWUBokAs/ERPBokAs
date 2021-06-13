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
using Newtonsoft.Json;
using WindowsFormsApp1.MEMBER;

namespace WindowsFormsApp1.BOOK
{
    public partial class BarCode : UserControl
    {
        const int BOOKNUMBER_SIZE = 6;
        private Form3 parent;
        private string behave;//대여인지 반납인지
        public BarCode(Form3 form3)
        {
            parent = form3;
            form3.BarcodeClick_Event += SetTitle;
            InitializeComponent();
            SetTitle(null, null);
        }
        private void SetTitle(object sender, EventArgs e)
        {
            labTitle.Text = parent.BarcodePageTitle;
            if (labTitle.Text == "도서 대여")
            {
                behave = "대여";
            }
            else behave = "반납";
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            string BOOK_ID = ((TextBox)sender).Text;
            if (BOOK_ID.Length < BOOKNUMBER_SIZE) return;
            ((TextBox)sender).Text = "";
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT " +
                                        "RENT_YN " +
                                  "FROM " +
                                        "BOOKS " +
                                  "WHERE " +
                                        "BOOK_ID=@BOOK_ID");
                selectSQL.AddParam("BOOK_ID", BOOK_ID);
                selectSQL.Go();
                JArray jarray = selectSQL.ToJArray();
                if (jarray.Count == 0)
                {
                    MessageBox.Show("책 ID : " + BOOK_ID + " 은 저희 도서관에 등록된 도서가 아닙니다", behave);
                    return;
                }
                bool RENT_YN = jarray[0].Value<bool>("RENT_YN");
                if (labTitle.Text == "도서 반납")
                {
                    
                    ReturnBook(BOOK_ID, RENT_YN);
                }
                else//도서 대출
                {
                    if (RENT_YN)
                    {
                        MessageBox.Show("해당책은 대여중입니다", "대여");
                        return;
                    }
                    RentBook(BOOK_ID);
                }
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
            }
        }
        /// <summary>
        /// 해당책이 대여중인지 아닌지 반환한다.
        /// true가 대여중 / false 이 대여가능 이라는 소리
        /// </summary>
        /// <param name="CALLNUM"></param>
        /// <returns></returns>
        
        private void RentBook(string BOOK_ID)
        {
            BaseMember member = BaseMember.GetInstance();
            Options options = Options.GetInstance();
            if (member.CanRentBook)//책을 빌릴수 있을 때만 대여한다.
            {
                try
                {                    
                    if(MessageBox.Show("책 ID : " + BOOK_ID + " - 해당 도서를 대여하시겠습니까?", "대여", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SQLObject updateSQL = new SQLObject();
                        updateSQL.setQuery("UPDATE " +
                                                "BOOKS " +
                                            "SET " +
                                                "RENT_YN='1', " +
                                                "RENT_ID=@RENT_ID " +
                                            "WHERE " +
                                                "BOOK_ID=@BOOK_ID");
                        updateSQL.AddParam("BOOK_ID", BOOK_ID);
                        updateSQL.AddParam("RENT_ID", member.ID);
                        updateSQL.Go();

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
                        MessageBox.Show("대여했습니다", "대여");
                    }
                }
                catch
                {
                    MessageBox.Show("DB접속이 불안정합니다.", "대여");
                }
            }
            else
            {
                MessageBox.Show("이 이상 대여할 수 없습니다\n" +
                    "다른 책을 대여하려면 기존에 대여한 책을 반납해주세요", "대여한도");
            }
        }
        private void ReturnBook(string BOOK_ID, bool Rent_YN)
        {
            SQLObject selectSQL;
            JArray jarray;
            try//연체된 책 검출
            {
                selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT " +
                                        "* " +
                                  "FROM " +
                                        "BOOKRENTS " +
                                  "WHERE " +
                                        "BOOK_ID = @BOOK_ID AND " +
                                        "RENT_YN='0'");
                selectSQL.AddParam("BOOK_ID", BOOK_ID);
                selectSQL.Go();
                jarray = selectSQL.ToJArray();
                if (jarray.Count != 0)
                {
                    if (jarray[0].Value<int>("OVERDUE_YN") == 1)//연체됐다면
                    {
                        MessageBox.Show("책 ID : " + BOOK_ID + " 은 연체된 도서입니다.\n사서에게 문의해 주시기 바랍니다..", "연체 도서");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
                return;
            }
            if (Rent_YN)
            {
                if (MessageBox.Show("책 ID : " + BOOK_ID + " - 해당 도서를 반납하시겠습니까?", "반납", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SQLObject updateSQL = new BACK.SQLObject();
                    updateSQL.setQuery("UPDATE " +
                                            "BOOKS " +
                                        "SET " +
                                            "RENT_YN=@RENT_YN, " +
                                            "RENT_ID=@RENT_ID " +
                                        "WHERE " +
                                            "BOOK_ID=@BOOK_ID");
                    updateSQL.AddParam("RENT_YN", "0");
                    updateSQL.AddParam("RENT_ID", "");
                    updateSQL.AddParam("BOOK_ID", BOOK_ID);
                    updateSQL.Go();

                    updateSQL = new BACK.SQLObject();
                    updateSQL.setQuery("UPDATE " +
                                            "BOOKRENTS " +
                                        "SET " +
                                            "RENT_YN=@RENT_YN " +
                                        "WHERE " +
                                            "BOOK_ID=@BOOK_ID");
                    updateSQL.AddParam("RENT_YN", "1");
                    updateSQL.AddParam("BOOK_ID", BOOK_ID);
                    updateSQL.Go();
                    MessageBox.Show("책 ID " + BOOK_ID + " 이 반납되었습니다", "반납");
                }
            }
            else
            {
                MessageBox.Show("책 ID : " + BOOK_ID + " 은 이미 반납된상태입니다", "반납");
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
