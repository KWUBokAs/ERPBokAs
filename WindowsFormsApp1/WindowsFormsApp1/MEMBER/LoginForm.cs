using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MEMBER
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            lab_LoginStatus.Text = "";
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
        private void InitTest()
        {

            txtId.Text = "admin";
            txtPassward.Text = "admin123";
            txtId.Focus();
            /*
            lvwMember.View = View.Details;
            lvwMember.Columns.Add("");
            lvwMember.Columns.Add("ID");
            lvwMember.Columns.Add("이름");
            lvwMember.Columns.Add("E-Mail");
            lvwMember.Columns.Add("전화번호");
            lvwMember.Columns.Add("권한");
            */
        }

        private void txtPassward_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }
        private void CheckLogin()
        {
            BaseMember member = BaseMember.GetInstance();
            switch (member.TryLogin(txtId.Text, txtPassward.Text))
            {
                case BaseMember.LOGINTYPE.ID_NOT_EXIST://아이디가 존재하지 않을 때
                    lab_LoginStatus.Text = "ID가 존재하지 않습니다.";
                    break;
                case BaseMember.LOGINTYPE.ID_NOT_INPUT://아이디 입력 안했을 때
                    lab_LoginStatus.Text = "ID를 입력해 주세요.";
                    break;
                case BaseMember.LOGINTYPE.PW_NOT_INPUT://pw 입력 안 했을 때
                    lab_LoginStatus.Text = "PW를 입력해 주세요.";
                    break;
                case BaseMember.LOGINTYPE.PW_INCONSIST://pw가 불일치 할때
                    lab_LoginStatus.Text = "PW가 일치하지 않습니다.";
                    break;
                case BaseMember.LOGINTYPE.SUCCESS://성공 했을 때
                    if (!member.ReadDatabase())//DB입력이 실패 했을 때
                    {
                        lab_LoginStatus.Text = "데이터베이스와 접속을 실패했습니다.";
                    }
                    else
                    {
                        lab_LoginStatus.Text = "성공!";
                    }
                    break;
            }
            if (member.IsLogin)
            {
                Close();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (member.IsLogin)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
