using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form2 : Form {
        public const int panel2locdef = 232;
        public const int panel1heightdef = 183;
        public const int panel1changesize = 70;
        public Form2() {
            InitializeComponent();
            this.Load += UserControlShow;
        }
        private void UserControlShow(Object Sender, EventArgs e) {
            UserControl user = new UserControl1();
            panel1.Controls.Add(user);
        }
        public void setSizeLittle() {
            Console.WriteLine("set Size small");
            panel1.Height -= panel1changesize;
            panel2.Top = panel2locdef - panel1changesize;
        }
        public void setSizeBig() {
            Console.WriteLine("set Size Big");
            panel1.Height += panel1changesize;
            panel2.Top = panel2locdef;
        }
    }
}
