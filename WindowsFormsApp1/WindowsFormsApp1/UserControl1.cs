using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class UserControl1 : UserControl {

        bool isSmall = false;
        Form2 myparent;
        public UserControl1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //size Control
            if (!isSmall) { //big -> small
                myparent.setSizeLittle();
                button1.Height = 64; //144 64
                isSmall = true;
            } else {    //small -> big
                myparent.setSizeBig();
                button1.Height = 144; //144 64
                isSmall = false;
            }

        }

        private void UserControl1_Load(object sender, EventArgs e) {

            myparent = this.ParentForm as Form2;
            Console.WriteLine("User Control1 Attatched on Form2!");
        }
    }
}
