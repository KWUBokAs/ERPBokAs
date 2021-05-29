using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MEMBER;

namespace WindowsFormsApp1.MEMBER
{
    public partial class MemberDataInputPanel : UserControl
    {
        
        public MemberDataInputPanel()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (txtId.Text.Length < 5)
            {
                testTextBox.Text = "아이디를 다시 입력하세요.\n-4자 이상-";
                txtId.Focus();
            }
            if(txtPassward.Text.Length < 5)
            {
                testTextBox.Text = "패스웨드를 다시 입력하세요.\n-4자 이상-";
                txtPassward.Focus();
            }
            if(txtName.Text.Length < 2)
            {
                testTextBox.Text = "이름을 다시 입력하세요.\n-2자 이상-";
                txtName.Focus();
            }
            if (txtPhoneNumber.Text.Length< 5)
            {
                testTextBox.Text = "전화번호를 다시 입력하세요.";
                txtPhoneNumber.Focus();
            }
            if (txtEmail.Text.Length < 5)
            {
                testTextBox.Text = "E-Mail를 다시 입력하세요.";
                txtEmail.Focus();
            }
            BaseMember.PERM perm = BaseMember.PERM.NOMAL_USR;
            BaseMember.PERM temp = BaseMember.PERM.NOMAL_USR;
            for (int i=0; i<chklistManage.CheckedItems.Count; i++)
            {
                var item = chklistManage.CheckedItems[i];
                if(item.ToString() == "사서사용자")
                {
                    temp = BaseMember.PERM.BOOK_ADMIN;
                }
                else if(item.ToString() == "열람실관리자")
                {
                    temp = BaseMember.PERM.READ_ADMIN;
                }
                else if (item.ToString() == "회의실관리자")
                {
                    temp = BaseMember.PERM.MEET_ADMIN;
                }
                else if (item.ToString() == "회원관리자")
                {
                    temp = BaseMember.PERM.MEMBER_ADMIN;
                }
                if(temp != BaseMember.PERM.NOMAL_USR)
                {
                    perm = perm | temp;
                }
            }
            switch(member.MakeUser(txtId.Text, txtPassward.Text, txtName.Text, txtPhoneNumber.Text, txtEmail.Text, perm, txtSummery.Text))
            {
                case BaseMember.LOGINTYPE.DB_CONNECT_FALL:
                    testTextBox.Text = "Database 접속실패!\n";
                    break;
                case BaseMember.LOGINTYPE.ID_NOT_EXIST:
                    testTextBox.Text = "아이디를 다시 입력하세요.\n-같은 이름에 아이디기 존재합니다-";
                    txtId.Focus();
                    break;
                case BaseMember.LOGINTYPE.SUCCESS:
                    txtEmail.Text = "";
                    txtId.Text = "";
                    txtName.Text = "";
                    txtPassward.Text = "";
                    txtPhoneNumber.Text = "";
                    txtSummery.Text = "";
                    testTextBox.Text = "추가 성공";
                    for(int i=0; i<chklistManage.Items.Count; i++)
                    {
                        chklistManage.SetItemChecked(i, false);
                    }
                    break;
                default:
                    testTextBox.Text = "최소 문자를 채우지 못한 것이 있습니다.";
                    break;
            }
        }

        private void MemberDataInputPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassward.Focus();
            }
        }

        private void txtPassward_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNumber.Focus();
            }
        }

        private void txtPhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSummery.Focus();
            }
        }
    }
}
