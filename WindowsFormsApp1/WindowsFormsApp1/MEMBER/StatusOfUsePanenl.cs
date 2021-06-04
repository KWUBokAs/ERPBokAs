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

        private Form3 parent;
        public StatusOfUsePanenl(Form3 form3)
        {
            parent = form3;
            InitializeComponent();

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
            SetDataGrideView();
        }
        private void SetDataGrideView()
        {
            BaseMember member = BaseMember.GetInstance();
            Options options = Options.GetInstance();

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
            int rowIndex = dgvRentData.CurrentCell.RowIndex;
            string number = dgvRentData.Rows[rowIndex].Cells[1].Value.ToString();//도서 등록번호

            
        }
    }
}
