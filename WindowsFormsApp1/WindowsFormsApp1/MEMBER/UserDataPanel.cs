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
    public partial class UserDataPanel : UserControl
    {
        private Form3 parent;
        private string userid;

        public event EventHandler btnChangePassward_Event;
        public UserDataPanel(Form3 parent)
        {
            this.parent = parent;
            InitializeComponent();
            parent.ListBtnUserData_Event += SetTable_Event;
            userid = "";
        }

        private void btnPasswardChange_Click(object sender, EventArgs e)
        {
            if(btnChangePassward_Event != null)
                btnChangePassward_Event(sender, e);
        }
        private void SetTable()
        {
            BaseMember member = BaseMember.GetInstance();
            labId.Text = member.ID;
            labEmail.Text = member.Email;
            string t = member.PhoneNumber;
            labPhone.Text = t.Substring(0,3) + "-"+ t.Substring(3, 4)+ "-"+ t.Substring(7, 4);
            labName.Text = member.Name;
            string temp = ((member.IsBadMember) ? "연체)" : "최대 대출건수 초과" ) + " => 사서에게 문의하세요.";
            labRent.Text = (member.CanRentBook) ? "Y":"N(사유:" + temp;
        }
        private void SetTable_Event(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (userid == member.ID) return;
            userid = member.ID;
            SetTable();
        }
        private void UserDataPanel_Load(object sender, EventArgs e)
        {
            labEmail.Text = "";
            labId.Text = "";
            labName.Text = "";
            labPhone.Text = "";
            labRent.Text = "";
            SetTable();
        }
    }
}
