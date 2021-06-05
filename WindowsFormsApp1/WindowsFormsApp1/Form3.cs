using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MEMBER;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Control OR = new OpenRoom();
        Control MR = new Meet();

        public event EventHandler ListBtnUserUsingData_Event;
        public event EventHandler ListBtnUserData_Event;
        public event EventHandler OpenPasswardChangePanel_Event;

        private UserDataPanel userDataPanel;
        private PasswardChangePanel passwardChangePanel;

        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.listBox1.Visible = !this.listBox1.Visible;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(OR))
                panel3.Controls.Remove(OR);
            if (panel3.Controls.Contains(MR))
                panel3.Controls.Remove(MR);
            switch (this.listBox1.SelectedIndex)
            {
                case 0:
                    HidePanel();

                    if (this.panel3.Controls.Find("SearchPage", false).Length == 1)
                    {
                        this.panel3.Controls.Find("SearchPage", false)[0].Visible = true;
                        break;
                    }
                    this.panel3.Controls.Add(new SearchPage());
                    break;

                case 2://등록
                    HidePanel();

                    if (this.panel3.Controls.Find("RegistrationPage", false).Length == 1)
                    {
                        this.panel3.Controls.Find("RegistrationPage", false)[0].Visible = true;
                        break;
                    }
                    this.panel3.Controls.Add(new RegistrationPage());
                    break;

                default:
                    this.listBox1.SelectedIndex = -1;
                    break;
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = WindowsFormsApp1.Properties.Resources.도서_호버;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = WindowsFormsApp1.Properties.Resources.책;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApp1.Properties.Resources.열람실_호버;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApp1.Properties.Resources.열람실;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = WindowsFormsApp1.Properties.Resources.회의실_호버;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = WindowsFormsApp1.Properties.Resources.회의실;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HidePanel();
            if (panel3.Controls.Contains(OR)) { 
                panel3.Controls.Remove(OR);
            }
            else
                panel3.Controls.Add(OR);

            if (panel3.Controls.Contains(MR))
            {
                panel3.Controls.Remove(MR);
            }
        }

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HidePanel();
            if (panel3.Controls.Contains(MR)) { 
                panel3.Controls.Remove(MR);
            }
            else
                panel3.Controls.Add(MR);

            if (panel3.Controls.Contains(OR))
            {
                panel3.Controls.Remove(OR);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            ChangeMemberData();
            SetlbMemberItem();
            HeadLabelSync();
        }
        private void ChangeMemberData()
        {
            BaseMember member = BaseMember.GetInstance();
            labMemberID.Text = member.ID;
            labMemberName.Text = member.Name;
        }

        private void MemberPanel_Click(object sender, EventArgs e)
        {
            this.lbMember.Visible = !this.lbMember.Visible;
        }

        private void lbMember_Click(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            int index = lbMember.SelectedIndex;
            string selectItem = lbMember.Items[index].ToString();

            if (panel3.Controls.Contains(OR))
                panel3.Controls.Remove(OR);
            if (panel3.Controls.Contains(MR))
                panel3.Controls.Remove(MR);
            if (selectItem.Equals("■ 로그아웃"))
            {
                member.Logout();
                SetlbMemberItem();
                DeletePanel();
                HeadLabelSync();
            }
            else if (selectItem.Equals("■ 로그인"))
            {
                LoginForm logForm = new LoginForm();
                DialogResult dResult = logForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    SetlbMemberItem();
                    HeadLabelSync();
                }
            }
            else if (selectItem.Equals("■ 이용현황"))
            {
                HidePanel();
                if (this.panel3.Controls.Find("StatusOfUsePanenl", false).Length == 1)
                {
                    this.panel3.Controls.Find("StatusOfUsePanenl", false)[0].Visible = true;
                    if(ListBtnUserUsingData_Event != null)
                    {
                        ListBtnUserUsingData_Event(sender, e);
                    }
                }
                else this.panel3.Controls.Add(new StatusOfUsePanenl(this));
            }
            else if (selectItem.Equals("■ 권한부여"))
            {

            }
            else if (selectItem.Equals("■ 회원생성"))
            {
                HidePanel();
                if (this.panel3.Controls.Find("MemberDataInputPanel", false).Length == 1)
                {
                    this.panel3.Controls.Find("MemberDataInputPanel", false)[0].Visible = true;
                }
                else this.panel3.Controls.Add(new MemberDataInputPanel());
            }
            else if (selectItem.Equals("■ 불량자 회원 검색"))
            {

            }
            else if (selectItem.Equals("■ 개인정보관리"))
            {
                OpenUserData_Event(sender,e);
            }
            else return;
            ChangeMemberData();
            this.lbMember.Visible = false;
        }
        private void OpenPasswardChange_Event(object sender, EventArgs e)
        {
            HidePanel();
            if (this.panel3.Controls.Find("PasswardChangePanel", false).Length == 1)
            {
                this.panel3.Controls.Find("PasswardChangePanel", false)[0].Visible = true;
                if(OpenPasswardChangePanel_Event != null)
                {
                    OpenPasswardChangePanel_Event(sender, e);
                }
            }
            else
            {
                passwardChangePanel = new PasswardChangePanel(this);
                passwardChangePanel.SavePassward_Event += OpenUserData_Event;
                this.panel3.Controls.Add(passwardChangePanel);
            }
        }
        private void OpenUserData_Event(object sender, EventArgs e)
        {
            HidePanel();
            if (this.panel3.Controls.Find("UserDataPanel", false).Length == 1)
            {
                this.panel3.Controls.Find("UserDataPanel", false)[0].Visible = true;
                if (ListBtnUserData_Event != null)
                {
                    ListBtnUserData_Event(sender, e);
                }
            }
            else
            {
                userDataPanel = new UserDataPanel(this);
                userDataPanel.btnChangePassward_Event += OpenPasswardChange_Event;
                this.panel3.Controls.Add(userDataPanel);
            }
        }
        /// <summary>
        /// 회원상태에 따라 lbMember에 item을 만들어줌
        /// </summary>
        private void SetlbMemberItem()
        {
            BaseMember member = BaseMember.GetInstance();
            lbMember.Items.Clear();
            if (member.IsLogin)
            {
                lbMember.Items.Add("■ 로그아웃");
                lbMember.Items.Add("");
                lbMember.Items.Add("■ 개인정보관리");
            }
            else
            {
                lbMember.Items.Add("■ 로그인");
            }
            if ((member.Permission&BaseMember.PERM.MEMBER_ADMIN) == BaseMember.PERM.MEMBER_ADMIN)
            {
                lbMember.Items.Add("■ 권한부여");
                lbMember.Items.Add("■ 회원생성");
            }
            lbMember.Items.Add("");
            
            if(member.IsBookAdmin)
            {
                lbMember.Items.Add("■ 불량자 회원 검색");
                lbMember.Items.Add("");
            }
            else if(member.Permission == BaseMember.PERM.NOMAL_USR)
            {
                lbMember.Items.Add("■ 이용현황");
            }
            for(int i=lbMember.Items.Count; i<7; i++)
            {
                lbMember.Items.Add("");
            }
        }

        private void HidePanel()
        {
            foreach (Control c in this.panel3.Controls)
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(ListBox) || c.GetType() == typeof(MemberDataInputPanel)
                        || c.GetType() == typeof(StatusOfUsePanenl) || c.GetType() ==  typeof(UserDataPanel) || c.GetType()==typeof(PasswardChangePanel))
                    c.Visible = false;
            }
        }
        private void DeletePanel()
        {
            HidePanel();
            foreach (Control c in this.panel3.Controls)
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(MemberDataInputPanel)
                       || c.GetType() == typeof(StatusOfUsePanenl) || c.GetType() == typeof(UserDataPanel) || c.GetType() == typeof(PasswardChangePanel))
                    panel3.Controls.Remove(c);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = System.DateTime.Now.ToString("yy-MM-dd  hh:mm");
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            member.Logout();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            member.Logout();
        }
        private void HeadLabelSync()
        {
            BaseMember member = BaseMember.GetInstance();
            if (member.IsLogin)
            {
                labLoginState.Text = member.Name+"(님)으로 로그인 중입니다.";
                if (member.IsBookAdmin)
                {
                    labPerm.Text = "사용권한 : 사서관리자";
                }
                else if (member.IsMeetingRoomAdmin)
                {
                    labPerm.Text = "사용권한 : 회의실관리자";
                }
                else if (member.IsReadingRoomAdmin)
                {
                    labPerm.Text = "사용권한 : 열람실관리자";
                }
                else
                {
                    labPerm.Text = "사용권한 : 일반사용자";
                }
            }
            else
            {
                labLoginState.Text = "로그인을 해주세요.";
                labPerm.Text = "사용권한 : 비회원 사용자";
            }
        }
    }
}
