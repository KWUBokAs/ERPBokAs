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
        string a="OR001";
        List<Control> OR1 = new List<Control>();
        ORoomAct o = new ORoomAct();
        
        public OpenRoom()
        {
            InitializeComponent();
        }

        private void OpenRoom_Load(object sender, EventArgs e)
        {
            
            int s =o.ReadRoomCount(a);
            
            for(int i = 1 ; i <=o.ReadRoomCount(a); i++)
            {
                Sseat seat = new Sseat(i);
                panel2.Controls.Add(seat);
                seat.Location = seat.GetPoint();
                
                
                OR1.Add(seat);
            }
            
            

        }
    }
}
