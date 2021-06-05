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


namespace WindowsFormsApp1.MeetRoom
{
    public partial class Sseat : UserControl
    {
        public int SeatNum;
        public bool used;
        public Point SeatPoint;
        
        
        public Sseat(int RoomNum,int num)
        {
            InitializeComponent();
            SeatNum = num;
            SeatAct Sa = new SeatAct();
            SeatPoint = Sa.ReadSeatPoint("OR00" + RoomNum.ToString(), num.ToString());
            used = Sa.ReadSeatUsed("OR00"+ RoomNum.ToString(), num.ToString());
           
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
    }
}
