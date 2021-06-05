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

namespace WindowsFormsApp1
{
    public partial class SearchPage : UserControl
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string NAME = this.txtName.Text;
            string WRITER = this.txtWriter.Text;
            string PUBLISHER = this.txtPublisher.Text;

            // 앞 뒤 공백은 삭제
            // Ex) "     A B    " => "A B"
            Regex rmFBSpace = new Regex(@"^\s+|\s+$");
            NAME = rmFBSpace.Replace(NAME, "");
            WRITER = rmFBSpace.Replace(WRITER, "");
            PUBLISHER = rmFBSpace.Replace(PUBLISHER, "");

            // 가운데 공백은 단일 공백으로 만듬
            // Ex) "A       B" => "A B"
            Regex multiSpaceToOne = new Regex(@"\s+");
            NAME = multiSpaceToOne.Replace(NAME, " ");
            WRITER = multiSpaceToOne.Replace(WRITER, " ");
            PUBLISHER = multiSpaceToOne.Replace(PUBLISHER, " ");

            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT "+
                                    "ISBN, " +
                                    "NAME AS 도서명, " +
                                    "WRITER AS 저자, " +
                                    "TRANSRATOR AS 번역가, " +
                                    "PUBLISHER AS 출판사, " +
                                    "TYPE AS 유형, " +
                                    "ORIGINNM AS 원저, " +
                                    "PUBLICATION_DATE AS 출간일, " +
                                    "PRICE AS 가격 " +
                              "FROM " +
                                    "BOOKINFO " +
                              "WHERE " +
                                    "NAME LIKE @NAME " +
                                    "AND WRITER LIKE @WRITER " +
                                    "AND PUBLISHER LIKE @PUBLISHER");
            selectSQL.AddParam("NAME","%"+NAME+"%");
            selectSQL.AddParam("WRITER","%"+WRITER+"%");
            selectSQL.AddParam("PUBLISHER", "%" + PUBLISHER + "%");
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            foreach (var t in jarray)
            {
                if (t["유형"].ToString().Equals("0"))
                    t["유형"] = "단행본";
                else if (t["유형"].ToString().Equals("1"))
                    t["유형"] = "e북";
                else if (t["유형"].ToString().Equals("2"))
                    t["유형"] = "오디오북";
                else if (t["유형"].ToString().Equals("3"))
                    t["유형"] = "논문";
            }
            dgvBookInfo.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
        }

        private void dgvBookInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvBookInfo.CurrentRow == null) return;
            DataGridViewRow dgvr = this.dgvBookInfo.CurrentRow;
            BookInfoDetail bid = new BookInfoDetail(dgvr);
            bid.ShowDialog();
        }
    }
}
