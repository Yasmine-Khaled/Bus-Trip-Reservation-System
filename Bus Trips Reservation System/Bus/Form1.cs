using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Bus
{
    public partial class Form1 : Form
    {
        Form2 Admin = new Form2();
        Form3 feedBack = new Form3();
        Form6 serach = new Form6();
        Form5 mod = new Form5();
        Form7 hisCostomer = new Form7();
        Form8 hisAdmin = new Form8();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            nav.Controls.Clear();
            nav.Controls.Add(Admin.flowLayoutPanel3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
            Admin.flowLayoutPanel3.Size = nav.Size;
            feedBack.flowLayoutPanel1.Size = nav.Size;
            serach.panel1.Size = nav.Size;
            mod.panel1.Size = nav.Size;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nav.Controls.Clear();
            nav.Controls.Add(feedBack.flowLayoutPanel1);
            //label1.Text = btn.Text;
        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            nav.Controls.Clear();
            nav.Controls.Add(mod.panel1);
            //label1.Text = btn.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nav.Controls.Clear();
            nav.Controls.Add(serach.panel1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nav.Controls.Clear();
            nav.Controls.Add(mod.panel1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hisCostomer.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            hisAdmin.ShowDialog();
        }
    }
}
