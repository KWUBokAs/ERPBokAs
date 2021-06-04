using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MeetRoom
{
    public partial class Sseat : UserControl
    {
        public int SeatNum;
        public bool used;
        public Point SeatPoint;
        public Sseat()
        {
            InitializeComponent();
        }

        private void Sseat_Load(object sender, EventArgs e)
        {
            if (!used)
            {

            }
        }
    }
}
