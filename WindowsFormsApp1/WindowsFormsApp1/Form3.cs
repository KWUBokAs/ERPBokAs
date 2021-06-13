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
using WindowsFormsApp1.BOOK;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Control OR = new OpenRoom();
        Control MR = new Meet();

        public event EventHandler ListBtnUserUsingData_Event;
        public event EventHandler ListBtnUserData_Event;
        //public event EventHandler ListBtnBadSearch_Event;
        public event EventHandler BarcodeClick_Event;
        public event EventHandler OpenPasswardChangePanel_Event;

        private UserDataPanel userDataPanel;
        private PasswardChangePanel passwardChangePanel;

        private string day;
        const int AUTO_LOGOUT_TIME = 2;//자동 로그아웃창을 띄우는 시간
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.listBox1.Visible = !this.listBox1.Visible;
        }


        private string barcodePageOfTitle;
        public string BarcodePageTitle { get { return barcodePageOfTitle; } }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(OR))
                panel3.Controls.Remove(OR);
            if (panel3.Controls.Contains(MR))
                panel3.Controls.Remove(MR);
            int index = listBox1.SelectedIndex;
            //if (index >= 0 && index < listBox1.Items.Count) return;
            string selectItem = listBox1.Items[index].ToString();
            if (selectItem.Equals("■ 검색"))
            {
                HidePanel();

                if (this.panel3.Controls.Find("SearchPage", false).Length == 1)
                {
                    this.panel3.Controls.Find("SearchPage", false)[0].Visible = true;
                }
                else this.panel3.Controls.Add(new SearchPage());
                this.Size = new Size(848, 565);
            }
            else if (selectItem.Equals("■ 바코드 대여"))
            {
                PopBarcodePage("도서 대여");
            }
            else if (selectItem.Equals("■ 등록"))
            {
                HidePanel();

                if (this.panel3.Controls.Find("RegistrationPage", false).Length == 1)
                {
                    this.panel3.Controls.Find("RegistrationPage", false)[0].Visible = true;
                }
                else this.panel3.Controls.Add(new RegistrationPage());
                this.Size = new Size(848, 580);
            }
            else if (selectItem.Equals("■ 바코드 반납"))
            {
                PopBarcodePage("도서 반납");

            }
            else return;
            this.listBox1.Visible = false;
        }
        private void PopBarcodePage(string title)
        {
            HidePanel();
            barcodePageOfTitle = title;
            if (this.panel3.Controls.Find("BarCode", false).Length == 1)
            {
                this.panel3.Controls.Find("BarCode", false)[0].Visible = true;
                if (BarcodeClick_Event != null)
                {
                    BarcodeClick_Event(null, null);
                }
            }
            else this.panel3.Controls.Add(new BarCode(this));
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
            labTime.Text = System.DateTime.Now.ToString("yy-MM-dd  hh:mm");
            SetlbMemberItem();
            SetBookMenuItem();
            HeadLabelSync();
            PopStartPanel();
        }

        private void MemberPanel_Click(object sender, EventArgs e)
        {
            this.lbMember.Visible = !this.lbMember.Visible;
        }
        private void Logout()
        {
            BaseMember member = BaseMember.GetInstance();
            member.Logout();
            SetlbMemberItem();
            SetBookMenuItem();
            DeletePanel();
            HeadLabelSync();
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
                Logout();
            }
            else if (selectItem.Equals("■ 로그인"))
            {
                LoginForm logForm = new LoginForm();
                DialogResult dResult = logForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    SetlbMemberItem();
                    SetBookMenuItem();
                    //DeletePanel();
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

                this.Size = new Size(848, 468);
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
                this.Size = new Size(848, 468);
            }
            else if (selectItem.Equals("■ 연체도서 반납"))
            {
                HidePanel();
                if (this.panel3.Controls.Find("BadMemberSearch", false).Length == 1)
                {
                    this.panel3.Controls.Find("BadMemberSearch", false)[0].Visible = true;
                    //if(ListBtnBadSearch_Event != null)
                    //{
                    //    ListBtnBadSearch_Event(sender, e);
                    //}
                }
                else this.panel3.Controls.Add(new BadMemberSearch(this));
                this.Size = new Size(848, 468);
            }
            else if (selectItem.Equals("■ 개인정보관리"))
            {
                OpenUserData_Event(sender,e);
            }
            else return;
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

            this.Size = new Size(848, 468);
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

            this.Size = new Size(848, 468);
        }
        private void SetBookMenuItem()
        {
            BaseMember member = BaseMember.GetInstance();
            listBox1.Items.Clear();

            listBox1.Items.Add("■ 검색");
            if (member.Permission == BaseMember.PERM.NOMAL_USR && member.CanRentBook)//일반유저이고 베드맴버가 아닐때 바코드 대여 가능
            {
                listBox1.Items.Add("");
                listBox1.Items.Add("■ 바코드 대여");
            }
            if (member.IsBookAdmin)
            {
                listBox1.Items.Add("");
                listBox1.Items.Add("■ 등록");
                listBox1.Items.Add("");
                listBox1.Items.Add("■ 바코드 반납");
            }
            for(int i=listBox1.Items.Count; i<3; i++)
            {
                listBox1.Items.Add("");
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
                lbMember.Items.Add("■ 연체도서 반납");
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

        private void PopStartPanel()
        {
            if (this.panel3.Controls.Find("StartPanel", false).Length == 1)
            {
                this.panel3.Controls.Find("StartPanel", false)[0].Visible = true;
            }
            else this.panel3.Controls.Add(new StartPanel());
            this.Size = new Size(848, 468);
        }
        private void HidePanel()
        {
            foreach (Control c in this.panel3.Controls)
            {
                if (c.GetType() == typeof(StartPanel) || c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(ListBox) || c.GetType() == typeof(MemberDataInputPanel)
                        || c.GetType() == typeof(StatusOfUsePanenl) || c.GetType() ==  typeof(UserDataPanel) || c.GetType()==typeof(PasswardChangePanel)
                        || c.GetType() == typeof(BadMemberSearch) || c.GetType()==typeof(BarCode))
                    c.Visible = false;
            }
        }
        private void DeletePanel()
        {
            HidePanel();
            foreach (Control c in this.panel3.Controls)
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(MemberDataInputPanel)
                       || c.GetType() == typeof(StatusOfUsePanenl) || c.GetType() == typeof(UserDataPanel) || c.GetType() == typeof(PasswardChangePanel)
                       || c.GetType() == typeof(BadMemberSearch) || c.GetType() == typeof(BarCode))
                    panel3.Controls.Remove(c);
            }
            PopStartPanel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = System.DateTime.Now.ToString("yy-MM-dd  hh:mm");
            if (!this.ContainsFocus) return;//포커스가 안가있다면 아무것도 안함
            if (day != DateTime.Now.ToString("yy-MM-dd"))//날짜 변경시 자동업데이트 
            {
                UpdateOverdueBook();
                UpdateBadMember();
                day = DateTime.Now.ToString("yy-MM-dd");
                Options options = Options.GetInstance();
                this.ResetText();
                this.Text = options.NM;
                timer1.Interval = 10000;
            }
            BaseMember member = BaseMember.GetInstance();
            if (member.Permission == BaseMember.PERM.NOMAL_USR)//노멀 유저인 경우에만 자동 로그아웃
            {
                TimeSpan timeSpan = DateTime.Now - DateTime.Parse(member.LoginTime);
                if(timeSpan.Minutes >= AUTO_LOGOUT_TIME)//정해진 시간이 경과하면
                {
                    LogOutQnAForm logOut = new LogOutQnAForm();
                    DialogResult dResult = logOut.ShowDialog();
                    if (dResult == DialogResult.OK)//로그인을 유지하면
                    {
                        member.ResetLoginTime();
                    }
                    else//유지하지 않으면
                    {
                        Logout();
                    }
                }
            }

        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            Logout();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            Logout();
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
        private void UpdateOverdueBook()
        {
            try
            {
                SQLObject updateSQL = new BACK.SQLObject();
                updateSQL.setQuery("UPDATE `BOOKRENTS` " +
                                    "SET OVERDUE_YN='1' " +
                                    "WHERE " +
                                            "`RETURN_DT`<@NOW_DATE " +
                                            "AND RENT_YN='0' " +
                                            "AND OVERDUE_YN='0'");
                updateSQL.AddParam("NOW_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                updateSQL.Go();
            }
            catch
            {
                MessageBox.Show("DB접속이 원활하지 않습니다.", "DB접속 오류");
            }
        }
        private void UpdateBadMember()
        {
            JArray jarray=null;
            try//연체료 납부할 것이 더 있는지 확인인
            {
                SQLObject selectSQL = new BACK.SQLObject();
                selectSQL.setQuery("SELECT USER_ID, COUNT(USER_ID) AS 'CNT' " +
                                    "FROM `BOOKRENTS` " +
                                    "WHERE " +
                                            "OVERDUE_YN='1' " +
                                            "AND RENT_YN='0' " +
                                    "GROUP BY USER_ID");
                selectSQL.Go();
                jarray = selectSQL.ToJArray();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ": DB접속이 불안정합니다.", "DB접속 오류");
                return;
            }
            if (jarray == null || jarray.Count == 0) return;//없을경우

            List<string> userid = new List<string>();
            foreach(JToken item in jarray)
            {
                int cnt = item.Value<int>("CNT");
                if(cnt > 0)//cnt 1개 이상 있다면
                {
                    userid.Add(item.Value<string>("USER_ID"));
                }
            }
            foreach(string USER_ID in userid)
            {
                try
                {
                    SQLObject updateSQL = new BACK.SQLObject();

                    updateSQL.setQuery("UPDATE `USER` " +
                                    "SET `BAD_YN`='y' " +
                                    "WHERE " +
                                            "USER_ID = @USER_ID");
                    updateSQL.AddParam("USER_ID", USER_ID);
                    updateSQL.Go();

                }
                catch
                {
                    MessageBox.Show("DB접속이 원활하지 않습니다.", "DB접속 오류");
                }
            }
        }
    }
}
