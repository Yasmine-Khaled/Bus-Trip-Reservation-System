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
    public partial class Form4 : Form
    {
        public static int globalCustomerID;
        string ordb = "Data Source=orcl;user id=scott;password=tiger;";
        OracleConnection conn;
        public Form4()
        {
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                {


                    string name = textBox2.Text.ToString();
                    string password = textBox1.Text.ToString();
                    string sql = "SELECT COUNT(*) FROM Customer WHERE Name = :name AND Password = :password";
                    OracleCommand command = new OracleCommand(sql, conn);
                    command.Parameters.Add(new OracleParameter("Name", name));
                    command.Parameters.Add(new OracleParameter("password", password));
                    command.ExecuteNonQuery();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    OracleDataReader dr = command.ExecuteReader();
                   
                    if (count > 0)
                    {

                        int customerID=0;
                        string message = "HELLO";
                        string title = "Login Window";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                        string sql2 = "SELECT Customer_ID FROM Customer WHERE Name = :name";
                        OracleCommand command2 = new OracleCommand(sql2, conn);
                        command2.Parameters.Add(new OracleParameter("name", name));
                        OracleDataReader reader = command2.ExecuteReader();
                        if (reader.Read())
                        {
                            customerID = Convert.ToInt32(reader["Customer_ID"].ToString());
                            dr.Close();
                            globalCustomerID = customerID;
                        }
                        Form1 form = new Form1();
                        this.Hide();
                        form.ShowDialog();
                    }
                    else
                    {
                        string message = "There Are Mistake Sure You Are SignUp";
                        string title = "Login Window";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    }
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

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncansel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
