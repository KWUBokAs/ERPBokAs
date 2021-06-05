using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MEMBER
{
    public partial class BadMemberSearch : UserControl
    {
        private int latefee = 0;//총합
        private string id;
        private Form3 parent;
        public BadMemberSearch(Form3 form)
        {
            parent = form;
            InitializeComponent();
            parent.ListBtnBadSearch_Event += SetGrideView;
            id = "";
        }

        private void BadMemberSearch_Load(object sender, EventArgs e)
        {
            SetGrideView(sender, e);
        }
        private void SetGrideView()
        {
            

        }
        private void SetGrideView(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (id == member.ID) return;
            latefee = 0;
            labSumLatefee.Text = "0원";
            SetGrideView();
            dgvBadTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
