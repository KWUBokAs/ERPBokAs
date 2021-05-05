using System;
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
    public partial class BookInfoDetail : UserControl
    {
        public BookInfoDetail()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
        }
    }
}
