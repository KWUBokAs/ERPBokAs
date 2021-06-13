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



namespace WindowsFormsApp1.MeetRoom
{
    public partial class SeatReserve2 : Form
    {
        public EventHandler ExitClick;
        public EventHandler Ban;
        public EventHandler Prevent;
        public int Roomnum;
        public int Seatnum;
        public string UID;

        SeatRrvAct sr = new SeatRrvAct();
        SeatAct sa = new SeatAct();

        BaseMember BM = BaseMember.GetInstance();
        public SeatReserve2()
        {
            InitializeComponent();

            button1.Click += Prevent_Event;
            button2.Click += Prevent_Event;
            button3.Click += Exit_Event;
            button3.DoubleClick += Exit_Event;
            button4.Click += Ban_Event;
            button4.DoubleClick += Ban_Event;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SeatReserve2_Load(object sender, EventArgs e)
        {
            lblUserName.Text = sr.GetName("OR00" + Roomnum.ToString(),Seatnum.ToString());
            lblEndTime.Text = sr.GetTime("OR00" + Roomnum.ToString(), Seatnum.ToString());
            lblExtend.Text = "연장요청 : " + sr.GetExtend("OR00" + Roomnum.ToString(), Seatnum.ToString()) + " 회";

            if(UID == sr.GetUserID("OR00" + Roomnum.ToString(), Seatnum.ToString()))
            {
                button2.Visible = true;
                button3.Visible = true;
            }
            if (BM.IsReadingRoomAdmin)
            {
                button4.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sr.UpExtend("OR00" + Roomnum.ToString(), Seatnum.ToString());
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sa.UpdateSeat("OR00" + Roomnum.ToString(), Seatnum.ToString(),false);
            sr.ExitSeat(sr.GetUserID("OR00" + Roomnum.ToString(), Seatnum.ToString()), 0);
            Close();
        }
        public void Exit_Event(object sender, EventArgs e)
        {
            if (this.ExitClick != null)
                ExitClick(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sa.UpdateSeat("OR00" + Roomnum.ToString(), Seatnum.ToString(), false);
            sr.ExitSeat(sr.GetUserID("OR00" + Roomnum.ToString(), Seatnum.ToString()), 0);
            Close();
        }
        public void Ban_Event(object sender, EventArgs e)
        {
            if (this.Ban != null)
                Ban(sender, e);
        }
        public void Prevent_Event(object sender, EventArgs e)
        {
            if (this.Prevent != null)
                Prevent(sender, e);
        }
    }
}
