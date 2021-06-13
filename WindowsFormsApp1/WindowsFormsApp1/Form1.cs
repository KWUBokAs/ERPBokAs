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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        IMGSQLObject mysqlObj;
        public Form1() {
            InitializeComponent();
            mysqlObj = new IMGSQLObject();

        }

    }
}
