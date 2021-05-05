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
    public partial class Form3 : Form
    {
        Control OR = new OpenRoom();
        Control MR = new MeetRoom();

        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.listBox1.Visible = !this.listBox1.Visible;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(OR))
                panel3.Controls.Remove(OR);
            if (panel3.Controls.Contains(MR))
                panel3.Controls.Remove(MR);
            switch (this.listBox1.SelectedIndex)
            {
                case 0:
                    foreach (Control c in this.panel3.Controls)
                    {
                        if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(ListBox))
                            c.Visible = false;
                    }

                    if (this.panel3.Controls.Find("SearchPage", false).Length == 1)
                    {
                        this.panel3.Controls.Find("SearchPage", false)[0].Visible = true;
                        break;
                    }
                    this.panel3.Controls.Add(new SearchPage());
                    break;

                case 2:
                    foreach (Control c in this.panel3.Controls)
                    {
                        if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage) || c.GetType() == typeof(ListBox))
                            c.Visible = false;
                    }

                    if (this.panel3.Controls.Find("RegistrationPage", false).Length == 1)
                    {
                        this.panel3.Controls.Find("RegistrationPage", false)[0].Visible = true;
                        break;
                    }
                    this.panel3.Controls.Add(new RegistrationPage());
                    break;

                default:
                    this.listBox1.SelectedIndex = -1;
                    break;
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = WindowsFormsApp1.Properties.Resources.도서_호버;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = WindowsFormsApp1.Properties.Resources.책;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApp1.Properties.Resources.열람실_호버;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = WindowsFormsApp1.Properties.Resources.열람실;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = WindowsFormsApp1.Properties.Resources.회의실_호버;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = WindowsFormsApp1.Properties.Resources.회의실;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel3.Controls)
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage))
                    c.Visible = false;
            }
            if (panel3.Controls.Contains(OR)) { 
                panel3.Controls.Remove(OR);
            }
            else
                panel3.Controls.Add(OR);

            if (panel3.Controls.Contains(MR))
            {
                panel3.Controls.Remove(MR);
            }
        }

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {   
            foreach (Control c in panel3.Controls) 
            {
                if (c.GetType() == typeof(SearchPage) || c.GetType() == typeof(RegistrationPage))
                    c.Visible = false;
            }
            if (panel3.Controls.Contains(MR)) { 
                panel3.Controls.Remove(MR);
            }
            else
                panel3.Controls.Add(MR);

            if (panel3.Controls.Contains(OR))
            {
                panel3.Controls.Remove(OR);
            }
        }
    }
}
