using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BACK;
using WindowsFormsApp1.MEMBER;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WindowsFormsApp1.MEMBER
{
    public partial class BadMemberSearch : UserControl
    {
        const int NUMBER_USERID = 0, NUMBER_BOOKID = 1, NUMBER_RENT = 2, NUMBER_RETURN = 3, NUMBER_LATEFEE = 4;
        const int booknumLenth = 6;
        private int latefee = 0;//총합
        private Form3 parent;
        public BadMemberSearch(Form3 form)
        {
            parent = form;
            InitializeComponent();
            //parent.ListBtnBadSearch_Event += SetGrideView;
        }

        private void BadMemberSearch_Load(object sender, EventArgs e)
        {

        }
        private void SetGrideView()
        {
            Options options = Options.GetInstance();
            string booknum = txtBookNum.Text;
            string id = txtId.Text;
            booknum = booknum.Trim();
            id = id.Trim();
            latefee = 0;
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT USER_ID AS 'ID', BOOK_ID AS '등록번호', RENT_DT AS '대출일', RETURN_DT AS '반납일', RENT_ID AS '연체료' " +
                                    "FROM `BOOKRENTS` " +
                                    "WHERE " +
                                            "(USER_ID=@USER_ID " +
                                            "OR BOOK_ID=@BOOK_ID) " +
                                            "AND OVERDUE_YN='1' " +
                                            "AND RENT_YN='0'");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.AddParam("BOOK_ID", booknum);
                selectSQL.Go();

                JArray jarray = selectSQL.ToJArray();
                dgvBadTable.DataSource = JsonConvert.DeserializeObject(jarray.ToString());//rent table get

                if(dgvBadTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvBadTable.Rows.Count; i++)
                    {
                        var row = dgvBadTable.Rows[i];
                        row.Cells[NUMBER_RENT].Value = DateTime.Parse(row.Cells[NUMBER_RENT].Value.ToString()).ToString("yyyy-MM-dd");//대출일 시간때기
                        string return_dt = DateTime.Parse(row.Cells[NUMBER_RETURN].Value.ToString()).ToString("yyyy-MM-dd");//반납일 시간때기
                        row.Cells[NUMBER_RETURN].Value = return_dt;//반납일 시간 때기

                        int tempFee = options.GetLatefee(return_dt);//연체료계산
                        latefee += tempFee;
                        row.Cells[NUMBER_LATEFEE].Value = tempFee.ToString() + "원";
                    }
                    dgvBadTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    txtId.Text = dgvBadTable.Rows[0].Cells[NUMBER_USERID].Value.ToString();
                    txtBookNum.Text = "";
                }
                else//없을때
                {
                    DistnctBadMemberFree(id);
                }
                labSumLatefee.Text = latefee.ToString() + "원";
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
            }
            
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtBookNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtBookNum_TextChanged(object sender, EventArgs e)
        {
            string BOOK_ID = ((TextBox)sender).Text;
            if (BOOK_ID.Length < booknumLenth) return;
            SetGrideView();
        }

        /// <summary>
        /// bad member에서 해방됐다면 해제해주자
        /// </summary>
        /// <param name="id"></param>
        private void DistnctBadMemberFree(string id)
        {
            try//연체료 납부할 것이 더 있는지 확인인
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT COUNT(USER_ID) AS 'ID_CNT' " +
                                    "FROM `BOOKRENTS` " +
                                    "WHERE " +
                                            "USER_ID=@USER_ID " +
                                            "AND OVERDUE_YN='1' " +
                                            "AND RENT_YN='0'");
                selectSQL.AddParam("USER_ID", id);
                selectSQL.Go();
                JArray jarray = selectSQL.ToJArray();
                int cnt = jarray[0].Value<int>("ID_CNT");
                if (cnt > 0) return;//추가로 더 연체료납부할 것이 있음
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
            }
            try
            {
                SQLObject updateSQL = new BACK.SQLObject();//일반회원으로 만들어준다.
                updateSQL.setQuery("UPDATE `USER` " +
                                    "SET `BAD_YN`='n' " +
                                    "WHERE " +
                                            "USER_ID = @USER_ID");
                updateSQL.AddParam("USER_ID", id);
                updateSQL.Go();
                MessageBox.Show(id + "(님)은 일반회원 입니다.", "연체 도서 반납");
                txtId.Text = "";
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBookNum.Text.Length > booknumLenth) txtBookNum.Text = txtBookNum.Text.Substring(0, booknumLenth);
            if (txtId.Text.Length > 13)//너무 길면 막음 / 인젝션 위험
            {
                txtId.Text = "";
                txtBookNum.Focus();
                return;
            }
            if (txtId.Text.Length<4 && txtBookNum.Text.Length < booknumLenth)//아무것도 입력하지 않았을때
            {
                txtBookNum.Focus();
                return;
            }
            SetGrideView();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBadTable == null || dgvBadTable.Rows == null || dgvBadTable.Rows.Count == 0)//선택할 것이 없을 때
            {
                MessageBox.Show("항목을 선택한 후 진행해 주세요.", "연체 도서 반납");
                return;
            }
            DataGridViewRow row = null;
            int rowindex = dgvBadTable.CurrentCell.RowIndex;
            row = dgvBadTable.Rows[rowindex];
            string bookNumber = row.Cells[NUMBER_BOOKID].Value.ToString();

            try
            {
                SQLObject updateSQL = new BACK.SQLObject();//이전cnt는 종결될수 있도록해준다.
                updateSQL.setQuery("UPDATE `BOOKRENTS` " +
                                    "SET `RENT_YN`='1' " +
                                    "WHERE " +
                                            "BOOK_ID=@BOOK_ID " +
                                            "AND OVERDUE_YN='1' " +
                                            "AND RENT_YN='0'");
                updateSQL.AddParam("BOOK_ID", bookNumber);
                updateSQL.Go();
                updateSQL = new BACK.SQLObject();
                updateSQL.setQuery("UPDATE " +
                                        "BOOKS " +
                                    "SET " +
                                        "RENT_YN=@RENT_YN, " +
                                        "RENT_ID=@RENT_ID " +
                                    "WHERE " +
                                        "BOOK_ID=@BOOK_ID");
                updateSQL.AddParam("RENT_YN", "0");
                updateSQL.AddParam("RENT_ID", "");
                updateSQL.AddParam("BOOK_ID", bookNumber);
                updateSQL.Go();
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.", "DB 접속 오류");
                return;
            }
            SetGrideView();
        }

        private void txtBookNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBookNum.Text.Length < booknumLenth)
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
