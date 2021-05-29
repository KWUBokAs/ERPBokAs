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
        }
        private void SetDataGrideView()
        {
            BaseMember member = BaseMember.GetInstance();

            try//id가 있는지 없는지 판별하는 부분 있으면 실패를 반환한다.
            {
                SQLObject selectSQL = new BACK.SQLObject();//반납예정일 추가
                selectSQL.setQuery("SELECT infos.NAME AS '서명', infos.ISBN AS 'ISBN', rent.RENT_DT AS '대출일', rent.RENEW_CNT AS '연장횟수' " +
                                    "FROM (SELECT BOOK_ID, RENT_DT, RENEW_CNT " +
                                            "FROM BOOKRENTS " +
                                            "WHERE USER_ID=@USER_ID) AS rent " +
                                    "LEFT JOIN " +
                                    "(BOOKS LEFT JOIN BOOKINFO ON BOOKS.ISBN = BOOKINFO.ISBN) AS infos " +
                                    "ON rent.BOOK_ID = infos.BOOK_ID ");
                selectSQL.AddParam("USER_ID", member.ID);
                selectSQL.Go();
                JArray idnum = selectSQL.ToJArray();
                JArray jarray = selectSQL.ToJArray();
                dgvRentData.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
