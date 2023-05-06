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
    public partial class Form2 : Form
    {
        string ordb = "Data Source=ORCL;user id=scott;password=tiger;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Bus_ID From Bus";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBusID.Items.Add(dr[0]);
            }
            dr.Close();
            cmd.Connection = conn;
            cmd.CommandText = "select ADMINISTRATOR_ID From ADMINISTRATOR";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbAdminID.Items.Add(dr[0]);
            }
            dr.Close();

            cmd.Connection = conn;
            cmd.CommandText = "select RESERVEDTRIP_ID From RESERVETRIP";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbRes.Items.Add(dr[0]);
            }
            dr.Close();


            cmd.Connection = conn;
            cmd.CommandText = "select Trip_ID From Trip";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbTrip.Items.Add(dr[0]);
            }
            dr.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Bus_ID From Bus";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBusID.Items.Add(dr[0]);
            }
            dr.Close();
            cmd.Connection = conn;
            cmd.CommandText = "select ADMINISTRATOR_ID From ADMINISTRATOR";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbAdminID.Items.Add(dr[0]);
            }
            dr.Close();

            cmd.Connection = conn;
            cmd.CommandText = "select TRIP_ID From trip";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbTrip.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void cmbBusID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select BUS_ROUTE From Bus where Bus_ID=:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", cmbBusID.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtRoute.Text = dr["Bus_Route"].ToString();
            }
            dr.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Update BUS set Bus_Route=:Route where Bus_ID=:id";
                cmd.Parameters.Add("name", txtRoute.Text);
                cmd.Parameters.Add("id", cmbBusID.SelectedItem.ToString());
                int cheak = cmd.ExecuteNonQuery();
                if (cheak != -1)
                {
                    string message = "Update is Done";
                    string title = "Update Window";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Driver values (:id,:name,:age,:phone,:Birth,:admin)";
                cmd.Parameters.Add("id", txtDrID.Text);
                cmd.Parameters.Add("name", txtDrName.Text);
                cmd.Parameters.Add("age", txtDrAge.Text);
                cmd.Parameters.Add("phone", txtDrPhone.Text);
                cmd.Parameters.Add("Birth", DateTime.Parse(dateTimeDR.Value.ToString("dd - MMM - yyyy")));
                cmd.Parameters.Add("Admin", cmbAdminID.Text);
                int cheak = cmd.ExecuteNonQuery();
                if (cheak != -1)
                {
                    string message = "Insert is Done";
                    string title = "Insert Window";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                string message = ex.ToString();
                string title = "ERROR Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OracleCommand command = new OracleCommand("viewBooking", conn);
            command.CommandType = CommandType.StoredProcedure;

            // Input parameter
            OracleParameter customerIdParam = new OracleParameter("CUSTOMERID", OracleDbType.Int32);
            customerIdParam.Value = int.Parse(cmbRes.SelectedItem.ToString()); // Replace with the actual customer ID
            customerIdParam.Direction = ParameterDirection.Input;
            command.Parameters.Add(customerIdParam);

            // Output parameters
            OracleParameter reservedTripIdParam = new OracleParameter("RESERVEDTRIPID", OracleDbType.Int32);
            reservedTripIdParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(reservedTripIdParam);

            OracleParameter tripDateParam = new OracleParameter("TRIPDATE", OracleDbType.Date);
            tripDateParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(tripDateParam);

            OracleParameter numOfSeatsParam = new OracleParameter("NUMOFSEATS", OracleDbType.Int32);
            numOfSeatsParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(numOfSeatsParam);

            OracleParameter statusParam = new OracleParameter("STAT", OracleDbType.Varchar2, 100);
            statusParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(statusParam);

            OracleParameter busIdParam = new OracleParameter("BUSID", OracleDbType.Int32);
            busIdParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(busIdParam);

            OracleParameter tripIdParam = new OracleParameter("TRIPID", OracleDbType.Int32);
            tripIdParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(tripIdParam);

            command.ExecuteNonQuery();

            // Retrieve the output parameter values
            int reservedTripId = Convert.ToInt32(command.Parameters["RESERVEDTRIPID"].Value.ToString());
            DateTime tripDate = Convert.ToDateTime(command.Parameters["TRIPDATE"].Value.ToString());
            int numOfSeats = Convert.ToInt32(command.Parameters["NUMOFSEATS"].Value.ToString());
            string status = command.Parameters["STAT"].Value.ToString();
            int busId = Convert.ToInt32(command.Parameters["BUSID"].Value.ToString());
            int tripId = Convert.ToInt32(command.Parameters["TRIPID"].Value.ToString());

            dataGridView1.Rows.Add(reservedTripId.ToString(),tripDate.ToString(),numOfSeats.ToString(),status,busId.ToString(),tripId.ToString());


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetFeedback";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Trip_ID", cmbTrip.SelectedItem);
                cmd.Parameters.Add("FEEDBACK_DESCRIPTION",OracleDbType.RefCursor,ParameterDirection.Output);
                OracleDataReader dr = cmd.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["FEEDBACK_DESCRIPTION"],dr["CUSTOMER_ID"]);
                }
                dr.Close();
                }
                catch (Exception ex)
                {
                string message = ex.ToString();
                string title = "ERROR Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
                }
         }
    }
}
