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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.MeetRoom;
using WindowsFormsApp1.MEMBER;



namespace WindowsFormsApp1
{
    public partial class OpenRoom : UserControl
    {
        public string RoomName="OR00";
        public int RoomNum = 1;

        List<Control> OR1 = new List<Control>();
        ORoomAct o = new ORoomAct();
        BaseMember bm = BaseMember.GetInstance();
        
        public OpenRoom()
        {
            InitializeComponent();
        }

        private void OpenRoom_Load(object sender, EventArgs e)
        {
            BaseMember bm = BaseMember.GetInstance();
            label1.Text = "열람실 이용 정보 : " + o.ReadSeatInf(bm.ID);
            label2.Text = "좌석 이용 종료 시간 : " + o.ReadEndTime(bm.ID);

            string a = RoomName + RoomNum.ToString();
            int s =o.ReadRoomCount(a);
            o.AddImage(a, pictureBox2);
            for(int i = 1 ; i <=o.ReadRoomCount(a); i++)
            {
                Sseat seat = new Sseat(RoomNum,i);
                panel2.Controls.Add(seat);
                seat.Location = seat.GetPoint();
                seat.FormRepair += ReroadForm;
                OR1.Add(seat);
            }
            pictureBox2.SendToBack();
             RoomName = "OR00";
        }

        private void btnRN_Click(object sender, EventArgs e)
        {   if (RoomNum == 3)
                RoomNum = 0;
            RoomNum++;
            btnRN.Text = "제" + RoomNum.ToString() + "열람실";
            panel2.Controls.Clear();
            panel2.Controls.Add(pictureBox2);
            OpenRoom_Load(sender,e);
        }
        public void ReroadForm(object sender,EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(pictureBox2);
            OpenRoom_Load(sender, e);
        }
    }
}
