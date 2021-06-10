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
        const int expendDate = 5;//연장가능한 날짜 범위
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
            this.latefee = 0;

            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT infos.NAME AS '서명', rents.BOOK_ID AS '등록번호', infos.ISBN, rents.RENT_DT AS '대여일' ,rents.RETURN_DT AS '반납일', rents.RENEW_CNT AS '연장횟수', rents.OVERDUE_YN AS '연체여부' " +
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
                    var rent_dt = row.Cells[3];
                    string temp1 = rent_dt.Value.ToString();
                    rent_dt.Value = DateTime.Parse(temp1).ToString("yyyy-MM-dd");//날짜 시간 때기

                    var return_dt = row.Cells[4];
                    string temp2 = return_dt.Value.ToString();
                    return_dt.Value = DateTime.Parse(temp2).ToString("yyyy-MM-dd");//날짜 시간 때기
                    try
                    {
                        var overdue_yn = row.Cells[6];
                        int temp3 = Convert.ToInt32(overdue_yn.Value.ToString());
                        overdue_yn.Value = (temp3 == 1) ? "연체" : "N";

                        TimeSpan over_due = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) - DateTime.Parse((return_dt.Value).ToString());
                        int latefee = temp3 * options.RV * over_due.Days;
                        overdueNum += temp3;
                        this.latefee += latefee;
                    }
                    catch { }
                }

                rentNum = dgvRentData.Rows.Count;
                labRentNum.Text = rentNum.ToString()+"권";//대여권수 세팅
                labOverDueNum.Text = overdueNum.ToString()+"권";
                labLatefee.Text = this.latefee.ToString()+"원";
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
            int rent_cnt = Convert.ToInt32(row.Cells[5].Value);

            DateTime last = DateTime.Parse(row.Cells[4].Value.ToString());//반납일
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
            if (overdueNum > 0)
            {
                MessageBox.Show("연체되었습니다.\n사서에게 문의해주세요.");
                return false;//연체된것이 있는면 실패
            }
            Options options = Options.GetInstance();
            BaseMember member = BaseMember.GetInstance();
            if (options.EC < rent_cnt) return false;//연장횟수 초가
            JArray jarray;//이전 data 저장
            string BOOK_ID ="";
            DateTime dateStart =DateTime.Now;
            DateTime dateEnd = DateTime.Now;
            try
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT BOOK_ID, USER_ID, RENT_DT, RETURN_DT, RENEW_CNT " +
                                    "FROM `BOOKRENTS` " +
                                    "WHERE " +
                                            "BOOK_ID = @BOOK_ID AND " +
                                            "RENT_YN='0' AND " +
                                            "OVERDUE_YN='0' AND " +
                                            "USER_ID = @USER_ID");
                selectSQL.AddParam("USER_ID", member.ID);
                selectSQL.AddParam("BOOK_ID", bookNumber);
                selectSQL.Go();
                jarray = selectSQL.ToJArray();

                if (jarray.Count == 0)
                {
                    MessageBox.Show("연체되었습니다.\n사서에게 문의해주세요.");
                    return false;
                }

                BOOK_ID = jarray[0].Value<string>("BOOK_ID");
                dateStart = DateTime.Parse(jarray[0].Value<string>("RENT_DT"));
                dateEnd = DateTime.Parse(jarray[0].Value<string>("RETURN_DT"));

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
            if (BOOK_ID == "" || dateStart == DateTime.Now || dateStart == dateEnd) return false;//재대로 못받았을 때
            try
            {
                SQLObject updateSQL = new BACK.SQLObject();//이전cnt는 종결될수 있도록해준다.
                updateSQL.setQuery("UPDATE `BOOKRENTS` " +
                                    "SET `RENT_YN`='1' " +
                                    "WHERE " +
                                            "BOOK_ID=@BOOK_ID AND " +
                                            "RENT_YN='0' AND " +
                                            "USER_ID = @USER_ID");
                updateSQL.AddParam("BOOK_ID", bookNumber);
                updateSQL.AddParam("USER_ID", member.ID);
                updateSQL.Go();


                SQLObject insertSQL = new SQLObject();//새로운로그 생성
                insertSQL.setQuery("INSERT INTO " +
                                        "`BOOKRENTS` " +
                                        "(`BOOK_ID`, `USER_ID`, `RENT_DT`, `RETURN_DT`, `RENT_DIV`, `RENT_YN`, `OVERDUE_YN`, `RENEW_CNT`) " +
                                    "VALUES " +
                                        "(@BOOK_ID, @USER_ID, @RENT_DT, @RETURN_DT, @RENT_DIV, @RENT_YN, @OVERDUE_YN, @RENEW_CNT)");
                insertSQL.AddParam("BOOK_ID", BOOK_ID);
                insertSQL.AddParam("USER_ID", member.ID);
                insertSQL.AddParam("RENT_DT", dateStart.ToString("yyyy-MM-dd HH:mm:ss"));
                insertSQL.AddParam("RETURN_DT", dateEnd.AddDays(options.RDADD).ToString("yyyy-MM-dd HH:mm:ss"));
                insertSQL.AddParam("RENT_DIV", "1");
                insertSQL.AddParam("RENT_YN", "0");
                insertSQL.AddParam("OVERDUE_YN", "0");
                insertSQL.AddParam("RENEW_CNT", rent_cnt.ToString());
                insertSQL.Go();
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
