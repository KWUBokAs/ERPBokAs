using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MEMBER
{
    public partial class PasswardChangePanel : UserControl
    {
        private Form3 parent;
        public EventHandler SavePassward_Event;
        public PasswardChangePanel(Form3 form3)
        {
            parent = form3;
            InitializeComponent();
        }

        private void PasswardChangePanel_Load(object sender, EventArgs e)
        {
            txtNew.PasswordChar = '*';
            txtCheck.PasswordChar = '*';
            txtOrigin.PasswordChar = '*';
        }
    }
}
