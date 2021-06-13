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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.BOOK
{
    class StringPair
    {
        public string key { get; set; }
        public string value { get; set; }

        public StringPair(string _key, string _value)
        {
            this.key = _key;
            this.value = _value;
        }
    }
    public partial class RegistrationPage : UserControl
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationPage_Load(object sender, EventArgs e)
        {
            string[] types = { "단행본", "e북", "오디오북", "논문" };

            cmbTypes.Items.AddRange(types);

            cmbTypes.SelectedIndex = 0;
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            var list = new List<StringPair>();

            // 필수
            list.Add(new StringPair("NAME", this.txtName.Text));    // tinytext
            list.Add(new StringPair("ISBN", this.txtISBN.Text));    // varchar13

            // 선택  
            list.Add(new StringPair("WRITER", this.txtWriter.Text));    // tinytext
            list.Add(new StringPair("TRANSRATOR", this.txtTransrator.Text));    // tinytext
            list.Add(new StringPair("PUBLISHER", this.txtPublisher.Text));  // tinytext
            //blob img
            list.Add(new StringPair("TYPE", this.cmbTypes.SelectedIndex.ToString()));   // int2
            list.Add(new StringPair("ORIGINNM", this.txtOriginnm.Text));    // text
            list.Add(new StringPair("SUMMARY", this.txtSummary.Text));  // text
            list.Add(new StringPair("PUBLICATION_DATE", this.dtpPublishcationDate.Text + " :00:00:00"));  // date
            list.Add(new StringPair("PRICE", this.nudPrice.Value.ToString()));  // int11
            list.Add(new StringPair("INDEX_LIST", this.txtIndex.Text)); // text


            // 앞 뒤 공백은 삭제
            // Ex) "     A B    " => "A B"
            Regex rmFBSpace = new Regex(@"^[^\S\r\n]+|[^\S\r\n]+$");
            foreach (var pair in list)
                pair.value = rmFBSpace.Replace(pair.value, "");

            // 가운데 공백은 단일 공백으로 만듬
            // Ex) "A       B" => "A B"
            Regex multiSpaceToOne = new Regex(@"[^\S\r\n]+");
            foreach (var pair in list)
                pair.value = multiSpaceToOne.Replace(pair.value, " ");

            // 필수항목 입력 검사
            if (list.Find(p => p.key.Equals("NAME")).value.Equals(""))
            {
                MessageBox.Show("필수항목을 입력해주세요", "필수항목");
                return;
            }
            if (list.Find(p => p.key.Equals("ISBN")).value.Length != 13)
            {
                MessageBox.Show("ISBN은 13자리 숫자입니다", "필수항목");
                return;
            }

            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "COUNT(ISBN) AS CNT " +
                              "FROM " +
                                    "BOOKINFO " +
                              "WHERE " +
                                    "ISBN=@ISBN");
            selectSQL.AddParam("ISBN", list.Find(p => p.key.Equals("ISBN")).value);
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            if (jarray[0].Value<int>("CNT") != 0)
            {
                MessageBox.Show("해당 ISBN을 가진 책은 이미 등록되어 있습니다\n" +
                    "같은 ISBN의 책을 추가하려면 [도서->검색->검색->추가]를 이용해주세요", "이미 존재하는 ISBN");
                return;
            }

            SQLObject insertSQL = new BACK.SQLObject();
            insertSQL.setQuery("INSERT INTO " +
                                   "`BOOKINFO` " +
                                   "(`ISBN`, `NAME`, `WRITER`, `TRANSRATOR`, `PUBLISHER`, `TYPE`, `ORIGINNM`, `SUMMARY`, `PUBLICATION_DATE`, `PRICE`, `INDEX_LIST`) " +
                               "VALUES " +
                                   "(@ISBN, @NAME, @WRITER, @TRANSRATOR, @PUBLISHER, @TYPE, @ORIGINNM, @SUMMARY, @PUBLICATION_DATE, @PRICE, @INDEX_LIST)");
            foreach (var pair in list)
                insertSQL.AddParam(pair.key, pair.value);

            insertSQL.Go();

            MessageBox.Show("ISBN : "+list.Find(p => p.key.Equals("ISBN")).value + " 을 등록했습니다", "등록");
        }
    }
}
