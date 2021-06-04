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

namespace WindowsFormsApp1
{
    public partial class Seat : UserControl
    {
        public int SeatNum;
        public bool used;
        public Point SeatPoint;
        public Seat()
        {
            InitializeComponent();
        }
    }
}
