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
namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        SQLObject mysqlObj;
        public Form1() {
            InitializeComponent();
            mysqlObj = new SQLObject();

        }

        private void button1_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(this.richTextBox1.Text))
                return;
            mysqlObj.setQuery(this.richTextBox1.Text);
            mysqlObj.Go();
            this.label2.Text = "Done!";

        }

        private void bookSearchPage_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form showForm = new bookSearchPage();
            showForm.ShowDialog();
        }
    }
}
