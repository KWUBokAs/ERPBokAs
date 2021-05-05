using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.BACK {
    public partial class LoadingForm : Form {
        private Image gifimage;
        public LoadingForm() {
            InitializeComponent();
            //gifimage = Image.FromFile("Resources://loading.gif");
        }
    }
}
