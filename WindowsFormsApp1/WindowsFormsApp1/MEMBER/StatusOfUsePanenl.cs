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
        public StatusOfUsePanenl()
        {
            InitializeComponent();
        }
        private void StatusOfUsePanenl_Load(object sender, EventArgs e)
        {
            SetDataGrideView();
            dgvRentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void SetDataGrideView()
        {
            BaseMember member = BaseMember.GetInstance();

            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT infos.NAME AS '서명', rents.BOOK_ID AS '등록번호', infos.ISBN, rents.RENT_DT AS '대여일', rents.RENEW_CNT AS '연장장횟수' " +
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
                dgvRentData.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
                rentNum = dgvRentData.Rows.Count;

                Options options = Options.GetInstance();

                labRentNum.Text = rentNum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetOption()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
