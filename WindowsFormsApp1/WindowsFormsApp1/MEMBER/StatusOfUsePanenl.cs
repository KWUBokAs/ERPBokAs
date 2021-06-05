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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1.MEMBER
{
    public partial class StatusOfUsePanenl : UserControl
    {
        private int rentNum=0;
        private int overdueNum=0;
        private int latefee=0;
        const int expendDate = 5;
        private string userid;

        private Form3 parent;
        public StatusOfUsePanenl(Form3 form3)
        {
            parent = form3;
            InitializeComponent();
            userid = "";
            parent.ListBtnUserData_Event += ChangeUserData_Event;
            labLatefee.Text = "";
            labOverDueNum.Text = "";
            labRentNum.Text = "";
        }
        private void StatusOfUsePanenl_Load(object sender, EventArgs e)
        {
            SetDataGrideView();
            dgvRentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void ChangeUserData_Event(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (userid == member.ID) return;
            userid = member.ID;
            SetDataGrideView();
        }
        private void SetDataGrideView()
        {
            BaseMember member = BaseMember.GetInstance();
            Options options = Options.GetInstance();

            rentNum = 0;
            overdueNum = 0;
            latefee = 0;

            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT infos.NAME AS '서명', rents.BOOK_ID AS '등록번호', infos.ISBN, rents.RENEW_CNT AS '연장횟수', rents.RENT_DT AS '대여일' ,rents.RENT_DT AS '반납일' " +
                                   "FROM BOOKINFO as infos " +
                                   "INNER JOIN BOOKRENTS as rents " +
                                   "ON  rents.RENT_YN = '0' " +
                                   "INNER JOIN BOOKS as books " +
                                   "ON infos.ISBN = books.ISBN " +
                                   "AND rents.BOOK_ID = books.BOOK_ID " +
                                   "WHERE rents.USER_ID = @USER_ID");
                selectSQL.AddParam("USER_ID", member.ID);
                selectSQL.Go();
                JArray idnum = selectSQL.ToJArray();
                JArray jarray = selectSQL.ToJArray();
                dgvRentData.DataSource = JsonConvert.DeserializeObject(jarray.ToString());//rent table get
                
                for(int i=0; i<dgvRentData.Rows.Count; i++)
                {
                    var row = dgvRentData.Rows[i];
                    var rent_dt = row.Cells[4];
                    string temp1 = rent_dt.Value.ToString();
                    rent_dt.Value = DateTime.Parse(temp1).ToString("yyyy-MM-dd");//날짜 시간 때기

                    int rent_cnt = Convert.ToInt32(row.Cells[3].Value);
                    string temp2 = options.GetBookReturnDate(temp1,rent_cnt);
                    row.Cells[5].Value = temp2;

                    int over_due = options.GetOverDue(temp1, rent_cnt);
                    if (over_due> 0)//연체됐으면
                    {
                        overdueNum++;
                        latefee +=  options.RV * over_due;
                    }
                }

                rentNum = dgvRentData.Rows.Count;
                labRentNum.Text = rentNum.ToString()+"권";//대여권수 세팅
                labOverDueNum.Text = overdueNum.ToString()+"권";
                labLatefee.Text = latefee.ToString()+"원";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (dgvRentData == null || dgvRentData.Rows == null || dgvRentData.Rows.Count == 0) return;//선택한 것이 없을때
            DataGridViewRow row = null;
            int rowIndex = dgvRentData.CurrentCell.RowIndex;
            row = dgvRentData.Rows[rowIndex];
            string number = row.Cells[1].Value.ToString();//도서 등록번호
            int rent_cnt = Convert.ToInt32(row.Cells[3].Value);

            DateTime last = DateTime.Parse(row.Cells[5].Value.ToString());//반납일
            DateTime now = DateTime.Now;
            TimeSpan gap = last - now;
            
            if (overdueNum == 0 && gap.Days < expendDate)//연장이 가능할 때
            {
                if (UpdateRentCnt(number, rent_cnt + 1))
                {
                    SetDataGrideView();
                }
                else
                {
                    Options options = Options.GetInstance();
                    MessageBox.Show("대출연장이 불가능합니다.\n" +
                        "아래 사항을 확인하시기 바랍니다.\n" +
                        "1.연장횟수 초과 "+ options.EC +"회\n" +
                        "2.DB 접속실패");
                }
            }
            else
            {
                MessageBox.Show("대출연장이 불가능합니다.\n" +
                                "사유 : 너무 이른기간 연장시도("+ expendDate + "일 이전)");
            }
        }
        /// <summary>
        /// bookNumbe이고, 대여중인 책은 rent_cnt로 업데이트 해준다.
        /// </summary>
        /// <param name="bookNumber">등록번호</param>
        /// <param name="rent_cnt"></param>
        private bool UpdateRentCnt(string bookNumber, int rent_cnt)
        {
            Options options = Options.GetInstance();
            if (options.EC < rent_cnt) return false;//연장횟수 초가

            try
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT RENEW_CNT " +
                                    "FROM `BOOKRENTS` " +
                                    "WHERE " +
                                            "BOOK_ID = @BOOK_ID AND " +
                                            "RENT_YN='0'");
                selectSQL.AddParam("RENEW_CNT", rent_cnt.ToString());
                selectSQL.AddParam("BOOK_ID", bookNumber);
                selectSQL.Go();
                JArray jarray = selectSQL.ToJArray();
                int temp = jarray[0].Value<int>("RENEW_CNT");
                if (rent_cnt - temp == 1) { }//정상적인 값이 들어온 경우
                else if (rent_cnt < temp) { return false; }//더 낮은 값으로 업데이트하려는 경우
                else if(rent_cnt < temp) { rent_cnt = temp + 1; }//엄청크게 하려는 경우 하나만 올려준다.
            }
            catch
            {
                MessageBox.Show("DB접속 오류");
                return false;
            }
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("UPDATE `BOOKRENTS` " +
                                    "SET `RENEW_CNT`=@RENEW_CNT " +
                                    "WHERE " +
                                            "BOOK_ID=@BOOK_ID AND " +
                                            "RENT_YN='0'");
                selectSQL.AddParam("RENEW_CNT", rent_cnt.ToString());
                selectSQL.AddParam("BOOK_ID", bookNumber);
                selectSQL.Go();
            }
            catch
            {
                MessageBox.Show("DB접속 오류");
                return false;
            }
            return true;
        }
    }
}
