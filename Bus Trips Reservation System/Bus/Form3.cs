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
    public partial class Form3 : Form
    {
        string ordb = "Data Source=orcl;user id=scott;password=tiger;";
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Trip_ID From Trip";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbTrip.Items.Add(dr[0]);
            }
            dr.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
                try
                {
                btnUpdate.Enabled = true;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into FeedBack values (:id,:descreption,:customerID,:tripID)";
                    cmd.Parameters.Add("id", 2);
                    cmd.Parameters.Add("descreption", txtDes.Text);
                    cmd.Parameters.Add("customerID", Form4.globalCustomerID);
                    cmd.Parameters.Add("tripID", cmbTrip.SelectedItem);
                    int cheak = cmd.ExecuteNonQuery();
                    if (cheak != -1)
                    {
                        string message = "FeedBack is Send";
                        string title = "Sned FeedBack";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    }
                }

                catch (Exception ex)
                {
                    string message = ex.ToString();
                    string title = "ERROR Window";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                }
            
        }

        private void txtDes_Enter(object sender, EventArgs e)
        {
            if (txtDes.Text == "write your nessage")
            {
                txtDes.Text = "";
                txtDes.ForeColor = Color.Black;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
