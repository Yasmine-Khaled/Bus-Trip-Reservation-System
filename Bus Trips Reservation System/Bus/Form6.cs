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
    public partial class Form6 : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;
        OracleCommandBuilder builder;
        public Form6()
        {
            InitializeComponent();
            textBox1.Text = Form4.globalCustomerID.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constr = "Data Source=orcl;user id=scott;password=tiger;";
            String cmdstr = @"select * from RESERVETRIP
               where CUSTOMER_ID =:id ";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Trip Table Updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
