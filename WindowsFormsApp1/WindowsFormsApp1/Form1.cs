﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Console.Write("Hello, World!");
            this.label1.Text = "Hello, World!";
        }

        private void bookSearchPage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form showForm = new bookSearchPage();
            showForm.ShowDialog();
        }
    }
}
