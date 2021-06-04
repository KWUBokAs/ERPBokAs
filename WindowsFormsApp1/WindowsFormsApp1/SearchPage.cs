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
            WRITER = multiSpaceToOne.Replace(WRITER, "");
            PUBLISHER = multiSpaceToOne.Replace(PUBLISHER, "");

            SQLObject selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT "+
                                    "*" +
                              "FROM " +
                                    "BOOKINFO " +
                              "WHERE " +
                                    "NAME LIKE @NAME " +
                                    "AND WRITER LIKE @WRITER " +
                                    "AND PUBLISHER LIKE @PUBLISHER");
            selectSQL.AddParam("NAME","%"+NAME+"%");
            selectSQL.AddParam("WRITER","%"+WRITER+"%");
            selectSQL.AddParam("PUBLISHER","%"+PUBLISHER+"%");
            selectSQL.Go();
            JArray jarray = selectSQL.ToJArray();
            dgvBookInfo.DataSource = JsonConvert.DeserializeObject(jarray.ToString());
        }

        private void dgvBookInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvBookInfo.CurrentRow == null) return;
            string ISBN = this.dgvBookInfo.CurrentRow.Cells[0].Value.ToString();
            DataGridViewRow dgvr = this.dgvBookInfo.CurrentRow;
            BookInfoDetail bid = new BookInfoDetail(ISBN, dgvr);
            DialogResult dResult = bid.ShowDialog();
        }
    }
}
