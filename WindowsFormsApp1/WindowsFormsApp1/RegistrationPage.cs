﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegistrationPage : UserControl
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationPage_Load(object sender, EventArgs e)
        {
            string[] types = { "단행본", "e북", "오디오북", "논문" };

            cmbTypes.Items.AddRange(types);

            cmbTypes.SelectedIndex = 0;
        }
    }
}
