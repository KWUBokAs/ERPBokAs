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

namespace WindowsFormsApp1.BOOK
{
    public partial class BarCode : UserControl
    {
        const int BOOKNUMBER_SIZE = 6;
        public BarCode()
        {
            InitializeComponent();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            string BOOK_ID = ((TextBox)sender).Text;
            if (BOOK_ID.Length < BOOKNUMBER_SIZE) return;
            ((TextBox)sender).Text = "";
            SQLObject selectSQL;
            JArray jarray;
            try//연체된 책 검출
            {
                selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT " +
                                        "* " +
                                  "FROM " +
                                        "BOOKRENTS " +
                                  "WHERE " +
                                        "BOOK_ID = @BOOK_ID AND " +
                                        "RENT_YN='0'");
                selectSQL.AddParam("BOOK_ID", BOOK_ID);
                selectSQL.Go();
                jarray = selectSQL.ToJArray();
                if (jarray.Count == 0)
                {
                    MessageBox.Show("책 ID : " + BOOK_ID + " 은 대여된 책이 아닙니다.", "반납");
                    return;
                }
                if (jarray[0].Value<string>("OVERDUE_YN").Equals("True"))//연체됐다면
                {
                    MessageBox.Show("책 ID : " + BOOK_ID + " 은 연체된 도서입니다.\n사서에게 문의해 주십쇼.", "반납");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("DB접속이 불안정합니다.");
                return;
            }


            selectSQL = new BACK.SQLObject();
            selectSQL.setQuery("SELECT " +
                                    "* " +
                              "FROM " +
                                    "BOOKS " +
                              "WHERE " +
                                    "BOOK_ID=@BOOK_ID");
            selectSQL.AddParam("BOOK_ID", BOOK_ID);
            selectSQL.Go();
            jarray = selectSQL.ToJArray();

            if (jarray.Count == 0)
            {
                MessageBox.Show("책 ID : " + BOOK_ID + " 은 저희 도서관에 등록된 도서가 아닙니다", "반납");
                return;
            }
            
            
            if (jarray[0].Value<string>("RENT_YN").Equals("True"))
            {
                if (MessageBox.Show("책 ID : " + BOOK_ID + " - 해당 도서를 반납하시겠습니까?", "반납", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SQLObject updateSQL = new BACK.SQLObject();
                    updateSQL.setQuery("UPDATE " +
                                            "BOOKS " +
                                        "SET " +
                                            "RENT_YN=@RENT_YN, " +
                                            "RENT_ID=@RENT_ID " +
                                        "WHERE " +
                                            "BOOK_ID=@BOOK_ID");
                    updateSQL.AddParam("RENT_YN", "0");
                    updateSQL.AddParam("RENT_ID", "");
                    updateSQL.AddParam("BOOK_ID", BOOK_ID);
                    updateSQL.Go();

                    updateSQL = new BACK.SQLObject();
                    updateSQL.setQuery("UPDATE " +
                                            "BOOKRENTS " +
                                        "SET " +
                                            "RENT_YN=@RENT_YN " +
                                        "WHERE " +
                                            "BOOK_ID=@BOOK_ID");
                    updateSQL.AddParam("RENT_YN", "1");
                    updateSQL.AddParam("BOOK_ID", BOOK_ID);
                    updateSQL.Go();
                    MessageBox.Show("책 ID " + BOOK_ID + " 이 반납되었습니다","반납");
                }
            }
            else
            {
                MessageBox.Show("책 ID : " + BOOK_ID + " 은 이미 반납된상태입니다", "반납");
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
