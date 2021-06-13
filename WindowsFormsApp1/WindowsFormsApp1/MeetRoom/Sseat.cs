using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MeetRoom;
using WindowsFormsApp1.MEMBER;



namespace WindowsFormsApp1.MeetRoom
{
    public partial class Sseat : UserControl
    {
        public int SeatNum;
        public bool used;
        public Point SeatPoint;
        public int RoomID;
        public string UserID;

        BaseMember bm = BaseMember.GetInstance();
        SeatAct Sa = new SeatAct();

        public Sseat(int RoomNum,int num)
        {
            InitializeComponent();
            SeatNum = num;
            RoomID = RoomNum; 
            SeatPoint = Sa.ReadSeatPoint("OR00" + RoomNum.ToString(), num.ToString());
            used = Sa.ReadSeatUsed("OR00"+ RoomNum.ToString(), num.ToString());
            
            UserID = bm.ID;

           
        }

        private void Sseat_Load(object sender, EventArgs e)
        {
            if (!used)
                pictureBox1.Image = imageList1.Images[1];
            else
                pictureBox1.Image = imageList1.Images[0];
            lblSN.Text = SeatNum.ToString();
        }
        public Point GetPoint()
        {
            return SeatPoint;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            BaseMember member = BaseMember.GetInstance();
            if (!member.IsLogin)
            {
                MessageBox.Show("로그인 중이 아닙니다. 로그인 후 사용하여 주세요.");
            }
            else
            {
                if (!used)
                {
                    SeatReserve Sr = new SeatReserve(SeatNum);
                    Sr.Show();
                    Sr.Reserve_Event += reserveBtn_Event; 
                }
                else
                {
                    SeatReserve2 Sr = new SeatReserve2();
                    Sr.Seatnum = SeatNum;
                    Sr.Roomnum = RoomID;
                    Sr.UID = UserID;
                    Sr.Show();
                }
            }
            // used 를 판별해서 if 자리가 사용중이면 폼 1
            // 자리가 비어있으면 폼 2  폼에 띄울내용 사용중이면 남은 시간 출력하고 연장 카운트 띄우고
            // 처음엔 다 사용안함 그러다가 아이디로 예약 하기 만약에 로그인이 안되어있으면 로그인을 하고 사용해주세요 하기
        }
        
        public void reserveBtn_Event(object sender,EventArgs e)
        {   SeatRrvAct sr = new SeatRrvAct();
            if (Sa.ReadSeatUsed("OR00" + RoomID.ToString(), SeatNum.ToString()))
                MessageBox.Show("이 좌석은 이미 사용중입니다.");
            else { 
            if (sr.ReadSeatReserveUsed(UserID)) { 
            used = true;
            Sa.UpdateSeat("OR00" + RoomID.ToString(), SeatNum.ToString(),used);
            Sa.InsertSeatRsv("OR00" + RoomID.ToString(), SeatNum.ToString(),UserID);
            pictureBox1.Image = imageList1.Images[0];
            }
            else
            {
                MessageBox.Show("이미 사용중인 좌석이 존재하여 추가로 이용은 불가능합니다.");
            }
            }
        }
        
    }
}
