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
            ChangeMemberData();
            SetlbMemberItem();
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
            }
            else if (selectItem.Equals("■ 로그인"))
            {
                LoginForm logForm = new LoginForm();
                DialogResult dResult = logForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    SetlbMemberItem();
                }
            }
            else if (selectItem.Equals("■ 이용현황"))
            {

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

            }
            else return;
            ChangeMemberData();
            this.lbMember.Visible = false;
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
        }

        private void HidePanel()
        {
            foreach (Control c in this.panel3.Controls)
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(ListBox) || c.GetType() == typeof(MemberDataInputPanel))
                    c.Visible = false;
            }
        }
    }
}
