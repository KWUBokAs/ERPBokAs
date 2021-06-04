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
        List<Control> OR1 = new List<Control>();
        
        public OpenRoom()
        {
            InitializeComponent();
        }

        private void OpenRoom_Load(object sender, EventArgs e)
        {
            Sseat s;
        }
    }
}
