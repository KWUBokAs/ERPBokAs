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



namespace WindowsFormsApp1
{
    public partial class OpenRoom : UserControl
    {
        public string RoomName="OR00";
        public int RoomNum = 1;

        List<Control> OR1 = new List<Control>();
        ORoomAct o = new ORoomAct();
        
        public OpenRoom()
        {
            InitializeComponent();
        }

        private void OpenRoom_Load(object sender, EventArgs e)
        {
            
            string a = RoomName + RoomNum.ToString();
            int s =o.ReadRoomCount(a);
            
            for(int i = 1 ; i <=o.ReadRoomCount(a); i++)
            {
                Sseat seat = new Sseat(RoomNum,i);
                panel2.Controls.Add(seat);
                seat.Location = seat.GetPoint();
                
                
                OR1.Add(seat);
            }
             RoomName = "OR00";
        }

        private void btnRN_Click(object sender, EventArgs e)
        {   if (RoomNum == 3)
                RoomNum = 0;
            RoomNum++;
            btnRN.Text = "제" + RoomNum.ToString() + "열람실";
            panel2.Controls.Clear();
            OpenRoom_Load(sender,e);
        }
    }
}
