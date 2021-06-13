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
    public partial class PasswardChangePanel : UserControl
    {
        private Form3 parent;
        public EventHandler SavePassward_Event;
        public PasswardChangePanel(Form3 form3)
        {
            parent = form3;
            InitializeComponent();
            parent.OpenPasswardChangePanel_Event += TextBoxClear_Event;
        }

        private void PasswardChangePanel_Load(object sender, EventArgs e)
        {
            txtNew.PasswordChar = '*';
            txtCheck.PasswordChar = '*';
            txtOrigin.PasswordChar = '*';
        }

        private void TextBoxClear_Event(object sender, EventArgs e)
        {
            txtNew.Text = "";
            txtCheck.Text = "";
            txtOrigin.Text = "";
            txtNew.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool branch = true;
            if (txtOrigin.Text.Length < 5)
            {
                txtOrigin.Focus();
            }
            else if (txtNew.Text.Length < 5)
            {
                txtNew.Focus();
            }
            else if (txtCheck.Text.Length < 5)
            {
                txtCheck.Focus();
            }
            else branch = false;
            if (branch)
            {
                MessageBox.Show("정확하게 입력해주세요.\n다시 입력해 주세요", "입력오류");
                return;
            }
            BaseMember member = BaseMember.GetInstance();
            switch (member.TryLogin(member.ID, txtOrigin.Text))
            {
                case BaseMember.LOGINTYPE.PW_NOT_INPUT://pw 입력 안 했을 때
                    MessageBox.Show("현제 비밀번호를 다시 입력해 주세요.", "입력오류");
                    txtOrigin.Focus();
                    break;
                case BaseMember.LOGINTYPE.PW_INCONSIST://pw가 불일치 할때
                    MessageBox.Show("비밀번호가 틀렸습니다.\n다시 입력해주세요.", "입력오류");
                    txtOrigin.Focus();
                    break;
                case BaseMember.LOGINTYPE.SUCCESS:
                case BaseMember.LOGINTYPE.ID_STAT_LOGIN://로그인중임
                    if(txtNew.Text == txtCheck.Text)
                    {
                        switch (member.ChangePassward(txtNew.Text))
                        {
                            case BaseMember.LOGINTYPE.SUCCESS:
                                TextBoxClear_Event(sender, e);
                                MessageBox.Show("비밀번호 변경에 성공하셨습니다.","비밀번호 변경");
                                SavePassward_Event(sender, e);
                                break;
                            default:
                                MessageBox.Show("DB와 접속이 원활하지 않습니다.","DB 접속 오류");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 다릅니다.\n다시 확인해주세요.", "입력오류");
                        txtCheck.Focus();
                    }
                    break;
                default:
                    MessageBox.Show("DB와 접속이 원활하지 않습니다.\n사유:예상치 못한 오류, 인터넷 상태 불안정", "DB 접속 오류");
                    break;
            }

        }
    }
}
