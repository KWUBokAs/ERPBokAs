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
            mysqlObj.Dispose();
            //DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(mysqlObj.jArray.ToString());
            //dataTable.TableName = "Test Table";
            //dataGridView1.DataSource = dataTable;
            //this.label2.Text = "Done!";

        }
    }
}
