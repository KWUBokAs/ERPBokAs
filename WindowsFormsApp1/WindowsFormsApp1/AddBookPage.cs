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

namespace WindowsFormsApp1
{
    public partial class AddBookPage : Form
    {
        string ISBN;
        public AddBookPage(string _ISBN)
        {
            InitializeComponent();
            ISBN = _ISBN;
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
    }
}
