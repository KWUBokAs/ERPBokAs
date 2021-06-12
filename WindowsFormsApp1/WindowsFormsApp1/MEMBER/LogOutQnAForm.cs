using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MEMBER
{
    /// <summary>
    /// DialogResult가 Ok이면 로그인 유지
    /// cancel이면 로그아웃이다.
    /// </summary>
    public partial class LogOutQnAForm : Form
    {
        const int LIMIT_TIME = 9;
        int time;
        bool continueLogin = false;//ture 유지 false logout
        public LogOutQnAForm()
        {
            InitializeComponent();
            continueLogin = false;
            time = LIMIT_TIME;
        }
        private void LogOutQnAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (continueLogin)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            labTime.Text = time.ToString()+"초 후 자동 Logout";
            if (time<0) Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            continueLogin = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
