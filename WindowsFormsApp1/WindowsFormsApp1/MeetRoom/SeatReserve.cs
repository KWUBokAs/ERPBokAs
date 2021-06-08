﻿using System;
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
    public partial class SeatReserve : Form
    {
        public event EventHandler Reserve_Event;
        public int SeatNum;
        public int end = 0;
        public SeatReserve(int n)
        {
            InitializeComponent();
            this.SeatNum = n;

            button1.Click += reserveBtn_Event;
            button1.DoubleClick += reserveBtn_Event;
            
        }

        private void SeatReserve_Load(object sender, EventArgs e)
        {
            lblSeat.Text = SeatNum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void reserveBtn_Event(object sender,EventArgs e)
        {
            if (this.Reserve_Event != null)
                Reserve_Event(sender, e);
            Close();
        }
    }
}
